using MainForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Main : Form
    {
        private Borrowed_Manager qlm;
        private Returned_Manager qlt;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //comboBox1.Text = "Tên Sách";
            if (Save.Share_DbServices.type == "Admin")
            {
                //btn_MuonSach.Visible = true;
                //btn_QuanLyMuon.Visible = true;
                btnChangePass.Visible = true;
                button4.Visible = true;
                MN_QLSach.Visible = true;
                MN_QLNguoiDoc.Visible = true;
                MN_QLTK.Visible = true;
                MN_QLTK_DoiMK.Visible = true;
                MN_QLTK_DSTK.Visible = true;
                MN_QLTK_ThayDoiTT.Visible = true;
                MN_QLMuon.Visible = true;
                groupQuanly.Visible = true;
                tạoPhiếuMớiToolStripMenuItem.Visible = false;

            }
            else if (Save.Share_DbServices.type == "User")
            {
                //btn_MuonSach.Visible = true;
                // btn_QuanLyMuon.Visible = false;
                btnChangePass.Visible = true;
                button4.Visible = true;
                MN_QLSach.Visible = false;
                MN_QLNguoiDoc.Visible = false;
                MN_QLTK.Visible = true;
                MN_QLTK_DoiMK.Visible = true;
                MN_QLTK_ThayDoiTT.Visible = true;
                MN_QLTK_DSTK.Visible = false;
                MN_QLMuon.Visible = false;
                MN_QLMuon.Visible = false;
                groupQuanly.Visible = false;
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void MN_QLTK_DoiMK_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm.ChangePass dmk = new MainForm.ChangePass();
            dmk.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_MuonSach_Click(object sender, EventArgs e)
        {

        }

        private void MN_QLTK_DSTK_Click(object sender, EventArgs e)
        {
            MainForm.DanhSachTK dstk = new DanhSachTK();
            dstk.ShowDialog();
        }

        private void MN_QLMuon_Click(object sender, EventArgs e)
        {
            qlm = new Borrowed_Manager();
            qlm.TopLevel = false;
            qlm.Parent = this;

            qlm.Location = new Point(170, 110);
            qlm.Size = new Size(1000, 520);

            qlm.Show();

            groupBox4.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void phiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.UserBorrowBook ubrb = new MainForm.UserBorrowBook();
            ubrb.ShowDialog();
        }

        private void phiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.UserReturnBook userReturnBook = new MainForm.UserReturnBook();
            userReturnBook.ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            MainForm.ChangePass dmk = new MainForm.ChangePass();
            dmk.ShowDialog();
        }

        private void MN_QLTK_ThayDoiTT_Click(object sender, EventArgs e)
        {
            MainForm.Personal_Information personal_Information = new MainForm.Personal_Information();
            personal_Information.ShowDialog();
        }

        private void tHÊMSÁCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks aDDBOOK = new AddBooks();
            aDDBOOK.Show();
        }

        private void xEMSÁCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XEMSACH xEMSACH = new XEMSACH();
            xEMSACH.Show();
        }

        private void thêmNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timnguoidoc timnguoidoc = new Timnguoidoc();
            timnguoidoc.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MainForm.Personal_Information personal_Information = new MainForm.Personal_Information();
            personal_Information.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MainForm.DanhSachTK dstk = new DanhSachTK();
            dstk.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AddBooks addBooks = new AddBooks();
            addBooks.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            qlm = new Borrowed_Manager();
            qlm.TopLevel = false;
            qlm.Parent = this;

            qlm.Location = new Point(170, 110);
            qlm.Size = new Size(1000, 520);

            qlm.Show();

            groupBox4.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            qlt = new Returned_Manager();
            qlt.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserBorrowed userBorrowed = new UserBorrowed();
            userBorrowed.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UserReturned userReturned = new UserReturned();
            userReturned.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //qlt.Close();
            //qlm.Close();
            groupBox4.Show();
        }
    }
}
