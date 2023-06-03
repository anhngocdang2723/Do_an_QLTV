using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm.Forms
{
    public partial class UserBorrowed : Form
    {
        public UserBorrowed()
        {
            InitializeComponent();
        }
        Save.Share_DbServices db = new Save.Share_DbServices();
        public void LoadData()
        {
            try
            {
                //lấy readerID của tk đang login
                string query = "SELECT readerID FROM accounts WHERE username = @Username";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.Parameters.AddWithValue("@Username", Save.User_Pass.uname);
                int readerID = (int)cmd.ExecuteScalar();


                //select tt ra gridview
                string SelectQuery = "Select r.rname as N'Tên độc giả', b.bname as N'Tên sách', br.borrow_date as N'Ngày mượn', br.due_date as N'Ngày trả', br.quantity_borrowed as N'Số lượng' \r\n FROM Borrows br \r\n LEFT JOIN Readers r ON r.readerID = br.readerID \r\n LEFT JOIN Books b ON b.bookID = br.bookID \r\n WHERE br.readerID LIKE @rID";
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
        private void UserBorrowed_Load(object sender, EventArgs e)
        {
            db.con.Open();
            LoadData();
        }
    }
}
