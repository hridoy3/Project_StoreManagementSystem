using System;

namespace WarehouseApp.BLL
{
    class TransactionDetailsBLL
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal Total { get; set; }
        //public decimal Paid
        //{
        //    set
        //    {
        //        Paid = 0;
        //    }
        //    get
        //    {
        //        return 0;
        //    }
        //}
        public int TransactionID { get; set; }
        public int Dea_Cust_Id { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddedBy { get; set; }




    }
}
