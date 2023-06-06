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
                string username = Save.User_Pass.uname;
                //LINQ
                using (db.con)
                {
                    var readerID = (
                        from acc in Accounts
                        where acc.Username == username
                        select acc.readerID
                    ).FirstOrDefault();

                    var query = from br in db.Borrows
                                join r in db.Readers on br.ReaderID equals r.ReaderID
                                join b in db.Books on br.BookID equals b.BookID
                                where br.ReaderID == readerID && br.IsDeleted == false
                                select new
                                {
                                    TenDocGia = r.RName,
                                    TenSach = b.BName,
                                    NgayMuon = br.BorrowDate,
                                    NgayTra = br.DueDate,
                                    SoLuong = br.QuantityBorrowed
                                };

                    dataGridView1.DataSource = query.ToList();
                }

                //
                /*
                string query = "SELECT readerID FROM accounts WHERE username = @Username";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.Parameters.AddWithValue("@Username", Save.User_Pass.uname);
                int readerID = (int)cmd.ExecuteScalar();

                string SelectQuery = "Select r.rname as N'Tên độc giả', b.bname as N'Tên sách', br.borrow_date as N'Ngày mượn', br.due_date as N'Ngày trả', br.quantity_borrowed as N'Số lượng'FROM Borrows br \r\n LEFT JOIN Readers r ON r.readerID = br.readerID \r\n LEFT JOIN Books b ON b.bookID = br.bookID \r\n WHERE br.readerID LIKE @rID and br.is_deleted = 'false'";
                SqlCommand command = new SqlCommand(SelectQuery, db.con);
                command.Parameters.AddWithValue("@rID", readerID);
                SqlDataReader dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                */
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
