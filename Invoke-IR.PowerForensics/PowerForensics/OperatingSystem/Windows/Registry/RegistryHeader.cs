﻿using System;
using System.Text;
using InvokeIR.PowerForensics.Ntfs;
using InvokeIR.Win32;

namespace InvokeIR.PowerForensics.Registry
{
    public class RegistryHeader
    {
        #region Constants

        internal const int HBINOFFSET = 0x1000;

        #endregion Constants

        #region Enums

        enum FILE_TYPE
        {
            Normal = 0x00,
            TransactionLog = 0x01
        }

        #endregion Enums

        #region Properties

        public readonly string Signature;
        public readonly uint PrimarySequenceNumber;
        public readonly uint SecondarySequenceNumber;
        public readonly DateTime ModificationTime;
        public readonly Version Version;
        public readonly string FileType;
        public readonly uint RootKeyOffset;
        public readonly uint HiveBinsDataSize;
        public readonly uint Checksum;

        #endregion Properties

        #region Constructors

        internal RegistryHeader(byte[] bytes)
        {
            Signature = Encoding.ASCII.GetString(bytes, 0x00, 0x04);

            if(Signature != "regf")
            {
                throw new Exception("Invalid Registry Header");
            }

            PrimarySequenceNumber = BitConverter.ToUInt32(bytes, 0x04);
            SecondarySequenceNumber = BitConverter.ToUInt32(bytes, 0x08);
            ModificationTime = DateTime.FromFileTimeUtc(BitConverter.ToInt64(bytes, 0x0C));
            Version = new Version(BitConverter.ToInt32(bytes, 0x14), BitConverter.ToInt32(bytes, 0x18));
            FileType = Enum.GetName(typeof(FILE_TYPE), 0x1C);
            RootKeyOffset = BitConverter.ToUInt32(bytes, 0x24);
            HiveBinsDataSize = BitConverter.ToUInt32(bytes, 0x28);
            Checksum = BitConverter.ToUInt32(bytes, 0x1FC);
        }

        #endregion Constructors

        #region StaticMethods
        
        public static byte[] GetBytes(string path)
        {
            // Get bytes for the specific record
            string volume = "\\\\.\\" + path.Split('\\')[0];
            IndexEntry entry = IndexEntry.Get(path);
            FileRecord record = new FileRecord(FileRecord.GetRecordBytes(volume, (int)entry.RecordNumber), volume, true);
            byte[] bytes = record.GetBytes();

            // Registry Header
            return NativeMethods.GetSubArray(bytes, 0x00, 0x200);
        }

        public static RegistryHeader Get(string path)
        {
            return new RegistryHeader(RegistryHeader.GetBytes(path));
        }

        #endregion StaticMethods
    }
}
