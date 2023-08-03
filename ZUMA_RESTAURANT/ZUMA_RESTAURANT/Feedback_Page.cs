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

namespace ZUMA_RESTAURANT
{
    public partial class Feedback_Page : Form
    {
        //InitializeComponent();
        // private string text1;
        //private string text2;
        //private string v;
        //private string text3;
    
        public Feedback_Page()
        {
            InitializeComponent();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Zuma Restaurant;Integrated Security=True");
                if (txt_userid.Text != "" && txt_name.Text != "" && txt_emailid.Text != "" && txt_feedback.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_Userfeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@_User_Id", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_userid.Text;
                    SqlParameter param2 = new SqlParameter("@_Name", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_name.Text;
                    SqlParameter param3 = new SqlParameter("@Emailid", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_emailid.Text;
                    SqlParameter param4 = new SqlParameter("@About", SqlDbType.VarChar);
                    cmd.Parameters.Add(param4).Value = comboBox_about.Text;
                    SqlParameter param5 = new SqlParameter("@Feedback", SqlDbType.VarChar);
                    cmd.Parameters.Add(param5).Value = txt_feedback.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("FeedBack Send successfully");
                    else
                        MessageBox.Show("Data cannot be Sended");
                    con.Close();
                }

                else
                {
                    MessageBox.Show("Enter given Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Zuma Restaurant;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_send", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView_feedback.DataSource = ds.Tables[0];
            con.Close();
        }  

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_Page f = new Admin_Page();
            f.Show();
            Hide();
        }

        private void Feedback_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
