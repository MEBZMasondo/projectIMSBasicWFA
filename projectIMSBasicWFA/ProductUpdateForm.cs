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
    public partial class ProductUpdateForm : Form
    {

        int current_selected_product_ID = 0;
        DBConnect db = null;

        public ProductUpdateForm()
        {
            InitializeComponent();
        }

        private void ProductUpdateForm_Load(object sender, EventArgs e)
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
                }
                else
                {
                    idLabel.Text = Convert.ToString(dr[0]);

                    nameTextBox.Text = Convert.ToString(dr[1]);
                    supplierTextBox.Text = Convert.ToString(dr[2]);
                    categoryComboBox.Text = Convert.ToString(dr[3]);
                    quantPerUnitTextBox.Text = Convert.ToString(dr[4]);
                    priceTextBox.Text = Convert.ToString(dr[5]);
                    unitsInStockTextBox.Text = Convert.ToString(dr[6]);
                    unitsOnOrderTextBox.Text = Convert.ToString(dr[7]);
                    reOrderLevelTextBox.Text = Convert.ToString(dr[8]);
                    //wr[9] = 0;
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update Product details?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // TODO : Data check
                    string selection = "ProductID = '" + current_selected_product_ID + "'";
                    DBConnect mydb = new DBConnect("Products", selection);
                    DataSet myds = new DataSet();
                    mydb.DA.Fill(myds, "Products");
                    mydb.DA.UpdateCommand = new SqlCommandBuilder(mydb.DA).GetUpdateCommand();
                    DataTable mydt = myds.Tables["Products"];


                    mydt.Rows[0][1] = nameTextBox.Text;
                    mydt.Rows[0][2] = supplierTextBox.Text;
                    mydt.Rows[0][3] = categoryComboBox.Text;
                    mydt.Rows[0][4] = quantPerUnitTextBox.Text;
                    mydt.Rows[0][5] = priceTextBox.Text;
                    mydt.Rows[0][6] = unitsInStockTextBox.Text;
                    mydt.Rows[0][7] = unitsOnOrderTextBox.Text;
                    mydt.Rows[0][8] = reOrderLevelTextBox.Text;

                    mydb.DA.Update(mydt);

                    MessageBox.Show("Product Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (result == DialogResult.No)
            {

            }

        }

        private void ProductUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // keep to refresh DB when this form closes
        }
    }
}
