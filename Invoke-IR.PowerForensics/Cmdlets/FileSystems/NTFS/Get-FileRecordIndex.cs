﻿using System;
using System.Collections.Generic;
using System.Management.Automation;
using PowerForensics.Ntfs;
using InvokeIR.Win32;

namespace PowerForensics.Cmdlet
{
    #region GetFileRecordIndexCommand
    
    /// <summary> 
    /// This class implements the Get-FileRecordIndex cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Get, "FileRecordIndex")]
    public class FileRecordIndexCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the Name of the Volume
        /// for which the FileRecord object should be
        /// returned.
        /// </summary> 
        [Alias("FullName")]
        [Parameter(Mandatory = true, Position = 0)]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string path;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// 
        /// </summary> 
        protected override void BeginProcessing()
        {
            NativeMethods.checkAdmin();
        }

        /// <summary> 
        /// 
        /// </summary> 
        protected override void ProcessRecord()
        {
            WriteObject(IndexEntry.Get(path).RecordNumber);
        }

        #endregion Cmdlet Overrides
    }
    #endregion GetFileRecordIndexCommand
}
