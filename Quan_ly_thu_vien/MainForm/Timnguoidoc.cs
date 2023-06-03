using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MainForm
{
    public partial class Timnguoidoc : Form
    {
        private string constr = "Data Source=MAYTINH\\SQLEXPRESS;Initial Catalog=Quan_ly_thu_vien;Integrated Security=True";
        private SqlConnection connec;
        private SqlDataAdapter dataadapter=new SqlDataAdapter();
        private DataTable dtQLND=new DataTable();
        //khai báo đối tượng truy vấn và cập nhật dữ liệu
        private SqlCommand mySqlCommand;
        //khai báo đối tượng kết nối CSDL
        //linq
        linqDataContext db=new linqDataContext();
        public Timnguoidoc()
        {
            InitializeComponent();
        }



        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txttnd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtidnd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtdc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            s_code.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Reader b = db.Readers.FirstOrDefault(p => p.readerID.Equals(int.Parse(txtidnd.Text)));
            b.name = txttnd.Text;
            b.phone_num = int.Parse(sdt.Text);
            b.address = txtdc.Text;
            b.student_code=int.Parse(s_code.Text);
            db.SubmitChanges();

            dataGridView1.DataSource = db.Readers.Select(p => p);
            /*int id = int.Parse(txtidnd.Text);
            string name = txttnd.Text;
            string dc = txtdc.Text;
            int sdt = int.Parse(txtsdt.Text);

            if (connec == null)
            {
                connec = new SqlConnection(constr);
            }
            if (connec.State == ConnectionState.Closed)
            {

                connec.Open();
                mySqlCommand = connec.CreateCommand();
                string update = "update Readers set name=@name,address=@dc,phone_num=@sdt where readerID=@id";
                mySqlCommand.Parameters.AddWithValue("@id", id);
                mySqlCommand.Parameters.AddWithValue("@name", name);
                mySqlCommand.Parameters.AddWithValue("@dc", dc);
                mySqlCommand.Parameters.AddWithValue("@sdt", sdt);
                mySqlCommand.CommandText = update;
                mySqlCommand.ExecuteNonQuery();
                connec.Close();
                MessageBox.Show("dữ liệu đã được sửa", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void Timnguoidoc_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.Readers.Select(p => p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*connec = new SqlConnection(constr);
            connec.Open();
            dataGridView1.DataSource = getData();
            connec.Close();*/
        }
        public DataTable getData()
        {
            try
            {
                mySqlCommand = connec.CreateCommand();
                mySqlCommand.CommandText = "select * from Readers";
                dataadapter.SelectCommand = mySqlCommand;

                dtQLND.Clear();
                dataadapter.Fill(dtQLND);
                return dtQLND;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            try
            {
                Reader b = db.Readers.FirstOrDefault(p => p.readerID.Equals(dataGridView1.CurrentRow.Cells[0].Value));
                db.Readers.DeleteOnSubmit(b);
                db.SubmitChanges();
                dataGridView1.DataSource = db.Readers.Select(p => p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*int id = int.Parse(txtidnd.Text);
         

            if (connec == null)
            {
                connec = new SqlConnection(constr);
            }
            if (connec.State == ConnectionState.Closed)
            {

                connec.Open();
                mySqlCommand = connec.CreateCommand();
                string update = "delete Readers where readerID=@id";
                mySqlCommand.Parameters.AddWithValue("@id", id);

                mySqlCommand.CommandText = update;
                mySqlCommand.ExecuteNonQuery();
                connec.Close();
                MessageBox.Show("dữ liệu đã được sửa", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txttnd.Text;
                dataGridView1.DataSource = from u in db.Readers
                                           where u.name == name
                                           select u;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    } 

 }
