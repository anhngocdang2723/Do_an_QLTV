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
    public partial class AddBooks : Form
    {
        dbms sql = new dbms();
        public AddBooks()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            using (linqDataContext dt = new linqDataContext())
            {
                try
                {
                    Book qlbook = new Book();

                    qlbook.bookID = int.Parse(idb.Text);
                    qlbook.name = nameb.Text;
                    qlbook.title = titleb.Text;
                    qlbook.author = tacgiab.Text;
                    qlbook.year_published = int.Parse(namb.Text);
                    qlbook.quantity = int.Parse(slb.Text);

                    dt.Books.InsertOnSubmit(qlbook);

                    dt.SubmitChanges();
                    MessageBox.Show("dữ liệu đã được nhập", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*string bname = nameb.Text;
                int id=int.Parse(idb.Text) ;
                string bwriter = tacgiab.Text;
                string btype = titleb.Text;
                int bdate = int.Parse(namb.Text);
                int bsl = int.Parse(slb.Text);
                try
                {
                    if (sql.cn == null)
                    {
                        sql.cn = new SqlConnection(sql.str);
                    }
                    if (sql.cn.State == ConnectionState.Closed)
                    {
                       
                        sql.cn.Open();
                        sql.insert(id,bname, bwriter,btype,bdate,bsl);
                        sql.cn.Close();
                    }


                    MessageBox.Show("dữ liệu đã được nhập", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
