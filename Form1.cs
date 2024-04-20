using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace _ADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SqlCmdSelectPrds = new SqlCommand("SELECT * FROM Product WHERE id>10", SqlCN);
            DAPrds = new SqlDataAdapter(SqlCmdSelectPrds);
            DTPrds = new DataTable();

            SqlCmdSelectSup = new SqlCommand("SELECT [Id] as SID , CompanyName  FROM Supplier", SqlCN);
            DASup = new SqlDataAdapter(SqlCmdSelectSup);
            DTSup = new DataTable();
        }

        SqlConnection SqlCN = new SqlConnection("Data Source=.;Initial Catalog=NorthWind2021;Integrated Security=True");
        SqlCommand SqlCmdSelectPrds;
        SqlCommand SqlCmdSelectSup;

        SqlDataAdapter DAPrds;
        SqlDataAdapter DASup;
        DataTable DTPrds;
        DataTable DTSup;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            DAPrds.Fill(DTPrds);
            dataGridView1.DataSource = DTPrds;

            dataGridView1.Columns["id"].ReadOnly = true;
            dataGridView1.Columns["SupplierID"].Visible = false;
            DASup.Fill(DTSup);

           DataGridViewComboBoxColumn DC = new DataGridViewComboBoxColumn();
            DC.HeaderText = "SUPPLIER";
            DC.DataSource = DTSup;
            DC.DisplayMember = "CompanyName";
            DC.ValueMember = "SID";
            DC.DataPropertyName = "SupplierID"; // column name in the datatable


            dataGridView1.Columns.Add(DC);
           
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            //SqlDA.Update(DT);
            foreach (DataRow row in DTPrds.Rows)
            {
                Debug.WriteLine(row.RowState);
            }
        }
    }
}
