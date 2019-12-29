using System;
using System.Data;
using System.Windows.Forms;
using WarehouseApp.BLL;
using WarehouseApp.DAL;

namespace WarehouseApp
{
    public partial class FormUsersAUD : Form
    {
        UsersBLL uBLL = new UsersBLL();
        UsersDAL uDAL = new UsersDAL();
        bool enableDelete = false;
        //bool enableAdd = false;
        bool enableUpdate = false;
        public FormUsersAUD()
        {
            InitializeComponent();
            DataTable dt = uDAL.Select();
            dataGridViewUser.DataSource = dt;
        }

        void UsernameAvailablity()
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Add User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                

                DataTable userNameColumn = uDAL.GetUsernameList();


                bool isAvailable = UserameAvailable();
                bool checkField = CheckFields();

                if (checkField)
                {
                    AddUser(isAvailable);
                }
                else
                {
                    MessageBox.Show("Please enter Name, Password, Username and User Type");
                }
                

                




                ////User
                //string username = FormLogin.loggedInUser;
                //UsersBLL user = uDAL.GetIdFromUsername(username);
                //uBLL.AddedBy = user.Id;

                ////Inserting data into database

                //bool isAdded = uDAL.Insert(uBLL);

                ////is added
                //if (isAdded)
                //{
                //    MessageBox.Show("Successfully added");
                //    //clear textbox fields
                //    Clear();
                //}
                //else
                //    MessageBox.Show("Failed to add");

