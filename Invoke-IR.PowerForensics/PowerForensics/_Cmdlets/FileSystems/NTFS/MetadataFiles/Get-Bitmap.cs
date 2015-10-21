﻿using System;
using System.Management.Automation;
using InvokeIR.Win32;
using PowerForensics.Ntfs;

namespace PowerForensics.Cmdlets
{
    #region GetBitmapCommand
    
    /// <summary> 
    /// This class implements the Get-Bitmap cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Get, "Bitmap", DefaultParameterSetName = "ByVolume")]
    public class GetBitmapCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the the name of the target volume.
        /// </summary> 
        [Parameter(ParameterSetName = "ByVolume")]
        public string VolumeName
        {
            get { return volume; }
            set { volume = value; }
        }
        private string volume;

        /// <summary> 
        ///
        /// </summary> 
        [Alias("FullName")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ByPath", ValueFromPipelineByPropertyName = true)]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string path;

        /// <summary> 
        ///
        /// </summary> 
        [Parameter(Mandatory = true, ParameterSetName = "ByVolume")]
        [Parameter(Mandatory = true, ParameterSetName = "ByPath")]
        public ulong Cluster
        {
            get { return cluster; }
            set { cluster = value; }
        }
        private ulong cluster;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// The BeginProcessing method returns.
        /// </summary> 
        protected override void BeginProcessing()
        {
            NativeMethods.checkAdmin();

            if (ParameterSetName == "ByVolume")
            {
                NativeMethods.getVolumeName(ref volume);
            }
        }

        /// <summary> 
        /// The ProcessRecord method returns.
        /// </summary> 
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "ByVolume":
                    WriteObject(Bitmap.Get(volume, cluster));
                    break;
                case "ByPath":
                    WriteObject(Bitmap.GetByPath(path, cluster));
                    break;
            }
        }

        #endregion Cmdlet Overrides
    }

    #endregion GetBitmapCommand
}
