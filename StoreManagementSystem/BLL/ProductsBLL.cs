using System;

namespace WarehouseApp.BLL
{
    class ProductsBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        public int Category { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public DateTime AddedDate { get; set; }
        //
        public int AddedBy { get; set; }

        ///////////////////////// FromProductsList 

        public DateTime TimeFilterValue { get; set; }

        /////////////////////////


    }
}
