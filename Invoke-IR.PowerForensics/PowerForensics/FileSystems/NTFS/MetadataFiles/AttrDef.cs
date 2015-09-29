﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using InvokeIR.Win32;

namespace InvokeIR.PowerForensics.Ntfs
{
    #region AttrDefClass

    public class AttrDef
    {
        #region Constants

        internal const int ATTRDEF_INDEX = 4;

        #endregion Constants

        #region Enums

        [FlagsAttribute]
        public enum ATTR_DEF_ENTRY
        {
            INDEX = 0x02,
            ALWAYS_RESIDENT = 0x40,
            ALWAYS_NONRESIDENT = 0x80
        }
        
        #endregion Enums

        #region Properties

        public readonly string Name;
        public readonly uint Type;
        public readonly uint DisplayRule;
        public readonly string CollationRule;
        public readonly ATTR_DEF_ENTRY Flags;
        public readonly ulong MinSize;
        public readonly ulong MaxSize;

        #endregion Properties

        #region Constructors

        internal AttrDef(byte[] bytes)
        {
            Name = Encoding.Unicode.GetString(bytes, 0x00, 0x80).TrimEnd('\0');
            Type = BitConverter.ToUInt32(bytes, 0x80);
            DisplayRule = BitConverter.ToUInt32(bytes, 0x84);
            #region CollationRuleSwitch
            
            switch (BitConverter.ToUInt32(bytes, 0x88))
            {
                case 0x00:
                    CollationRule = "Binary";
                    break;
                case 0x01: 
                    CollationRule = "Filename";
                    break;
                case 0x02: 
                    CollationRule = "Unicode String";
                    break;
                case 0x10: 
                    CollationRule = "Unsigned Long";
                    break;
                case 0x11: 
                    CollationRule = "SID";
                    break;
                case 0x12:
                    CollationRule = "Security Hash";
                    break;
                case 0x13:
                    CollationRule = "Multiple Unsigned Longs";
                    break;
                default:
                    CollationRule = "unknown";
                    break;
            }

            #endregion CollationRuleSwitch
            Flags = (ATTR_DEF_ENTRY)BitConverter.ToUInt32(bytes, 0x8C);
            MinSize = BitConverter.ToUInt64(bytes, 0x90);
            MaxSize = BitConverter.ToUInt64(bytes, 0x98);
        }

        #endregion Constructors

        #region StaticMethods

        internal static AttrDef[] GetInstances(byte[] bytes)
        {
            // Instantiate a List of AttrDef objects for output
            List<AttrDef> adList = new List<AttrDef>();

            // Iterate through 160 byte chunks (representing an AttrDef object)
            for (uint i = 0; (i < bytes.Length) && (bytes[i] != 0); i += 160)
            {
                // Intantiate a new AttrDef object and add it to the adList List of AttrDef objects
                adList.Add(new AttrDef(NativeMethods.GetSubArray(bytes, i, 0xA0)));
            }
            return adList.ToArray();
        }

        public static AttrDef[] GetInstances(string volume)
        {
            FileRecord record = FileRecord.Get(volume, ATTRDEF_INDEX, true);
            return AttrDef.GetInstances(record.GetBytes());
        }

        public static AttrDef[] GetInstancesByPath(string path)
        {
            FileRecord record = FileRecord.Get(path, true);
            return AttrDef.GetInstances(record.GetBytes());
        }

        #endregion StaticMethods
    }

    #endregion AttrDefClass
}
