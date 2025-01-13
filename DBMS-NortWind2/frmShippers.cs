using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DBMS_Nortwind;
using Microsoft.Data.SqlClient;

namespace DBMS_NortWind2
{
    public partial class frmShippers : Form
    {
        public frmShippers()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public string Status { get; set; }
        private void frmShippers_Load(object sender, EventArgs e)
        {
           
            txtShipperID.Text = ShipperID.ToString();
            txtCompanyName.Text = CompanyName;
            txtPhone.Text = Phone;
            txtCompanyName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn = connectDB.ConnectNortWind();
            if (Status == "insert")
            {
                insertShippers();
            }
            else if(Status == "update")
             {
                UpdateShipper();
            }
            this.Close();
        }

        private void UpdateShipper()
        {
            MessageBox.Show("ปรับปรุงข้อมูล");
            if (string.IsNullOrEmpty(txtShipperID.Text))
            {
                MessageBox.Show("โปรดเลือกข้อมูลที่จะถูกปรับปรุงเเก้ไข", "เกิดข้อผิดพลาด");
                return;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                MessageBox.Show("โปรดกรอกชื่อบริษัท", "เกิดข้อผิดพลาด");
                return;
            }
            string sql = "Update Shippers"
                + " set CompanyName = @companyName,Phone = @phone"
                + " Where ShipperID = @shipperID";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Companyname", txtCompanyName.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@ShipperID", txtShipperID.Text);
            int n = cmd.ExecuteNonQuery();
        }

        private void insertShippers()
        {
            MessageBox.Show("เพิ่มข้อมูล");
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                MessageBox.Show("โปรดกรอกชื่อบริษัท", "เกิดข้อผิดพลาด");
                return;
            }
            string sql = "Insert into shippers"
                + " Values(@companyName ,@phone)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Companyname", txtCompanyName.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            int n = cmd.ExecuteNonQuery();
        }
    }
}
