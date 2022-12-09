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

namespace projectIMSBasicWFA
{
    public partial class ProductQuantForm : Form
    {
        int current_selected_product_ID = 0;
        DBConnect db = null;

        public ProductQuantForm()
        {
            InitializeComponent();
        }

        private void ProductQuantForm_Load(object sender, EventArgs e)
        {           
            try
            {
                current_selected_product_ID = IMSMainForm.SELECTED_PRODUCT_ID;

                string selection = "ProductID = '" + current_selected_product_ID + "'";
                db = new DBConnect("Products", selection);
                DataSet ds = new DataSet();
                db.DA.Fill(ds, "Products");
                db.DA.UpdateCommand = new SqlCommandBuilder(db.DA).GetUpdateCommand();
                DataTable dt = ds.Tables["Products"];

                DataRow dr = dt.Rows[0];

                if (Convert.ToInt32(dr[0]) == 0)
                {
                    idLabel.Text = "";
                    nameLabel.Text = "";
                }
                else
                {
                    idLabel.Text = Convert.ToString(dr[0]);
                    nameLabel.Text = Convert.ToString(dr[1]);

                    unitsInStockLabel.Text = Convert.ToString(dr[6]);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                db.SqlConn.Close();
            }
        }

        public void clearEntries()
        {
            offsetTextBox.Clear();
            offsetTextBox.Focus();
        }

        private void addRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            clearEntries();
        }

        private void subRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            clearEntries();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            
            int value;
            if(offsetTextBox.Text != "")
            {
                try
                {
                    current_selected_product_ID = IMSMainForm.SELECTED_PRODUCT_ID;
                    try
                    {
                        value = Convert.ToInt16(offsetTextBox.Text); // value to offset by
                        if (value > 0)
                        { } // do nothing                         
                        else
                        {
                            MessageBox.Show("Value must be greater than 0", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return; // do not continue with the rest of the code
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return; // do not continue with the rest of the code
                    }

                    DialogResult result = MessageBox.Show("Do you want to change the value?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        int currentQuantValue = 0;

                        string selection = "ProductID = '" + current_selected_product_ID + "'";
                        DBConnect mydb = new DBConnect("Products", selection);
                        DataSet myds = new DataSet();
                        mydb.DA.Fill(myds, "Products");
                        mydb.DA.UpdateCommand = new SqlCommandBuilder(mydb.DA).GetUpdateCommand();
                        DataTable mydt = myds.Tables["Products"];

                        if (addRadioButton.Checked)
                        {
                            currentQuantValue = Convert.ToInt32(mydt.Rows[0][6]);
                            mydt.Rows[0][6] = (currentQuantValue + value);

                            mydb.DA.Update(mydt);
                            clearEntries();

                            unitsInStockLabel.Text = Convert.ToString(currentQuantValue + value);
                        }

                        if (subRadioButton.Checked)
                        {
                            //mydt.Rows[0][6] = (Convert.ToInt32(mydt.Rows[0][6]) - value);

                            currentQuantValue = Convert.ToInt32(mydt.Rows[0][6]);
                            mydt.Rows[0][6] = (currentQuantValue - value);

                            mydb.DA.Update(mydt);
                            clearEntries();

                            unitsInStockLabel.Text = Convert.ToString(currentQuantValue - value);
                        }
                        String message = "Quantity changed successfully";
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("Please Enter data", "Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void ProductQuantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // keep to refresh DB when this form closes
        }
    }
}