                //Refrash data grid view
                DataTable dt = uDAL.Select();
                dataGridViewUser.DataSource = dt;
            }
        }

        bool CheckFields()
        {
            if (textBoxName.Text == "" || textBoxPassword.Text == "" || textBoxUsername.Text == "" || !(comboBoxUserType.Text == "User" || comboBoxUserType.Text == "Admin"))
            {
                return false;
            }
            else
                return true;
        }



        void AddUser(bool isAvailable)
        {
            if (!isAvailable)
            {

                //getting data from user
                uBLL.Name = this.textBoxName.Text;
                uBLL.Email = textBoxEmail.Text;
                uBLL.Username = this.textBoxUsername.Text;
                uBLL.Password = textBoxPassword.Text;
                uBLL.Contact = textBoxContact.Text;
                //uBLL.Area = textBoxArea.Text;
                uBLL.Adderss = textBoxAddress.Text;
                uBLL.Note = textBoxNote.Text;
                uBLL.Gender = comboBoxGender.Text;
                uBLL.UserType = comboBoxUserType.Text;
                uBLL.AddedDate = DateTime.Now;
                //User
                string username = FormLogin.loggedInUser;
                UsersBLL user = uDAL.GetIdFromUsername(username);
                uBLL.AddedBy = user.Id;

                //Inserting data into database

                bool isAdded = uDAL.Insert(uBLL);

                //is added
                if (isAdded)
                {
                    MessageBox.Show("Successfully added");
                    //clear textbox fields
                    Clear();
                }
                else
                    MessageBox.Show("Failed to add");
            }

            else
            {
                MessageBox.Show("Username is already taken.");
            }
        }

        public bool UserameAvailable()
        {
            DataTable userNameColumn = uDAL.GetUsernameList();
            bool isAvailable = false;
            for (int i = 0; i < userNameColumn.Rows.Count; i++)
            {
                if (textBoxUsername.Text.ToString() == userNameColumn.Rows[i][0].ToString())
                {
                    isAvailable = true;
                    
                    //return isAvailable;
                }
                
            }
            return isAvailable;
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            if (enableUpdate)
            {
                if (MessageBox.Show("Are you sure?", "Update User Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //bool isAvailable = UserameAvailable();
                    bool checkField = CheckFields();

                    if (checkField)
                    {
                        uBLL.Id = int.Parse(textBoxId.Text);
                        uBLL.Name = textBoxName.Text;
                        uBLL.Email = textBoxEmail.Text;

                        uBLL.Username = textBoxUsername.Text;
                        uBLL.Password = textBoxPassword.Text;
                        uBLL.Contact = textBoxContact.Text;
                        uBLL.Adderss = textBoxAddress.Text;
                        uBLL.Note = textBoxNote.Text;
                        uBLL.Gender = comboBoxGender.Text;
                        uBLL.UserType = comboBoxUserType.Text;
                        uBLL.modifiedDate = DateTime.Now;
                        //
                        //uBLL.AddedBy = 1;
                        //
                        bool isUpdated = uDAL.Update(uBLL);

                        if (isUpdated)
                        {
                            MessageBox.Show("Successfully Updated");
                            Clear();
                        }
                        else
                            MessageBox.Show("Operation Failed");

                        DataTable dt = uDAL.Select();
                        dataGridViewUser.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Please enter Name, Password and Username");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select row to delete");
            }


        }


        void UpdateUserInfo(bool isAvailable)
        {
            if (!isAvailable)
            {
                uBLL.Id = int.Parse(textBoxId.Text);
                uBLL.Name = textBoxName.Text;
                uBLL.Email = textBoxEmail.Text;

                uBLL.Username = textBoxUsername.Text;
                uBLL.Password = textBoxPassword.Text;
                uBLL.Contact = textBoxContact.Text;
                uBLL.Adderss = textBoxAddress.Text;
                uBLL.Note = textBoxNote.Text;
                uBLL.Gender = comboBoxGender.Text;
                uBLL.UserType = comboBoxUserType.Text;
                uBLL.modifiedDate = DateTime.Now;
                //
                //uBLL.AddedBy = 1;
                //
                bool isUpdated = uDAL.Update(uBLL);

                if (isUpdated)
                {
                    MessageBox.Show("Successfully Updated");
                    Clear();
                }
                else
                    MessageBox.Show("Operation Failed");

                DataTable dt = uDAL.Select();
                dataGridViewUser.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Username is already taken.");
            }
        }

        void Clear()
        {
            textBoxName.Text =
            textBoxEmail.Text =
            textBoxUsername.Text =
            textBoxPassword.Text =
            textBoxContact.Text =
            textBoxAddress.Text =
            textBoxNote.Text =
            comboBoxGender.Text =
            comboBoxUserType.Text =
            textBoxId.Text = string.Empty;
        }

        private void dataGridViewUser_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewUser.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewUser.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxEmail.Text = dataGridViewUser.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxUsername.Text = dataGridViewUser.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxPassword.Text = dataGridViewUser.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxContact.Text = dataGridViewUser.Rows[rowIndex].Cells[5].Value.ToString();
            textBoxAddress.Text = dataGridViewUser.Rows[rowIndex].Cells[6].Value.ToString();
            textBoxNote.Text = dataGridViewUser.Rows[rowIndex].Cells[7].Value.ToString();
            comboBoxGender.Text = dataGridViewUser.Rows[rowIndex].Cells[8].Value.ToString();
            comboBoxUserType.Text = dataGridViewUser.Rows[rowIndex].Cells[9].Value.ToString();

            
            enableDelete = true;
            enableUpdate = true;
        }

        private void buttonDetete_Click(object sender, EventArgs e)
        {
            if (enableDelete)
            {
                if (MessageBox.Show("Are you sure?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    uBLL.Id = int.Parse(textBoxId.Text);

                    bool isDeleted = uDAL.Delete(uBLL);
                    Clear();
                }

                DataTable dt = uDAL.Select();
                dataGridViewUser.DataSource = dt;
                enableDelete = false;
            }
            else
            {
                MessageBox.Show("Select row to delete");

            }
            
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //getting text real time
            string keyWord = textBoxSearch.Text.ToString();

            //
            if (keyWord != null)
            {
                //show user based on keyWord
                uDAL.Search(keyWord);
                DataTable dt = uDAL.Search(keyWord);
                dataGridViewUser.DataSource = dt;
            }
            else
            {
                //show all users
                DataTable dt = uDAL.Select();
                dataGridViewUser.DataSource = dt;
            }
        }

        private void FormUsersAUD_Load(object sender, EventArgs e)
        {
            radioButtonAdd.Checked = true;
        }

        private void textBoxNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;


            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void radioButtonAdd_CheckedChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDetete.Enabled = false;

            textBoxUsername.Enabled = true;
        }

        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = true;
            buttonDetete.Enabled = false;

            textBoxUsername.Enabled = false;
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDetete.Enabled = true;

            textBoxUsername.Enabled = true;
        }
    }
}
