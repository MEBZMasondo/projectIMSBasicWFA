using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectIMSBasicWFA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                String tableName = "Login";
                String queryWHERE = "username = '" + userNameTextBox.Text + "' AND password = '" + passwordMaskedTextBox.Text + "'";
                DBConnect db = new DBConnect(tableName, queryWHERE);
                DataSet ds = new DataSet();
                db.DA.Fill(ds, "Login");
                DataTable dt = ds.Tables["Login"];

                if (dt.Rows.Count > 0)
                {
                    IMSMainForm IMSForm = new IMSMainForm();
                    IMSForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearEntries();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Login", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearEntries();
        }

        public void clearEntries()
        {
            userNameTextBox.Clear();
            passwordMaskedTextBox.Clear();
            userNameTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
