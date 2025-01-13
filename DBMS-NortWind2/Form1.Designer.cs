namespace DBMS_NortWind2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvShippers = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btninsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtShipperID = new TextBox();
            txtCompanyName = new TextBox();
            txtPhone = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvShippers).BeginInit();
            SuspendLayout();
            // 
            // dgvShippers
            // 
            dgvShippers.AllowUserToAddRows = false;
            dgvShippers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShippers.Location = new Point(12, 12);
            dgvShippers.Name = "dgvShippers";
            dgvShippers.ReadOnly = true;
            dgvShippers.Size = new Size(776, 263);
            dgvShippers.TabIndex = 0;
            dgvShippers.CellContentClick += dataGridView1_CellContentClick;
            dgvShippers.CellDoubleClick += dgvShippers_CellDoubleClick;
            dgvShippers.CellMouseUp += dataGridView1_CellMouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 301);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "รหัสบริษัทขนส่ง";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 338);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 2;
            label2.Text = "ชื่อบริษัท";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 371);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 3;
            label3.Text = "โทรศัพท์";
            label3.Visible = false;
            label3.Click += label3_Click;
            // 
            // btninsert
            // 
            btninsert.BackColor = Color.FromArgb(0, 192, 0);
            btninsert.ForeColor = Color.Black;
            btninsert.Location = new Point(250, 415);
            btninsert.Name = "btninsert";
            btninsert.Size = new Size(75, 23);
            btninsert.TabIndex = 4;
            btninsert.Text = "เพิ่ม";
            btninsert.UseVisualStyleBackColor = false;
            btninsert.Click += btninsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 128, 0);
            btnUpdate.Location = new Point(368, 415);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "ปรับปรุง";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Location = new Point(485, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtShipperID
            // 
            txtShipperID.Location = new Point(103, 298);
            txtShipperID.Name = "txtShipperID";
            txtShipperID.Size = new Size(360, 23);
            txtShipperID.TabIndex = 8;
            txtShipperID.Visible = false;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(103, 338);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(360, 23);
            txtCompanyName.TabIndex = 9;
            txtCompanyName.Visible = false;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(103, 371);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 23);
            txtPhone.TabIndex = 10;
            txtPhone.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPhone);
            Controls.Add(txtCompanyName);
            Controls.Add(txtShipperID);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btninsert);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvShippers);
            Name = "Form1";
            Text = "ระบบจัดการข้อมูลบริษัทขนส่ง(shippers)";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvShippers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvShippers;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btninsert;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtShipperID;
        private TextBox txtCompanyName;
        private TextBox txtPhone;
    }
}
