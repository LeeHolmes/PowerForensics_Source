﻿using System;
using System.Text;
using InvokeIR.Win32;

namespace PowerForensics.Registry
{
    //TODO: Determine if Data is Resident or NonResident
    //TODO: Get Data Buffer
    //TODO: Interpret Data based on Data Type
    #region ValueKeyClass

    public class ValueKey : Cell
    {
        #region Enums

        public enum VALUE_KEY_DATA_TYPES
        {
            REG_NONE = 0x00000000,
            REG_SZ = 0x00000001,
            REG_EXPAND_SZ = 0x00000002,
            REG_BINARY = 0x00000003,
            REG_DWORD = 0x00000004,
            REG_DWORD_BIG_ENDIAN = 0x00000005,
            REG_LINK = 0x00000006,
            REG_MULTI_SZ = 0x00000007,
            REG_RESOURCE_LIST = 0x00000008,
            REG_FULL_RESOURCE_DESCRIPTOR = 0x00000009,
            REG_RESOURCE_REQUIREMENTS_LIST = 0x0000000A,
            REG_QWORD = 0x0000000B
        }

        [FlagsAttribute]
        public enum VALUE_KEY_FLAGS
        {
            NameIsUnicode = 0x0000,
            NameIsAscii = 0x0001,
        }

        #endregion Enums

        #region Properties

        public readonly string HivePath;
        public readonly string Key;
        private readonly ushort NameLength;
        public readonly uint DataLength;
        private readonly bool ResidentData;
        private readonly uint DataOffset;
        public readonly VALUE_KEY_DATA_TYPES DataType;
        private readonly VALUE_KEY_FLAGS Flags;
        public readonly string Name;

        #endregion Properties

        #region Constructors

        internal ValueKey(byte[] bytes, string path, string key)
        {
            Signature = Encoding.ASCII.GetString(bytes, 0x04, 0x02);
            
            if (Signature == "vk")
            {
                HivePath = path;
                Key = key;
                #region CellHeader

                Size = BitConverter.ToInt32(bytes, 0x00);

                if (Size >= 0)
                {
                    Allocated = false;
                }
                else
                {
                    Allocated = true;
                }

                #endregion CellHeader
                NameLength = BitConverter.ToUInt16(bytes, 0x06);
                #region DataLength

                uint dataLengthRaw = BitConverter.ToUInt32(bytes, 0x08);

                if (dataLengthRaw > 0x80000000)
                {
                    DataLength = dataLengthRaw - 0x80000000;
                    ResidentData = true;
                }
                else
                {
                    DataLength = dataLengthRaw;
                    ResidentData = false;
                }
                
                #endregion DataLength
                DataOffset = BitConverter.ToUInt32(bytes, 0x0C) + RegistryHeader.HBINOFFSET;
                DataType = (VALUE_KEY_DATA_TYPES)BitConverter.ToUInt32(bytes, 0x10);
                Flags = (VALUE_KEY_FLAGS)BitConverter.ToUInt16(bytes, 0x14);
                #region ValueName

                if (NameLength == 0)
                {
                    Name = "(Default)";
                }
                else
                {
                    if (Flags == VALUE_KEY_FLAGS.NameIsAscii)
                    {
                        Name = Encoding.ASCII.GetString(bytes, 0x18, NameLength);
                    }
                    else
                    {
                        Name = Encoding.Unicode.GetString(bytes, 0x18, NameLength);
                    }
                }

                #endregion ValueName
            }
            else
            {
                throw new Exception("Cell is not a valid Value Key");
            }
        }

        #endregion Constructors

        #region StaticMethods

        public static ValueKey Get(string path, string key, string val)
        {
            byte[] bytes = Helper.GetHiveBytes(path);

            NamedKey hiveroot = Helper.GetRootKey(bytes, path);

            NamedKey nk = hiveroot;

            if (key != null)
            {
                foreach (string k in key.Split('\\'))
                {
                    foreach (NamedKey n in nk.GetSubKeys(bytes))
                    {
                        if (n.Name.ToUpper() == k.ToUpper())
                        {
                            nk = n;
                        }
                    }
                }
            }

            ValueKey[] values = nk.GetValues(bytes);

            foreach (ValueKey v in values)
            {
                if (v.Name.ToUpper() == val.ToUpper())
                {
                    return v;
                }
            }

            return null;
        }

        internal static ValueKey Get(byte[] bytes, string path, string key, string val)
        {
            NamedKey hiveroot = Helper.GetRootKey(bytes, path);

            NamedKey nk = hiveroot;

            if (key != null)
            {
                foreach (string k in key.Split('\\'))
                {
                    foreach (NamedKey n in nk.GetSubKeys(bytes))
                    {
                        if (n.Name.ToUpper() == k.ToUpper())
                        {
                            nk = n;
                        }
                    }
                }
            }

            ValueKey[] values = nk.GetValues(bytes);

            foreach (ValueKey v in values)
            {
                if (v.Name.ToUpper() == val.ToUpper())
                {
                    return v;
                }
            }

            return null;
        }

        public static ValueKey[] GetInstances(string path, string key)
        {
            byte[] bytes = Helper.GetHiveBytes(path);

            NamedKey hiveroot = Helper.GetRootKey(bytes, path);

            NamedKey nk = hiveroot;

            if (key != null)
            {
                foreach (string k in key.Split('\\'))
                {
                    foreach (NamedKey n in nk.GetSubKeys(bytes))
                    {
                        if (n.Name.ToUpper() == k.ToUpper())
                        {
                            nk = n;
                        }
                    }
                }
            }

            return nk.GetValues(bytes);
        }

        internal static ValueKey[] GetInstances(byte[] bytes, string path, string key)
        {
            NamedKey hiveroot = Helper.GetRootKey(bytes, path);

            NamedKey nk = hiveroot;

            if (key != null)
            {
                foreach (string k in key.Split('\\'))
                {
                    foreach (NamedKey n in nk.GetSubKeys(bytes))
                    {
                        if (n.Name.ToUpper() == k.ToUpper())
                        {
                            nk = n;
                        }
                    }
                }
            }

            return nk.GetValues(bytes);
        }

        #endregion StaticMethods

        #region InstanceMethods

        public byte[] GetData()
        {
            if (this.ResidentData)
            {
                return BitConverter.GetBytes(this.DataOffset - RegistryHeader.HBINOFFSET);
            }
            else
            {
                byte[] bytes = Helper.GetHiveBytes(this.HivePath);
                return NativeMethods.GetSubArray(bytes, this.DataOffset + 0x04, this.DataLength);
            }
        }

        public byte[] GetData(byte[] bytes)
        {
            if (this.ResidentData)
            {
                return BitConverter.GetBytes(this.DataOffset - RegistryHeader.HBINOFFSET);
            }
            else
            {
                return NativeMethods.GetSubArray(bytes, this.DataOffset + 0x04, this.DataLength);
            }
        }

        #endregion InstanceMethods
    }

    #endregion ValueKeyClass
}
