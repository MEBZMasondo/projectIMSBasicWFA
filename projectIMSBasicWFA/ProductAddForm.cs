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
    public partial class ProductAddForm : Form
    {

        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {

        }

        public void clearEntries()
        {
            nameTextBox.Text = "";
            categoryComboBox.Text = "";
            priceTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text != "" && categoryComboBox.Text != "" && priceTextBox.Text != "" )
            {
                DialogResult dialogRes = MessageBox.Show("Add Product ?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogRes == DialogResult.Yes)
                {
                    try
                    {
                        DBConnect db = new DBConnect("Products");
                        DataSet ds = new DataSet();
                        db.DA.Fill(ds, "Products");
                        db.DA.UpdateCommand = new SqlCommandBuilder(db.DA).GetUpdateCommand();
                        DataTable dt = ds.Tables["Products"];

                        DataRow wr = dt.NewRow();

                        // TODO : Tests before adding the data                      
                        wr[1] = nameTextBox.Text;
                        wr[2] = supplierTextBox.Text;
                        wr[3] = Convert.ToInt32(categoryComboBox.Text);
                        wr[4] = quantPerUnitTextBox.Text;
                        wr[5] = Convert.ToDecimal(priceTextBox.Text);
                        wr[6] = Convert.ToInt32(unitsInStockTextBox.Text);
                        wr[7] = Convert.ToInt32(unitsOnOrderTextBox.Text);
                        wr[8] = Convert.ToInt32(reOrderLevelTextBox.Text);
                        wr[9] = 0;
                        dt.Rows.Add(wr);
                        db.DA.Update(dt);

                        MessageBox.Show("Product Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearEntries();
                    
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please Check Data Types input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Product Add Not Completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {
                MessageBox.Show("Please Enter All Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
