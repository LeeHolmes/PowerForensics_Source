﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Management.Automation;
using PowerForensics.Ntfs;
using InvokeIR.Win32;

namespace PowerForensics.Cmdlet
{
    #region GetMftSlackCommand

    /// <summary> 
    /// This class implements the Get-MftSlack cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Get, "MftSlack", SupportsShouldProcess = true, DefaultParameterSetName = "ByIndex")]
    public class GetMftSlackCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// 
        /// returned.
        /// </summary> 
        [Parameter(ParameterSetName = "ByIndex")]
        public string VolumeName
        {
            get { return volume; }
            set { volume = value; }
        }
        private string volume;

        /// <summary> 
        /// 
        /// </summary> 
        [Parameter(Position = 0, ParameterSetName = "ByIndex")]
        public int Index
        {
            get { return indexNumber; }
            set { indexNumber = value; }
        }
        private int indexNumber;

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
        [Parameter(Mandatory = true, ParameterSetName = "ByMftPath")]
        public string MftPath
        {
            get { return mftpath; }
            set { mftpath = value; }
        }
        private string mftpath;

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
        /// The ProcessRecord instantiates a FileRecord objects that
        /// corresponds to the file(s) that is/are specified.
        /// </summary> 
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "ByIndex":
                    if (MyInvocation.BoundParameters.ContainsKey("Index"))
                    {
                        WriteObject(FileRecord.Get(volume, indexNumber, true).GetMftSlack());
                    }
                    else
                    {
                        WriteObject(MasterFileTable.GetSlack(volume));
                    }
                    break;
                case "ByPath":
                    WriteObject(FileRecord.Get(path, true).GetMftSlack());
                    break;
                case "MFTPath":
                    WriteObject(MasterFileTable.GetSlackByPath(mftpath));
                    break;
            }
        }

        #endregion Cmdlet Overrides
    }

    #endregion GetMftSlackCommand
}

