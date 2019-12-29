using System;

namespace WarehouseApp.BLL
{
    class CustDeaBLL
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddedBy { get; set; }
        public decimal Due { get; set; }
        public decimal DueAtCreation
        {
            set
            {
                Due = 0;
            }
            get
            {
                return 0;
            }
        }
    }
}
