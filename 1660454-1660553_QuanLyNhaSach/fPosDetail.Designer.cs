
namespace _1660454_1660553_QuanLyNhaSach
{
    partial class fPosDetail
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hienCTdonhang = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenhh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lsex = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtdiem = new System.Windows.Forms.TextBox();
            this.laddress = new System.Windows.Forms.Label();
            this.lemailKH = new System.Windows.Forms.Label();
            this.ltenKH = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Panel();
            this.txtthanhtien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.discountpos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tongtienpos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hienCTdonhang)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel3.SuspendLayout();
            this.lab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.txtso);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.hienCTdonhang);
            this.panel8.Location = new System.Drawing.Point(12, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(820, 545);
            this.panel8.TabIndex = 4;
            // 
            // txtso
            // 
            this.txtso.AutoSize = true;
            this.txtso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtso.Location = new System.Drawing.Point(260, 19);
            this.txtso.Name = "txtso";
            this.txtso.Size = new System.Drawing.Size(0, 29);
            this.txtso.TabIndex = 5;
            this.txtso.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phiếu đơn hàng bán:";
            this.label2.UseMnemonic = false;
            // 
            // hienCTdonhang
            // 
            this.hienCTdonhang.AllowUserToAddRows = false;
            this.hienCTdonhang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hienCTdonhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hienCTdonhang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.image,
            this.id_item,
            this.tenhh,
            this.sl,
            this.Gia});
            this.hienCTdonhang.Location = new System.Drawing.Point(0, 91);
            this.hienCTdonhang.Name = "hienCTdonhang";
            this.hienCTdonhang.RowHeadersWidth = 30;
            this.hienCTdonhang.RowTemplate.Height = 60;
            this.hienCTdonhang.Size = new System.Drawing.Size(817, 445);
            this.hienCTdonhang.TabIndex = 3;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID ĐƠN HÀNG";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 155;
            // 
            // image
            // 
            this.image.DataPropertyName = "avatar";
            this.image.FillWeight = 50F;
            this.image.HeaderText = "Hình Ảnh";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.image.MinimumWidth = 6;
            this.image.Name = "image";
            this.image.Width = 80;
            // 
            // id_item
            // 
            this.id_item.DataPropertyName = "id_items";
            this.id_item.HeaderText = "Mã Hàng Hóa";
            this.id_item.MinimumWidth = 6;
            this.id_item.Name = "id_item";
            this.id_item.Width = 150;
            // 
            // tenhh
            // 
            this.tenhh.DataPropertyName = "name";
            this.tenhh.HeaderText = "Tên Hàng Hóa";
            this.tenhh.MinimumWidth = 6;
            this.tenhh.Name = "tenhh";
            this.tenhh.Width = 155;
            // 
            // sl
            // 
            this.sl.DataPropertyName = "quanliti";
            this.sl.HeaderText = "Số Lượng";
            this.sl.MinimumWidth = 6;
            this.sl.Name = "sl";
            this.sl.Width = 155;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "price";
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.Width = 155;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel10.Controls.Add(this.lsex);
            this.panel10.Controls.Add(this.label17);
            this.panel10.Controls.Add(this.txtdiem);
            this.panel10.Controls.Add(this.laddress);
            this.panel10.Controls.Add(this.lemailKH);
            this.panel10.Controls.Add(this.ltenKH);
            this.panel10.Controls.Add(this.label16);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Controls.Add(this.label14);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Location = new System.Drawing.Point(842, 170);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(410, 246);
            this.panel10.TabIndex = 21;
            // 
            // lsex
            // 
            this.lsex.AutoSize = true;
            this.lsex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsex.Location = new System.Drawing.Point(112, 130);
            this.lsex.Name = "lsex";
            this.lsex.Size = new System.Drawing.Size(0, 20);
            this.lsex.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "Giới tính";
            // 
            // txtdiem
            // 
            this.txtdiem.Location = new System.Drawing.Point(116, 167);
            this.txtdiem.Name = "txtdiem";
            this.txtdiem.ReadOnly = true;
            this.txtdiem.Size = new System.Drawing.Size(100, 22);
            this.txtdiem.TabIndex = 7;
            // 
            // laddress
            // 
            this.laddress.AutoSize = true;
            this.laddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laddress.Location = new System.Drawing.Point(112, 89);
            this.laddress.Name = "laddress";
            this.laddress.Size = new System.Drawing.Size(0, 20);
            this.laddress.TabIndex = 6;
            // 
            // lemailKH
            // 
            this.lemailKH.AutoSize = true;
            this.lemailKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lemailKH.Location = new System.Drawing.Point(112, 53);
            this.lemailKH.Name = "lemailKH";
            this.lemailKH.Size = new System.Drawing.Size(0, 20);
            this.lemailKH.TabIndex = 5;
            // 
            // ltenKH
            // 
            this.ltenKH.AutoSize = true;
            this.ltenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltenKH.Location = new System.Drawing.Point(112, 20);
            this.ltenKH.Name = "ltenKH";
            this.ltenKH.Size = new System.Drawing.Size(0, 20);
            this.ltenKH.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 167);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "Điểm:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Địa chỉ:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Email:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tên Khách:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.lab);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(838, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 53);
            this.panel3.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(371, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 17);
            this.label19.TabIndex = 6;
            this.label19.Text = "VNĐ";
            // 
            // lab
            // 
            this.lab.Controls.Add(this.txtthanhtien);
            this.lab.Location = new System.Drawing.Point(119, 18);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(246, 20);
            this.lab.TabIndex = 7;
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.AutoSize = true;
            this.txtthanhtien.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtthanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtthanhtien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtthanhtien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtthanhtien.Location = new System.Drawing.Point(229, 0);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtthanhtien.Size = new System.Drawing.Size(17, 18);
            this.txtthanhtien.TabIndex = 3;
            this.txtthanhtien.Text = "0";
            this.txtthanhtien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(14, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thành tiền";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(838, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 93);
            this.panel2.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(363, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "VNĐ";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.discountpos);
            this.panel11.Location = new System.Drawing.Point(203, 56);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(154, 20);
            this.panel11.TabIndex = 7;
            // 
            // discountpos
            // 
            this.discountpos.AutoSize = true;
            this.discountpos.Dock = System.Windows.Forms.DockStyle.Right;
            this.discountpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountpos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.discountpos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.discountpos.Location = new System.Drawing.Point(137, 0);
            this.discountpos.Name = "discountpos";
            this.discountpos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.discountpos.Size = new System.Drawing.Size(17, 18);
            this.discountpos.TabIndex = 3;
            this.discountpos.Text = "0";
            this.discountpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(376, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "VNĐ";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tongtienpos);
            this.panel9.Location = new System.Drawing.Point(133, 13);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(237, 20);
            this.panel9.TabIndex = 5;
            // 
            // tongtienpos
            // 
            this.tongtienpos.AutoSize = true;
            this.tongtienpos.Dock = System.Windows.Forms.DockStyle.Right;
            this.tongtienpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tongtienpos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tongtienpos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tongtienpos.Location = new System.Drawing.Point(220, 0);
            this.tongtienpos.Name = "tongtienpos";
            this.tongtienpos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tongtienpos.Size = new System.Drawing.Size(17, 18);
            this.tongtienpos.TabIndex = 3;
            this.tongtienpos.Text = "0";
            this.tongtienpos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chiếu khấu hóa đơn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng cộng:";
            // 
            // fPosDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 569);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel8);
            this.Name = "fPosDetail";
            this.Text = "fPosDetail";
            this.Load += new System.EventHandler(this.fPosDetail_Load);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hienCTdonhang)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.lab.ResumeLayout(false);
            this.lab.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label txtso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView hienCTdonhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenhh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lsex;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtdiem;
        private System.Windows.Forms.Label laddress;
        private System.Windows.Forms.Label lemailKH;
        private System.Windows.Forms.Label ltenKH;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel lab;
        private System.Windows.Forms.Label txtthanhtien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label discountpos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label tongtienpos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}