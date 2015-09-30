﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using PowerForensics.Registry;

namespace PowerForensics.Artifacts
{
    public class NetworkList
    {
        #region Properties

        public readonly DateTime WriteTime;
        public readonly string ProfileGuid;
        public readonly string Description;
        public readonly uint Source;
        public readonly string DnsSuffix;
        public readonly string FirstNetwork;
        public readonly PhysicalAddress DefaultGatewayMac;

        #endregion Properties

        #region Constructors

        internal NetworkList(NamedKey nk, byte[] bytes)
        {
            WriteTime = nk.WriteTime;

            foreach (ValueKey vk in nk.GetValues(bytes))
            {
                switch (vk.Name)
                {
                    case "ProfileGuid":
                        ProfileGuid = Encoding.Unicode.GetString(vk.GetData(bytes));
                        break;
                    case "Description":
                        Description = Encoding.Unicode.GetString(vk.GetData(bytes));
                        break;
                    case "Source":
                        Source = BitConverter.ToUInt32(vk.GetData(bytes), 0x00);
                        break;
                    case "DnsSuffix":
                        DnsSuffix = Encoding.Unicode.GetString(vk.GetData(bytes));
                        break;
                    case "FirstNetwork":
                        FirstNetwork = Encoding.Unicode.GetString(vk.GetData(bytes));
                        break;
                    case "DefaultGatewayMac":
                        DefaultGatewayMac = new PhysicalAddress(vk.GetData(bytes));
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion Constructors

        #region StaticMethods

        #region GetInstancesMethods

        public static NetworkList[] GetInstances()
        {
            string hivePath = @"C:\windows\system32\config\SOFTWARE";
            return GetInstances(hivePath);
        }

        public static NetworkList[] GetInstances(string hivePath)
        {
            string Key = @"Software\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures";

            byte[] bytes = Registry.Helper.GetHiveBytes(hivePath);

            NamedKey[] SignatureKey = NamedKey.GetInstances(bytes, hivePath, Key);

            List<NetworkList> nlList = new List<NetworkList>();

            foreach (NamedKey key in SignatureKey)
            {
                if (key.NumberOfSubKeys != 0)
                {
                    foreach (NamedKey nk in key.GetSubKeys(bytes))
                    {
                        nlList.Add(new NetworkList(nk, bytes));
                    }
                }
            }
            return nlList.ToArray();
        }

        #endregion GetInstancesMethods

        #endregion StaticMethods
    }
}
