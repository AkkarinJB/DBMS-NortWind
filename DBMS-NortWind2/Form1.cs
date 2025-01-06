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
            txtShipperID.Text = dgvShippers.CurrentRow.Cells[0].Value.ToString();
            txtCompanyName.Text = dgvShippers.CurrentRow.Cells[1].Value.ToString();
            txtPhone.Text = dgvShippers.CurrentRow.Cells[2].Value.ToString();

        }
        private void cleanForm() //��ҧ�����
        {
            txtShipperID.Clear();
            txtCompanyName.Clear();
            txtPhone.Clear();
            txtCompanyName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                MessageBox.Show("�ô��͡���ͺ���ѷ", "�Դ��ͼԴ��Ҵ");
                return;
            }
            string sql = "Insert into shippers"
                + " Values(@companyName ,@phone)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Companyname", txtCompanyName.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                showdata();
                cleanForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtShipperID.Text))
            {
                MessageBox.Show("�ô���͡�����ŷ��ж١��Ѻ��ا����", "�Դ��ͼԴ��Ҵ");
                return;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                MessageBox.Show("�ô��͡���ͺ���ѷ", "�Դ��ͼԴ��Ҵ");
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
            if (n > 0)
            {
                showdata();
                cleanForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //��Ǩ�ͺ��������ѹ
            if(MessageBox.Show("��ͧ���ź�����Ūش����������", "Confirm?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (string.IsNullOrEmpty(txtShipperID.Text))
            {
                MessageBox.Show("�ô���͡�����ŷ���ź", "�Դ��ͼԴ��Ҵ");
                return;
            }

            string sql = "Delete from Shippers"
                + " Where ShipperID = @shipperID";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ShipperID", txtShipperID.Text);
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    showdata();
                    cleanForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�Դ��ͼԴ��Ҵ" + Environment.NewLine + ex.Message, "Error!!");
            }
        }
    }
}