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
    public partial class DanhSachTK : Form
    {
        public DanhSachTK()
        {
            InitializeComponent();
        }

        Save.Share_DbServices db = new Save.Share_DbServices();
        public void LoadData()
        {
            try
            {
                string SelectQuery = "Select R.rname as N'Tên người dùng',Acc.username as N'Tài khoản',Acc.password as N'Mật khẩu', R.address as N'Địa chỉ', R.student_code as N'Mã sinh viên', R.phone_num as N'Số điện thoại' \n\r From Readers R \n\r Join Accounts Acc On Acc.readerID = R.readerID";
                SqlCommand command = new SqlCommand(SelectQuery, db.con);
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

        private void DanhSachTK_Load(object sender, EventArgs e)
        {
            db.con.Open();
            LoadData();
        }
    }
}
