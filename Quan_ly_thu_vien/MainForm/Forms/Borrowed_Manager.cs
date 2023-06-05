using Save;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Borrowed_Manager : Form
    {
        public Borrowed_Manager()
        {
            InitializeComponent();
        }

        Save.Share_DbServices db = new Save.Share_DbServices();

        private void QuanLyMuon_Load(object sender, EventArgs e)
        {
            db.con.Open();
            LoadData();
        }

        public void LoadData()
        {
            string sqlSelect = "Select Br.borrowID as N'Mã phiếu', R.readerID as N'Mã độc giả', R.rname as N'Tên độc giả', B.bookID as N'Mã sách', B.bname as N'Tên sách', Br.borrow_date as N'Ngày mượn', Br.due_date as N'Ngày đến hạn', Br.quantity_borrowed as N'Số lượng'\r\nFrom Borrows Br\r\nJoin Books B on B.bookID = Br.bookID\r\nJoin Readers R On R.ReaderID = Br.readerID \r\nWhere is_deleted = 'false'";
            SqlCommand cmd = new SqlCommand(sqlSelect, db.con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            comboBox1.Text = "Mã phiếu";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 310;
            dataGridView1.Columns[5].Width = 104;
            dataGridView1.Columns[6].Width = 106;
            dataGridView1.Columns[7].Width = 80;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //db.con.Open();
                string borrowID = txtBorrowID.Text;

                string bookID = txtBookID.Text;
                string readerID = txtReaderID.Text;

                string bookQuery = "SELECT bname FROM books WHERE bookID = @bookID";
                string readerQuery = "SELECT rname FROM readers WHERE readerID = @readerID";
                SqlCommand bookCommand = new SqlCommand(bookQuery, db.con);
                SqlCommand readerCommand = new SqlCommand(readerQuery, db.con);
                bookCommand.Parameters.AddWithValue("@bookID", bookID);
                readerCommand.Parameters.AddWithValue("@readerID", readerID);

                string bookName = (string)bookCommand.ExecuteScalar();
                string readerName = (string)readerCommand.ExecuteScalar();

                string quantity_borrowed = txtQuantity_Borrowed.Text;
                DateTime borrowDate = dateBorrow.Value;
                DateTime dueDate = dateReturn.Value;

                string insertQuery = "INSERT INTO borrows ( bookID,  readerID, borrow_date, due_date, quantity_borrowed, is_deleted) VALUES ( @bookID,  @readerID,  @borrowDate, @dueDate, @quantity_borrowed, 'false')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, db.con);

                insertCommand.Parameters.AddWithValue("@borrowID", borrowID);
                insertCommand.Parameters.AddWithValue("@bookID", bookID);
                //insertCommand.Parameters.AddWithValue("@bookName", bookName);
                insertCommand.Parameters.AddWithValue("@readerID", readerID);
                //insertCommand.Parameters.AddWithValue("@readerName", readerName);
                insertCommand.Parameters.AddWithValue("@borrowDate", borrowDate);
                insertCommand.Parameters.AddWithValue("@dueDate", dueDate);
                insertCommand.Parameters.AddWithValue("@quantity_borrowed", quantity_borrowed);
                insertCommand.ExecuteNonQuery();

                LoadData();
            }
            catch
            {
                MessageBox.Show("kiểm tra lại dữ liệu");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtBorrowID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtReaderID.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtBookID.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtQuantity_Borrowed.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            dateBorrow.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            dateReturn.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();

            //LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "update borrows set is_deleted = 'true' where borrowID = '" + txtBorrowID.Text + "'";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, db.con);
                deleteCommand.ExecuteNonQuery();
                txtBorrowID.Clear();
                txtBookID.Clear();
                txtReaderID.Clear();
                txtQuantity_Borrowed.Clear();
                LoadData();
            }
            catch {
                MessageBox.Show("vui lòng thử lại sau"); 
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "update borrows set bookID = '" + txtBookID.Text + "', readerID = '" + txtReaderID.Text + "', borrow_date = '" + dateBorrow.Value + "', due_date = '" + dateReturn.Value + "', quantity_borrowed = '" + txtQuantity_Borrowed.Text + "' where borrowID = '" + txtBorrowID.Text + "'";
                SqlCommand updateCommand = new SqlCommand(updateQuery, db.con);
                updateCommand.ExecuteNonQuery();
                txtBorrowID.Clear();
                txtBookID.Clear();
                txtReaderID.Clear();
                txtQuantity_Borrowed.Clear();
                LoadData();
            }
            catch {
                MessageBox.Show("lỗi dữ liệu");
            }
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBorrowID.Clear();
            txtBookID.Clear();
            txtReaderID.Clear();
            txtQuantity_Borrowed.Clear();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Mã phiếu")
            {
                string selectQ = "select * from borrows where borrowID = '" + txtTuKhoa.Text + "'";
                SqlCommand selectC = new SqlCommand(selectQ, db.con);
                selectC.ExecuteNonQuery();
                //LoadData();
            }
            if (comboBox1.Text == "Mã độc giả")
            {
                string selectQ = "select * from borrows where readerID = '" + txtTuKhoa.Text + "'";
                SqlCommand selectC = new SqlCommand(selectQ, db.con);
                selectC.ExecuteNonQuery();
                //LoadData();
            }
            if (comboBox1.Text == "Mã sách")
            {
                string selectQ = "select * from borrows where bookID = '" + txtTuKhoa.Text + "'";
                SqlCommand selectC = new SqlCommand(selectQ, db.con);
                selectC.ExecuteNonQuery();
                //LoadData();
            }
        }
    }
}
