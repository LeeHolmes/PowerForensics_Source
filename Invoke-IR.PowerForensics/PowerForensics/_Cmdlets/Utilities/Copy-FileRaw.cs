﻿using System;
using System.IO;
using System.Management.Automation;
using InvokeIR.Win32;
using PowerForensics.Ntfs;

namespace PowerForensics.Cmdlets
{
    #region CopyFileRawCommand
    
    /// <summary> 
    /// This class implements the Get-Prefetch cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Copy, "FileRaw")]
    public class CopyFileRawCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the Name of the Volume
        /// for which the FileRecord object should be
        /// returned.
        /// </summary> 
        [Alias("FullName")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ByPath")]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string path;

        /// <summary> 
        /// This parameter provides the MFTIndexNumber for the 
        /// FileRecord object that will be returned.
        /// </summary> 
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ByIndex")]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        private int index;

        /// <summary> 
        /// 
        /// </summary> 
        [Parameter(ParameterSetName = "ByIndex")]
        public string VolumeName
        {
            get { return volume; }
            set { volume = value; }
        }
        private string volume;

        /// <summary> 
        /// This parameter provides the MFTIndexNumber for the 
        /// FileRecord object that will be returned.
        /// </summary> 
        [Parameter(Mandatory = true, Position = 1)]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        private string destination;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// 
        /// </summary> 
        protected override void BeginProcessing()
        {
            NativeMethods.checkAdmin();
            
            if (ParameterSetName == "ByIndex")
            {
                NativeMethods.getVolumeName(ref volume);
            }
        }

        /// <summary> 
        /// The ProcessRecord method calls ManagementClass.GetInstances() 
        /// method to iterate through each BindingObject on each system specified.
        /// </summary> 
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "ByPath":
                    FileRecord record = FileRecord.Get(path, true);
                    record.CopyFile(destination);
                    break;
                case "ByVolume":
                    FileRecord rec = FileRecord.Get(volume, index, true);
                    rec.CopyFile(destination);
                    break;
            }
        }

        #endregion Cmdlet Overrides
    }
    #endregion CopyFileRawCommand
}
