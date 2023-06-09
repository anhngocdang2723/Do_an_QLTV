﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm.Forms
{
    public partial class UserReturned : Form
    {
        public UserReturned()
        {
            InitializeComponent();
        }
        Save.Share_DbServices db = new Save.Share_DbServices();
        public void LoadData()
        {
            try
            {
                string query = "SELECT readerID FROM accounts WHERE username = @Username";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.Parameters.AddWithValue("@Username", Save.User_Pass.uname);
                int readerID = (int)cmd.ExecuteScalar();

                string SelectQuery = "Select r.rname as N'Tên độc giả', b.bname as N'Tên sách', br.borrow_date as N'Ngày mượn', rt.return_date as N'Ngày trả', rt.quantity_returned as N'Số lượng trả'" +
                                     "FROM Returns rt " +
                                     "Join Borrows br on br.borrowID = rt.borrowID " +
                                     "full outer Join Readers r on br.readerID = r.readerID " +
                                     "full outer Join Books b on b.bookID = br.bookID " +
                                     "WHERE r.readerID LIKE @rID and is_deleted = 'true'";
                SqlCommand command = new SqlCommand(SelectQuery, db.con);
                command.Parameters.AddWithValue("@rID", readerID);
                SqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("lỗi dữ liệu");
            }

        }
        private void UserReturned_Load(object sender, EventArgs e)
        {
            db.con.Open();
            LoadData();
        }
    }
}
