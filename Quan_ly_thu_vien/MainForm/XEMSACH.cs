using Menu_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class XEMSACH : Form
    {
        dbms sql = new dbms();
        //SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        //linq
        linqDataContext dt = new linqDataContext();
        public XEMSACH()
        {
            InitializeComponent();
        }

        private void XEMSACH_Load_1(object sender, EventArgs e)
        {
            //linqDataContext dt = new linqDataContext();
            try
            {
                dataGridView2.DataSource = dt.Books.Select(p => p);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*try
            {
                sql.cn.Open();
                dataGridView2.DataSource = sql.getData();
                sql.cn.Close();
                MessageBox.Show("khi cập nhật hoặc xóa cần lưu ý như sau:\n" +
                    "+cập nhật cần phải có nhập ID rồi sẽ sửa nội dung \n+xóa chỉ cần ID là đủ", "inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        //xem toàn bộ sách
        void loaddata2()
        {

            try
            {
                /*sql.cmd = sql.cn.CreateCommand();
                sql.cmd.CommandText = "select * from Qlbook";
                sql.adapter.SelectCommand = sql.cmd;

                table.Clear();
                sql.adapter.Fill(table);*/

                dataGridView2.DataSource = sql.getData();

            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //xem sách theo tên
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string find = findb.Text;
                dataGridView2.DataSource = from u in dt.Books
                                           where u.name == find
                                           select u;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*try
            {
                sql.cn.Open();
                loaddata1();
                sql.cn.Close();
            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }
        void loaddata1()
        {
            dataGridView2.DataSource = dt.Books.Select(p => p);
            /*try
            {
                string ten = findb.Text;
                dataGridView2.DataSource = sql.getDatawithvalue(ten);
            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

        }

        //quay lại xem toàn bộ sách
        private void backb_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = dt.Books.Select(p => p);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*try
            {
                sql.cn.Open();
                dataGridView2.DataSource = sql.getData();
                sql.cn.Close();
            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        

        //cập nhật
        
        private void update_Click(object sender, EventArgs e)
        {
            Book b = dt.Books.FirstOrDefault(p => p.bookID.Equals(idb.Text));
            b.name = nameb.Text;
            b.title = titleb.Text;
            b.author = tacgiab.Text;
            b.year_published = int.Parse(namb.Text);
            b.quantity = int.Parse(slb.Text);

            dt.SubmitChanges();

            dataGridView2.DataSource = dt.Books.Select(p => p);
            /*try
            {
                if (idb.Text == "")
                {
                    MessageBox.Show("trước khi cập nhật bạn phải chắc chắn là đã nhập ID cần cập nhật", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    int id = int.Parse(idb.Text);
                    string name = nameb.Text;
                    string title = titleb.Text;
                    string tg=tacgiab.Text;
                    int nam = int.Parse(namb.Text);
                    int sl=int.Parse(slb.Text);


                    sql.cn.Open();
                    sql.update(id, name, title,tg,nam,sl);
                    sql.getData();
                    sql.cn.Close();

                    MessageBox.Show("dữ liệu đã được cập nhật", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        //xóa
        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                Book b = dt.Books.FirstOrDefault(p => p.bookID.Equals(dataGridView2.CurrentRow.Cells[0].Value));
                dt.Books.DeleteOnSubmit(b);
                dt.SubmitChanges();
                dataGridView2.DataSource = dt.Books.Select(p => p);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*try
            {
                if (idb.Text == "")
                {
                    MessageBox.Show("trước khi xóa bạn phải chắc chắn là đã nhập ID cần xóa", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int id = int.Parse(idb.Text);
                    sql.cn.Open();
                    sql.delete(id);
                    sql.getData();
                    sql.cn.Close();

                    MessageBox.Show("dữ liệu đã được xóa", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ox)
            {
                MessageBox.Show(ox.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idb.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            idb.Enabled = false;
            nameb.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            titleb.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            tacgiab.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            namb.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            slb.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
