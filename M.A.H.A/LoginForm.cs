using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace M.A.H.A
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MAHA_DataSet"].ToString());


        private void RoleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;
            string role = RoleBox.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please enter username, password, and select a role.");
                return;
            }

            string query = "SELECT COUNT(*) FROM Account AS A INNER JOIN Employee AS E ON A.Username = E.Username " +
                "WHERE A.Username = @Username AND A.Password = @Password AND E.Role = @Role";


            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    switch (role)
                    {
                        case "Administrator":
                            AdminView adminViewForm = new AdminView();
                            this.Hide();
                            adminViewForm.Show();
                            break;
                        case "Accountant":
                           
                            break;
                        case "Doctor":
                            
                            break;
                        case "Nurse":
                            
                            break;
                        case "Receptionist":
                           
                            break;
                        default:
                            MessageBox.Show("Invalid role selected.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username, password, or role.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
