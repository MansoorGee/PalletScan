using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PalletScanMobile
{
    public class Item
    {
        public string SerialNumber { get; set; }
        public bool ProcessByIT { get; set; }
        public bool IsMatched { get; set; }
        public bool PresentInStock { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsManualUpdated { get; set; }
        public string DeviceName { get; set; }
        public long SyncId { get; set; }
        public string Location { get; set; }
    }
}
