using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Menu_Form
{
    internal class dbms
    {
        public string str = @"Data Source=DESKTOP-Q69S8H6;Initial Catalog=Quan_ly_thu_vien;Integrated Security=True";
        public SqlConnection cn;
        public SqlCommand cmd;
        public SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public dbms()
        {
            cn = new SqlConnection(str);
        }
        public DataTable getData()
        {
            try
            {
                cmd = cn.CreateCommand();
                cmd.CommandText = "select * from Books";
                adapter.SelectCommand = cmd;

                table.Clear();
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public DataTable getDatawithvalue(string value)
        {
            try
            {
                cmd = cn.CreateCommand();
                cmd.CommandText = "select * from Books where name=@ten";
                cmd.Parameters.AddWithValue("@ten", value);

                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public void insert(int id,string ten,  string tgia, string tt, int ngayph, int gia)
        {
            try
            {
                cmd = cn.CreateCommand();
                //parameter
                string insert = "insert into Books values (@id,@name,@title,@writer,@date,@sl)";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", ten);
                cmd.Parameters.AddWithValue("@writer", tgia);
                cmd.Parameters.AddWithValue("@title", tt);
                cmd.Parameters.AddWithValue("@date", ngayph);
                cmd.Parameters.AddWithValue("@sl", gia);
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        public void update(int id, string ten, string title, string tgia, int nam, int sl)
        {
            try
            {
                string update = "update Books set name=@name,title=@title,author=@writer,year_published=@year,quantity=@sl where bookID=@id";
                cmd = new SqlCommand(update, cn);
                //parameter
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", ten);
                cmd.Parameters.AddWithValue("@title",title);
                cmd.Parameters.AddWithValue("@writer", tgia);
                cmd.Parameters.AddWithValue("@year",nam);
                cmd.Parameters.AddWithValue("@sl",sl);
                //thực thi
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        public void delete(int id)
        {
            try
            {
                cmd = new SqlCommand("delete Books where bookID=@id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
