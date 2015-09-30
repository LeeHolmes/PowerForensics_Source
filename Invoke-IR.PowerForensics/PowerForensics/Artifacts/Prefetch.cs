﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using InvokeIR.Win32;
using PowerForensics.Ntfs;

namespace PowerForensics.Artifacts
{
    #region PrefetchClass

    public class Prefetch
    {
        #region Constants

        const string PREFETCH_MAGIC = "SCCA";

        #endregion Constants

        #region Enums

        public enum PREFETCH_VERSION
        {
            WINDOWS_8 = 0x1A,
            WINDOWS_7 = 0x17,
            WINDOWS_XP = 0x11
        }

        #endregion Enums

        #region Parameters

        public readonly PREFETCH_VERSION Version;
        public readonly string Name;
        public readonly string Path;
//        public string MD5
        public readonly string PathHash;
        public readonly int DependencyCount;
        public readonly DateTime[] PrefetchAccessTime;
//        public readonly DateTime PrefetchBornTime;
//        public readonly string ProgramBornTime;
//        public readonly string ProgramChangeTime;
        public readonly int DeviceCount;
        public readonly int RunCount;
        public readonly string[] DependencyFiles;

        #endregion Parameters

        #region Constructors

        private Prefetch(byte[] bytes)
        {
            // Check for Prefetch Magic Number (Value) SCCA at offset 0x04 - 0x07
            if (Encoding.ASCII.GetString(bytes, 0x04, 0x04) == PREFETCH_MAGIC)
            {
                // Check Prefetch file for version (0x1A = Win 8, 0x17 = Win 7, 0x11 = Win XP)
                Version = (PREFETCH_VERSION)bytes[0];
                #region PathHash

                //// Get Prefetch Path Hash Value ////
                // Instantiate byte array
                byte[] pfHashBytes = NativeMethods.GetSubArray(bytes, 0x4C, 0x04);
                // Reverse Little Endian bytes
                Array.Reverse(pfHashBytes);
                // Return string representing Prefetch Path Hash
                PathHash = BitConverter.ToString(pfHashBytes).Replace("-", "");
                
                #endregion PathHash
                #region PrefetchAccessTime

                // Get Prefetch Last Accessed Time Array //
                // Instantiate a null byte array
                byte[] pfAccessTimeBytes = null;
                // Instantiate a List of DateTime Objects
                List<DateTime> pfAccessTimeList = new List<DateTime>();
                // Zero out counter
                int counter = 0;
                // Check Prefetch version
                switch (this.Version)
                {
                    // Windows 8 Version
                    case PREFETCH_VERSION.WINDOWS_8:
                        pfAccessTimeBytes = NativeMethods.GetSubArray(bytes, 0x80, 0x40);
                        counter = 64;
                        break;
                    // Windows 7 Version
                    case PREFETCH_VERSION.WINDOWS_7:
                        pfAccessTimeBytes = NativeMethods.GetSubArray(bytes, 0x80, 0x08);
                        counter = 8;
                        break;
                    // Windows XP Version
                    case PREFETCH_VERSION.WINDOWS_XP:
                        pfAccessTimeBytes = NativeMethods.GetSubArray(bytes, 0x78, 0x08);
                        counter = 8;
                        break;
                }
                for (int i = 0; i < counter; i += 8)
                {
                    long winFileTime = BitConverter.ToInt64(pfAccessTimeBytes, i);
                    DateTime dt = DateTime.FromFileTimeUtc(winFileTime);
                    if ((this.Version == PREFETCH_VERSION.WINDOWS_8) && (dt.ToString() == "1/1/1601 12:00:00 AM"))
                    {
                        break;
                    }
                    pfAccessTimeList.Add(dt);
                }
                PrefetchAccessTime = pfAccessTimeList.ToArray();

                #endregion PrefetchAccessTime
                Name = System.Text.Encoding.Unicode.GetString(bytes, 0x10, 0x3C).TrimEnd('\0');
                #region DependencyFiles

                string dependencyString = Encoding.Unicode.GetString(bytes, BitConverter.ToInt32(bytes, 0x64), BitConverter.ToInt32(bytes, 0x68));
                string[] dependencyArraySplit = dependencyString.Split(new string[] { "\\DEVICE\\" }, StringSplitOptions.RemoveEmptyEntries);
                string[] dependencyArray = new string[dependencyArraySplit.Length];
                for (int i = 0; i < dependencyArraySplit.Length; i++)
                {
                    string dependency = dependencyArraySplit[i].Replace("HARDDISKVOLUME1", "\\DEVICE\\HARDDISKVOLUME1").Replace("\0", string.Empty);
                    if((dependency.Contains(Name)) && (!(dependency.Contains(".MUI"))))
                    {
                        Path = dependency;
                    }
                    dependencyArray[i] = dependency;
                }
                DependencyFiles = dependencyArray;

                #endregion DependencyFiles
                DependencyCount = dependencyArray.Length;
                DeviceCount = BitConverter.ToInt32(bytes, 0x70);
                #region RunCount

                switch (this.Version)
                {
                    case PREFETCH_VERSION.WINDOWS_8:
                        RunCount = BitConverter.ToInt32(bytes, 0xD0);
                        break;
                    case PREFETCH_VERSION.WINDOWS_7:
                        RunCount = BitConverter.ToInt32(bytes, 0x98);
                        break;
                    case PREFETCH_VERSION.WINDOWS_XP:
                        RunCount = BitConverter.ToInt32(bytes, 0x90);
                        break;
                }

                #endregion RunCount
            }
        }
        
