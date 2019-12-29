using System;
using System.Collections.Generic;
using WarehouseApp.DAL;

namespace WarehouseApp.BLL
{
    class UsersEditBLL
    {
        UsersEditDAL da = new UsersEditDAL();
        public int Id { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime modified_date { get; set; }
        UsersEditBLL u;
        
        public List<UsersEditBLL> GetAllUser()
        {
            var usersEditBll = da.GetAllUsers();
            List<UsersEditBLL> list = new List<UsersEditBLL>();
            for (int i = 0; i < usersEditBll.Rows.Count; i++)
            {
                u = new UsersEditBLL();
                u.Id = FormLogin.loggedInUserId;
                u.Password = usersEditBll.Rows[i][0].ToString();
                u.Contact = usersEditBll.Rows[i][1].ToString();
                u.Email = usersEditBll.Rows[i][2].ToString();
                u.Address = usersEditBll.Rows[i][3].ToString();

                list.Add(u);
            }
            return list;
        }
        
        

    }



}
