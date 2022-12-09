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
    public partial class IMSMainForm : Form
    {
        public static int SELECTED_PRODUCT_ID = 1;

        public IMSMainForm()
        {
            InitializeComponent();
        }

        public void loadAllData()
        {
            try
            {
                String tableName = "Products";
                String queryWHERE = "Discontinued = '" + 0 + "'";
                DBConnect dbAll = new DBConnect(tableName, queryWHERE);
                DataSet dsAll = new DataSet();
                dbAll.DA.Fill(dsAll, "Products");
                DataTable dtAll = dsAll.Tables["Products"];

                productDataGridView.DataSource = dtAll;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            finally
            {

            }           
        }

        private void IMSMainForm_Load(object sender, EventArgs e)
        {
            loadAllData();

            // Maximise Form
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want to Exit The Application", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            loadAllData();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                try
                {
                    if (searchByIDRadioButton.Checked)
                    {
                        String tableName = "Products";
                        String queryWHERE = "ProductID = '" + searchTextBox.Text + "' AND Discontinued = '" + 0 + "'";
                        DBConnect dbID = new DBConnect(tableName, queryWHERE);
                        DataSet dsID = new DataSet();
                        dbID.DA.Fill(dsID, "Products");
                        DataTable dtID = dsID.Tables["Products"];

                        productDataGridView.DataSource = dtID;
                    }
                    if (searchByNameRadioButton.Checked)
                    {
                        String tableName = "Products";
                        String queryWHERE = "ProductName LIKE'%" + searchTextBox.Text + "%' AND Discontinued = '" + 0 + "'";
                        DBConnect dbName = new DBConnect(tableName, queryWHERE);
                        DataSet dsName = new DataSet();
                        dbName.DA.Fill(dsName, "Products");
                        DataTable dtName = dsName.Tables["Products"];

                        productDataGridView.DataSource = dtName;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Data Type input: Name OR ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Please Enter Search Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            loadAllData();
        }

        private void searchByNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            loadAllData();
        }

        private void searchByIDRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            loadAllData();
        }

        private void lowStockButton_Click(object sender, EventArgs e)
        {
            try
            {
                String tableName = "Products";
                String queryWHERE = "UnitsInStock < '" + lowLimitTextBox.Text + "' AND Discontinued = '" + 0 + "'";
                DBConnect dbLowS = new DBConnect(tableName, queryWHERE);
                DataSet dsLowS = new DataSet();
                dbLowS.DA.Fill(dsLowS, "Products");
                DataTable dtLowS = dsLowS.Tables["Products"];

                productDataGridView.DataSource = dtLowS;
            } catch(Exception)
            {
                MessageBox.Show("Please Check Data Type input: Number Expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lowStockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(lowStockCheckBox.Checked == true)
            {
                lowLimitTextBox.ReadOnly = false;
            } else
            {
                lowLimitTextBox.ReadOnly = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ProductAddForm ProdAdd = new ProductAddForm();
            ProdAdd.FormClosed += new FormClosedEventHandler(ProductAddForm_FormClosed); //add handler to catch when child form is closed
            ProdAdd.ShowDialog();
        }
        private void ProductAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // what to do if ProdQuantForm closes
            loadAllData(); //when child form is closed, this code is executed
        }

        private void updateQuantButton_Click(object sender, EventArgs e)
        {
            ProductQuantForm ProdQuant = new ProductQuantForm();//create new isntance of form
            ProdQuant.FormClosed += new FormClosedEventHandler(ProductQuantForm_FormClosed); //add handler to catch when child form is closed
            ProdQuant.ShowDialog();
        }
        private void ProductQuantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            loadAllData(); //when child form is closed, this code is executed
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ProductUpdateForm ProdUpdate = new ProductUpdateForm();
            ProdUpdate.FormClosed += new FormClosedEventHandler(ProductUpdateForm_FormClosed); //add handler to catch when child form is closed
            ProdUpdate.ShowDialog();
        }
        private void ProductUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadAllData(); //when child form is closed, this code is executed
        }

        private void productDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SELECTED_PRODUCT_ID = Convert.ToInt32(productDataGridView.Rows[productDataGridView.CurrentCell.RowIndex].Cells[0].Value);
            } 
            catch(Exception)
            {

            }
        }

        private void actReactButton_Click(object sender, EventArgs e)
        {
            ProductArchiveForm prodArchive = new ProductArchiveForm();
            prodArchive.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want to Log Out", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool IsOpen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "LoginForm")
                    {
                        IsOpen = true;

                        f.Show();
                        f.Update();

                        this.Close();
                  
                        break;
                    }
                }
                if (IsOpen == false)
                {
                    LoginForm log = new LoginForm();
                    log.Show();

                    this.Close();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void IMSMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
