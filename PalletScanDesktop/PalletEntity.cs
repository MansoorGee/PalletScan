using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalletScanDesktop
{
    public class PalletEntity
    {

        public decimal availableField { get; set; }

        public bool availableFieldSpecified { get; set; }

        public string batchNumberField { get; set; }

        public string colorField { get; set; }

        public string configField { get; set; }

        public System.DateTime dateUpdatedField { get; set; }

        public bool dateUpdatedFieldSpecified { get; set; }

        public string deviceNameField { get; set; }

        public bool isManualField { get; set; }

        public bool isManualFieldSpecified { get; set; }

        public bool isMatchedField { get; set; }

        public bool isMatchedFieldSpecified { get; set; }

        public string itemNumberField { get; set; }

        public string locationField { get; set; }

        public string palletField { get; set; }

        public bool presentInStockField { get; set; }

        public bool presentInStockFieldSpecified { get; set; }

        public bool processByITField { get; set; }

        public bool processByITFieldSpecified { get; set; }

        public string productNameField { get; set; }

        public string sizeField { get; set; }

        public long syncIdField { get; set; }

        public bool syncIdFieldSpecified { get; set; }

        public string updatedByField { get; set; }

        public string warehouseField { get; set; }

        
    }
}
