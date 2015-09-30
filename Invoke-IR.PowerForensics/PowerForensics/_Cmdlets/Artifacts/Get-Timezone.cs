﻿using System;
using System.Management.Automation;
using PowerForensics.Registry;
using PowerForensics.Artifacts;

namespace PowerForensics.Cmdlets
{
    #region GetTimezoneCommand
    
    /// <summary> 
    /// This class implements the Get-Timezone cmdlet. 
    /// </summary> 
    [Cmdlet(VerbsCommon.Get, "Timezone")]
    public class GetTimezoneCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the the path of the Registry Hive to parse.
        /// </summary> 
        [Alias("HivePath")]
        [Parameter(Mandatory = false, Position = 0)]
        public string Path
        {
            get { return hivePath; }
            set { hivePath = value; }
        }
        private string hivePath;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// The ProcessRecord method calls TimeZone.CurrentTimeZone to return a TimeZone object.
        /// </summary> 
        protected override void ProcessRecord()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Path"))
            {
                 WriteObject(Timezone.Get(hivePath));
            }
            else
            {
                WriteObject(Timezone.Get());
            }
        } 

        #endregion Cmdlet Overrides
    }
    
    #endregion GetTimezoneCommand
}
