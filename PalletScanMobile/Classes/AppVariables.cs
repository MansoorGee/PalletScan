using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PalletScanMobile
{
    public static class AppVariables
    {
        public static string DeviceName { get; set; }
        public static string UpdatedBy { get; set; }
        public static RoleType RoleName { get; set; }
        public static bool WithoutInternet { get; set; }
        public static string DeviceIP { get; set; }
        
        public static readonly string VersionNumber = "Version 2.5.0.1";
        public static readonly string ProjectName = "PalletScan";
        public static readonly string NetworkDown = "Network/WiFi is down. Please contact Network administrator.";
    }
}
