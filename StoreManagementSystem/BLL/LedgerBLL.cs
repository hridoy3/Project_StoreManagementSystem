using System;

namespace WarehouseApp.BLL
{
    class LedgerBLL
    {
        public decimal Rate { get; set; }
        public int Id { get; set; }
        public decimal Qty { get; set; }
        public decimal Total { get; set; }
        public string Type { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime transaction_date { get; set; }
        public int AddedBy { get; set; }
        public int dea_cust_id { get; set; }
        public int n_cust_id { get; set; }
        public int Product_id { get; set; }
        public decimal Balance { get; set; }
        public string Title { get; set; }
        public decimal Bill { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
