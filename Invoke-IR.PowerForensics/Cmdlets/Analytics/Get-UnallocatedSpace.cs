﻿using System;
using System.IO;
using System.Management.Automation;
using InvokeIR.Win32;
using PowerForensics.Ntfs;

namespace PowerForensics.Cmdlets
{
    #region GetUnallocatedSpaceCommand
    
    /// <summary> 
    /// This class implements the Get-UnallocatedSpace cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Get, "UnallocatedSpace")]
    public class GetUnallocatedSpaceCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the the name of the target volume.
        /// </summary> 
        [Parameter(Position = 0)]
        public string VolumeName
        {
            get { return volume; }
            set { volume = value; }
        }
        private string volume;

        /// <summary> 
        ///
        /// </summary> 
        [Parameter(Mandatory = false)]
        public ulong Path
        {
            get { return path; }
            set { path = value; }
        }
        private ulong path;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// 
        /// </summary> 
        protected override void BeginProcessing()
        {
            NativeMethods.checkAdmin();
            NativeMethods.getVolumeName(ref volume);
        }

        /// <summary> 
        /// 
        /// </summary> 
        protected override void ProcessRecord()
        {
            IntPtr hVolume = NativeMethods.getHandle(volume);
            using(FileStream streamToRead = NativeMethods.getFileStream(hVolume))
            {
                foreach (Bitmap b in Bitmap.GetInstances(volume))
                {
                    if (!(b.InUse))
                    {
                        WriteObject(b);
                    }
                }
            }
        } 

        #endregion Cmdlet Overrides
    }

    #endregion GetUnallocatedSpaceCommand
}
