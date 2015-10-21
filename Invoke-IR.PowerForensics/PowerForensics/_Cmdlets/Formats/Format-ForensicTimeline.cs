﻿using System;
using System.Management.Automation;
using PowerForensics.Artifacts;
using PowerForensics.Formats;
using PowerForensics.Ntfs;
using PowerForensics.Registry;

namespace PowerForensics.Cmdlets
{
    #region FormatForensicTimelineCommand
    
    /// <summary> 
    /// This class implements the Format-ForensicTimeline cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Format, "ForensicTimeline")]
    public class FormatForensicTimelineCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the MFTRecord object(s) to
        /// derive Mactime objects from.
        /// </summary> 
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get { return inputobject; }
            set { inputobject = value; }
        }
        private PSObject inputobject;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// 
        /// </summary> 
        protected override void ProcessRecord()
        {
            switch (inputobject.TypeNames[0])
            {
                case "PowerForensics.Artifacts.Amcache":
                    break;
                case "PowerForensics.Artifacts.Prefetch":
                    WriteObject(ForensicTimeline.Get(inputobject.BaseObject as Prefetch), true);
                    break;
                case "PowerForensics.Artifacts.ScheduledJob":
                    WriteObject(ForensicTimeline.Get(inputobject.BaseObject as ScheduledJob), true);
                    break;
                case "PowerForensics.Artifacts.UserAssist":
                    WriteObject(ForensicTimeline.Get(inputobject.BaseObject as UserAssist), true);
                    break;
                case "PowerForensics.Ntfs.FileRecord":
                    FileRecord r = inputobject.BaseObject as FileRecord;
                    try
                    {
                        WriteObject(ForensicTimeline.Get(r), true);
                    }
                    catch
                    {
                        
                    }
                    break;
                case "PowerForensics.Ntfs.UsnJrnl":
                    WriteObject(ForensicTimeline.Get(inputobject.BaseObject as UsnJrnl), true);
                    break;
                case "PowerForensics.Registry.NamedKey":
                    WriteObject(ForensicTimeline.Get(inputobject.BaseObject as NamedKey), true);
                    break;
                default:
                    Console.WriteLine(inputobject.TypeNames[0]);
                    break;
            }
        }

        #endregion Cmdlet Overrides
    }

    #endregion FormatForensicTimelineCommand
}