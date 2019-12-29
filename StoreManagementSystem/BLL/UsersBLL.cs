using System;

namespace WarehouseApp.BLL
{
    class UsersBLL
    {
        //parameterless constructor
        public UsersBLL()
        {

        }

        //
        // string name, contact, address, mobilNo, email, area, note, id;

        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Adderss { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string Note { get; set; }
        public string Gender { get; set; }
        public string UserType { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime modifiedDate { get; set; }
        public string status { get; set; }


        //Add coustomer
        //public void AddCustomer(string name, string company, string address, string mobilNo, string email, string area, string note)
        //{
        //    this.name = name;
        //    this.contact = company;
        //    this.address = address;
        //    this.mobilNo = mobilNo;
        //    this.email = email;
        //    this.area = area;
        //    this.note = note;
        //}

    }
}
