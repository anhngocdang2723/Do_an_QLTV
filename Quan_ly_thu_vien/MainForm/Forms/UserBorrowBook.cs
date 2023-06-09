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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MainForm
{
    public partial class UserBorrowBook : Form
    {
        Save.Share_DbServices db = new Save.Share_DbServices();
        public void LoadData()
        {
            try 
            {
                using (db.con)//LINQ
                {
                    var booksQuery = from b in db.Books
                                     select new
                                     {
                                         MaSach = b.BookID,
                                         TenSach = b.BName,
                                         TheLoai = b.Title,
                                         TacGia = b.Author,
                                         NamPhatHanh = b.YearPublished,
                                         SoLuong = b.Quantity
                                     };

                    dataGridView1.DataSource = booksQuery.ToList();

                    string username = Save.User_Pass.uname;
                    int readerID = db.Accounts
                        .Where(a => a.Username == username)
                        .Select(a => a.ReaderID)
                        .FirstOrDefault();

                    txtReaderID.Text = readerID.ToString();
                }

                /*ADO.NET
                string sqlSelect = "Select B.bookID as N'Mã sách', B.bname as N'Tên sách', B.title as N'Thể loại', B.author as N'Tác giả',B.year_published as N'Năm phát hành', B.quantity as N'Số lượng'" +
                                    "From Books B";
                SqlCommand cmd = new SqlCommand(sqlSelect, db.con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

                // lấy readerID
                string query = "SELECT readerID FROM accounts WHERE username = @Username";
                SqlCommand command = new SqlCommand(query, db.con);
                command.Parameters.AddWithValue("@Username", Save.User_Pass.uname);
                //          db.con.Open();
                int readerID = (int)command.ExecuteScalar();
                //          db.con.Close();
                txtReaderID.Text = readerID.ToString();
                */

                comboBox1.Text = "Tên sách";
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].Width = 220;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 170;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 60;
            }
            catch
            {
                MessageBox.Show("lỗi dữ liệu");
            }

        }
        public UserBorrowBook()
        {
            InitializeComponent();
        }

        private void UserBorrowBook_Load(object sender, EventArgs e)
        {
            db.con.Open();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtBookID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int readerID = int.Parse(txtReaderID.Text);
                int bookID = int.Parse(txtBookID.Text);
                DateTime borrowDate = DateTime.Now;
                DateTime returnDate = dateReturn.Value;
                int quantity = int.Parse(txtQuantity.Text);

                using (db.con) // Replace 'YourDatabaseContext' with your actual database context
                {
                    var borrow = new Borrows
                    {
                        BookID = bookID,
                        ReaderID = readerID,
                        BorrowDate = borrowDate,
                        DueDate = returnDate,
                        QuantityBorrowed = quantity,
                        IsDeleted = false
                    };

                    db.Borrows.Add(borrow);
                    db.SaveChanges();
                }

                /* ADO.NET
                int readerID = int.Parse(txtReaderID.Text);
                int bookID = int.Parse(txtBookID.Text);
                DateTime borrowDate = DateTime.Now;
                DateTime returnDate = dateReturn.Value;
                int quantity = int.Parse(txtQuantity.Text);

                string insertQuery = "INSERT INTO borrows ( bookID,  readerID, borrow_date, due_date, quantity_borrowed, is_deleted) VALUES ( @bookID,  @readerID,  @borrowDate, @dueDate, @quantity_borrowed, 'false')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, db.con);

                insertCommand.Parameters.AddWithValue("@bookID", bookID);
                insertCommand.Parameters.AddWithValue("@readerID", readerID);
                insertCommand.Parameters.AddWithValue("@borrowDate", borrowDate);
                insertCommand.Parameters.AddWithValue("@dueDate", returnDate);
                insertCommand.Parameters.AddWithValue("@quantity_borrowed", quantity);
                insertCommand.ExecuteNonQuery();
                */
                LoadData();
                MessageBox.Show("Mượn sách thành công!");

                txtBookID.Clear();
                dateReturn.Refresh();
                txtQuantity.Clear();
                txtTuKhoa.Clear();
                comboBox1.Refresh();
            }
            catch
            {
                MessageBox.Show("lỗi dữ liệu");
            }
            LoadData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
