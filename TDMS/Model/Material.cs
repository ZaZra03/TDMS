using System;

namespace TDMS.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
    }
}
