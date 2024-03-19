using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M.A.H.A
{
    public partial class CreateAccounts : Form
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MAHA_DataSet"].ToString();
        public CreateAccounts()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }
        private void InitializeComboBoxes()
        {

            for (int i = 1; i <= 8; i++)
            {
                DepCode_comboBox.Items.Add(i);
            }

            Role_comboBox.Items.AddRange(new string[] { "Administrator", 
                "Receptionist", "Doctor", "Nurse", "Accountant" });
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateAccounts_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Name_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void SSN_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Nationality_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNb_box_TextChanged(object sender, EventArgs e)
        {

        }

        private String validateInputs()
        {
            String message = "";
            try
            {
                string Name = Name_box.Text;
                int SSN = int.Parse(SSN_box.Text);
                DateTime BirthDate = DateOfBirthPicker.Value;
                string Nationality = Nationality_box.Text;
                int PhoneNumber = int.Parse(PhoneNb_box.Text);
                string Email = Email_box.Text;
                string Address = Address_box.Text;
                string Password = Password_box.Text;
                int ID = int.Parse(ID_box.Text);
                string Username = Username_box.Text;
                string Role = Role_comboBox.Text;
                int Code = int.Parse(DepCode_comboBox.Text);
                double Salary = double.Parse(Salary_box.Text);

                string Specialization = Specialization_box.Text;
                int YearsOfExperience = int.Parse(YrsExp_box.Text);
                if (!int.TryParse(SSN_box.Text, out SSN))
                {
                    message = "Invalid SSN. Please enter a valid integer.";
                }

                if (!int.TryParse(PhoneNb_box.Text, out PhoneNumber))
                {
                    message = "Invalid phone number. Please enter a valid integer.";
                }

                if (!int.TryParse(ID_box.Text, out ID))
                {
                    message = "Invalid ID. Please enter a valid integer.";
                }
                if (!int.TryParse(DepCode_comboBox.Text, out Code))
                {
                    message = "Invalid department code. Please enter a valid integer.";
            
                }
                if (!double.TryParse(Salary_box.Text, out Salary))
                {
                    message = "Invalid salary";
                }
                if (!int.TryParse(YrsExp_box.Text, out YearsOfExperience))
                {
                        message = "Invalid years of experience";                }

                if (Role == "Receptionist" && Code != 2)
                {
                        message = "A Receptionist can only be assigned to Department Code 2";
                }
                else if ((Role == "Doctor" || Role == "Nurse") && (Code < 4 || Code > 8))
                {
                        message = "A Doctor or Nurse can only be assigned to Department Codes 4 to 8.";
                }
                else if (Role == "Accountant" && Code != 3)
                {
                        message = "An Accountant can only be assigned to Department Code 3.";
                }
                    return message;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        private void Create_btn_Click(object sender, EventArgs e)
        {
            String isValidated = validateInputs();
            if(isValidated != "")
            {
                MessageBox.Show(isValidated, "Error!");
                return;
            }

            string Name = Name_box.Text;
            int SSN = int.Parse(SSN_box.Text);
            DateTime BirthDate = DateOfBirthPicker.Value;
            string Nationality = Nationality_box.Text;
            int PhoneNumber = int.Parse(PhoneNb_box.Text);
            string Email = Email_box.Text;
            string Address = Address_box.Text;
            string Password = Password_box.Text;
            int ID = int.Parse(ID_box.Text);
            string Username = Username_box.Text;
            string Role = Role_comboBox.Text;
            int Code = int.Parse(DepCode_comboBox.Text);
            double Salary = double.Parse(Salary_box.Text);
            string Specialization = Specialization_box.Text;
            int YearsOfExperience = int.Parse(YrsExp_box.Text);
            //this is a comment
            string query = @"BEGIN TRANSACTION;
                 INSERT INTO Employee (Name, SSN, BirthDate, Nationality, 
                                      PhoneNumber, Email, Address, 
                                      ID, Username, Role, Code, Salary, 
                                      Specialization, YearsOfExperience) 
                 VALUES (@Name, @SSN, @DateOfBirth, @Nationality, 
                         @PhoneNumber, @Email, @Address, 
                         @ID, @Username, @Role, @Code, @Salary,
                         @Specialization, @YearsOfExperience);
                 INSERT INTO Account (Username, Password) 
                 VALUES (@Username, @Password);
                 COMMIT;";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@SSN", SSN);
                command.Parameters.AddWithValue("@DateOfBirth", BirthDate);
                command.Parameters.AddWithValue("@Nationality", Nationality);
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Role", Role);
                command.Parameters.AddWithValue("@Code", Code);
                command.Parameters.AddWithValue("@Salary", Salary);
                command.Parameters.AddWithValue("@Specialization", Specialization);
                command.Parameters.AddWithValue("@YearsOfExperience", YearsOfExperience);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee added successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error adding employee. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            AdminView adminViewForm = new AdminView();
            adminViewForm.Show();
            this.Close();
        }

        private void Info_grpBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