        #endregion Constructors

        #region StaticMethods

        #region GetMethods

        public static Prefetch Get(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Get bytes for specific Prefetch file
                byte[] fileBytes = FileRecord.Get(filePath, true).GetBytes();

                // Return a Prefetch object for the Prefetch file stored at filePath
                return new Prefetch(fileBytes);
            }
            else
            {
                throw new FileNotFoundException((filePath + " does not exist.  Please enter a valid file path."));
            }
        }

        public static Prefetch Get(string filePath, bool fast)
        {
            if (File.Exists(filePath))
            {
                // Get bytes for specific Prefetch file
                byte[] fileBytes = null;

                try
                {
                    fileBytes = File.ReadAllBytes(filePath);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("ArgumentException thrown by Prefetch.GetInstance()");
                }
                catch (PathTooLongException)
                {
                    throw new PathTooLongException("PathTooLongException thrown by Prefetch.GetInstance()");
                }
                catch (DirectoryNotFoundException)
                {
                    throw new DirectoryNotFoundException("DirectoryNotFoundException thrown by Prefetch.GetInstance()");
                }
                catch (IOException)
                {
                    throw new IOException("IOException thrown by Prefetch.GetInstance()");
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException("UnauthorizedAccessException thrown by Prefetch.GetInstance()");
                }

                // Return a Prefetch object for the Prefetch file stored at filePath
                return new Prefetch(fileBytes);
            }
            else
            {
                throw new FileNotFoundException((filePath + " does not exist.  Please enter a valid file path."));
            }
        }

        #endregion GetMethods

        #region GetInstancesMethods

        public static Prefetch[] GetInstances(string volume)
        {
            // Get current volume
            NativeMethods.getVolumeName(ref volume);

            // Get volume letter
            string volLetter = volume.Split('\\')[3];

            // Get a handle to the volume
            IntPtr hVolume = NativeMethods.getHandle(volume);

            // Create a FileStream to read from the volume handle
            using (FileStream streamToRead = NativeMethods.getFileStream(hVolume))
            {
                VolumeBootRecord VBR = VolumeBootRecord.Get(streamToRead);

                // Get a byte array representing the Master File Table
                byte[] MFT = MasterFileTable.GetBytes(streamToRead, volume);

                // Build Prefetch directory path
                string pfPath = volLetter + @"\Windows\Prefetch";

                if (Directory.Exists(pfPath))
                {
                    var pfFiles = System.IO.Directory.GetFiles(pfPath, "*.pf");
                    Prefetch[] pfArray = new Prefetch[pfFiles.Length];

                    // Get IndexEntry 
                    IndexEntry[] pfEntries = IndexEntry.GetInstances(pfPath);

                    int i = 0;

                    foreach(IndexEntry entry in pfEntries)
                    {
                        if (entry.Filename.Contains(".pf"))
                        {
                            pfArray[i] = new Prefetch(new FileRecord(NativeMethods.GetSubArray(MFT, (uint)entry.RecordNumber * 0x400, 0x400), volume, true).GetBytes(VBR));
                            i++;
                        }
                    }

                    return pfArray;
                }
                else
                {
                    throw new Exception("Prefetch Directory does not exist. Check registry to ensure Prefetching is enabled.");
                }
            }
        }

        public static Prefetch[] GetInstances(string volume, bool fast)
        {
            // Get current volume
            NativeMethods.getVolumeName(ref volume);

            // Get volume letter
            string volLetter = volume.Split('\\')[3];

            // Build Prefetch directory path
            string prefetchPath = volLetter + @"\\Windows\\Prefetch";

            // Check prefetchPath exists
            if (Directory.Exists(prefetchPath))
            {
                // Get list of file in the Prefetch directory that end in the .pf extension
                var pfFiles = System.IO.Directory.GetFiles(prefetchPath, "*.pf");
                    
                // Instantiate an array of Prefetch objects
                Prefetch[] pfArray = new Prefetch[pfFiles.Length];
                    
                // Iterate through Prefetch Files
                for (int i = 0; i < pfFiles.Length; i++)
                {
                    // Get bytes for specific Prefetch file
                    byte[] fileBytes = null;
                    
                    try
                    {
                        fileBytes = File.ReadAllBytes(pfFiles[i]);
                    }
                    catch (ArgumentException)
                    {
                        throw new ArgumentException("ArgumentException thrown by Prefetch.GetInstance()");
                    }
                    catch(PathTooLongException)
                    {
                        throw new PathTooLongException("PathTooLongException thrown by Prefetch.GetInstance()");
                    }
                    catch (DirectoryNotFoundException)
                    {
                        throw new DirectoryNotFoundException("DirectoryNotFoundException thrown by Prefetch.GetInstance()");
                    }
                    catch (IOException)
                    {
                        throw new IOException("IOException thrown by Prefetch.GetInstance()");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        throw new UnauthorizedAccessException("UnauthorizedAccessException thrown by Prefetch.GetInstance()");
                    }


                    // Output the Prefetch object for the corresponding file
                    pfArray[i] = (new Prefetch(fileBytes));
                }

                // Return array or Prefetch objects
                return pfArray;
            }
            else
            {
                return null;
            }
        }

        #endregion GetInstancesMethods

        #endregion StaticMethods
    }

    #endregion PrefetchClass
}
