using System.Data;
using DBMS_Nortwind;
using Microsoft.Data.SqlClient;

namespace DBMS_NortWind2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        //ประกาศตัวเเปรเพิ่ม
        int shipperID = 0;
        string companyName = string.Empty;
        string phone = string.Empty;



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectNortWind();
            showdata();
        }

        private void showdata()
        {
            string sql = "Select * from Shippers";
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvShippers.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            shipperID = Convert.ToInt32(dgvShippers.CurrentRow.Cells[0].Value);
            companyName = dgvShippers.CurrentRow.Cells[1].Value.ToString();
            phone = dgvShippers.CurrentRow.Cells[2].Value.ToString();

            //txtShipperID.Text = dgvShippers.CurrentRow.Cells[0].Value.ToString();
            //txtCompanyName.Text = dgvShippers.CurrentRow.Cells[1].Value.ToString();
            //txtPhone.Text = dgvShippers.CurrentRow.Cells[2].Value.ToString();

        }
        private void cleanForm() //ล้างฟอร์ม
        {
            //txtShipperID.Clear();
            //txtCompanyName.Clear();
            //txtPhone.Clear();
            //txtCompanyName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            //เพิ่มใหม่
            frmShippers f = new frmShippers();
            f.Status = "insert";
            f.ShowDialog();
            showdata();


            //if (string.IsNullOrEmpty(txtCompanyName.Text))
            //{
            //    MessageBox.Show("โปรดกรอกชื่อบริษัท", "เกิดข้อผิดพลาด");
            //    return;
            //}
            //string sql = "Insert into shippers"
            //    + " Values(@companyName ,@phone)";
            //cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@Companyname", txtCompanyName.Text.Trim());
            //cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            //int n = cmd.ExecuteNonQuery();
            //if (n > 0)
            //{
            //    showdata();
            //    cleanForm();
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //ปรับปรุง
            if (shipperID <= 0)
            {
                MessageBox.Show("โปดรเลือกข้อมูลที่จะเเก้ไข");
                return;
            }

            frmShippers f = new frmShippers();
            f.Status = "update";
            f.ShipperID = shipperID;
            f.CompanyName = companyName;
            f.Phone = phone;
            f.ShowDialog();
            showdata();
            //if (string.IsNullOrEmpty(txtShipperID.Text))
            //{
            //    MessageBox.Show("โปรดเลือกข้อมูลที่จะถูกปรับปรุงเเก้ไข", "เกิดข้อผิดพลาด");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtCompanyName.Text))
            //{
            //    MessageBox.Show("โปรดกรอกชื่อบริษัท", "เกิดข้อผิดพลาด");
            //    return;
            //}
            //string sql = "Update Shippers"
            //    + " set CompanyName = @companyName,Phone = @phone"
            //    + " Where ShipperID = @shipperID";
            //cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@Companyname", txtCompanyName.Text.Trim());
            //cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            //cmd.Parameters.AddWithValue("@ShipperID", txtShipperID.Text);
            //int n = cmd.ExecuteNonQuery();
            //if (n > 0)
            //{
            //    showdata();
            //    cleanForm();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ตรวจสอบความยืยยัน
            string msg = "รหัส :" + shipperID.ToString() + Environment.NewLine;
            msg += "บริษัท :" + companyName;
            msg += "โทร :" + phone;
            if (MessageBox.Show("ต้องการลบข้อมูลชุดนี้หรือไม่", "Confirm?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (shipperID <= 0)
            {
                MessageBox.Show("โปรดเลือกข้อมูลที่จะลบ", "เกิดข้อผิดพลาด");
                return;
            }

            string sql = "Delete from Shippers"
                + " Where ShipperID = @shipperID";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ShipperID", shipperID);
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    showdata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด" + Environment.NewLine + ex.Message, "Error!!");
            }
        }

        private void dgvShippers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.PerformClick();
        }
    }
}
