using System.Windows.Forms;

namespace MainForm
{
    partial class Timnguoidoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttnd = new System.Windows.Forms.TextBox();
            this.txtidnd = new System.Windows.Forms.TextBox();
            this.sdt = new System.Windows.Forms.TextBox();
            this.txtdc = new System.Windows.Forms.TextBox();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btntim = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsua = new System.Windows.Forms.Button();
            this.s_c = new System.Windows.Forms.Label();
            this.s_code = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 244);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(920, 138);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên người dùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID người dùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa chỉ";
            // 
            // txttnd
            // 
            this.txttnd.Location = new System.Drawing.Point(414, 46);
            this.txttnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttnd.Name = "txttnd";
            this.txttnd.Size = new System.Drawing.Size(331, 22);
            this.txttnd.TabIndex = 5;
            // 
            // txtidnd
            // 
            this.txtidnd.Location = new System.Drawing.Point(414, 74);
            this.txtidnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtidnd.Name = "txtidnd";
            this.txtidnd.Size = new System.Drawing.Size(331, 22);
            this.txtidnd.TabIndex = 6;
            // 
            // sdt
            // 
            this.sdt.Location = new System.Drawing.Point(414, 106);
            this.sdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(331, 22);
            this.sdt.TabIndex = 7;
            // 
            // txtdc
            // 
            this.txtdc.Location = new System.Drawing.Point(414, 136);
            this.txtdc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdc.Name = "txtdc";
            this.txtdc.Size = new System.Drawing.Size(331, 22);
            this.txtdc.TabIndex = 8;
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(49, 194);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(121, 32);
            this.btnxoa.TabIndex = 9;
            this.btnxoa.Text = "Xóa người đọc";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btntim
            // 
            this.btntim.Location = new System.Drawing.Point(554, 194);
            this.btntim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(113, 32);
            this.btntim.TabIndex = 10;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(766, 194);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(108, 32);
            this.btnthoat.TabIndex = 11;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(362, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 28);
            this.label6.TabIndex = 13;
            this.label6.Text = "TÌM NGƯỜI ĐỌC";
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(312, 194);
            this.btnsua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(113, 32);
            this.btnsua.TabIndex = 14;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // s_c
            // 
            this.s_c.AutoSize = true;
            this.s_c.Location = new System.Drawing.Point(194, 169);
            this.s_c.Name = "s_c";
            this.s_c.Size = new System.Drawing.Size(32, 16);
            this.s_c.TabIndex = 15;
            this.s_c.Text = "msv";
            // 
            // s_code
            // 
            this.s_code.Location = new System.Drawing.Point(414, 163);
            this.s_code.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.s_code.Name = "s_code";
            this.s_code.Size = new System.Drawing.Size(331, 22);
            this.s_code.TabIndex = 16;
            // 
            // Timnguoidoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(925, 383);
            this.Controls.Add(this.s_code);
            this.Controls.Add(this.s_c);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btntim);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.txtdc);
            this.Controls.Add(this.sdt);
            this.Controls.Add(this.txtidnd);
            this.Controls.Add(this.txttnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Timnguoidoc";
            this.Text = "Timnguoidoc";
            this.Load += new System.EventHandler(this.Timnguoidoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txttnd;
        private TextBox txtidnd;
        private TextBox sdt;
        private TextBox txtdc;
        private Button btnxoa;
        private Button btntim;
        private Button btnthoat;
        private Label label6;
        private Button btnsua;
        private Label s_c;
        private TextBox s_code;
    }
}