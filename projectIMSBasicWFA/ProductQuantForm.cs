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
                }
                else
                {
                    idLabel.Text = Convert.ToString(dr[0]);

                    unitsInStockLabel.Text = Convert.ToString(dr[6]);
                }

                /*
                string selection = "ProductID = '" + current_selected_product_ID + "'";
                db = new DBConnect("Products", selection);
                SqlDataReader reader = db.Cmd.ExecuteReader();
                if (reader.Read())
                {
                    idLabel.Text = Convert.ToString(reader[0]);
                }
                else
                {
                    idLabel.Text = "";
                }
                db.SqlConn.Close(); //don’t forget
                */
            }
            catch (Exception)
            {

            }
            finally
            {
                db.SqlConn.Close();
            }
        }

        private void addRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void subRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect mydb = new DBConnect("Products");
                DataSet myds = new DataSet();
                mydb.DA.Fill(myds, "Products");
                mydb.DA.UpdateCommand = new SqlCommandBuilder(mydb.DA).GetUpdateCommand();
                DataTable mydt = myds.Tables["Products"];            

                if (addRadioButton.Checked)
                {
                    MessageBox.Show("Im Here");

                    foreach (DataRow dr in mydt.Rows)
                    {
                        if (Convert.ToInt32(dr[0]) == current_selected_product_ID)
                        {
                            dr["UnitsInStock"] = ((int)dr["UnitsInStock"] + Convert.ToInt32(offsetTextBox.Text));
                        }
                    }
                    mydb.DA.Update(mydt);
                }
                if (subRadioButton.Checked)
                {
                    foreach (DataRow dr in mydt.Rows)
                    {
                        if (Convert.ToInt32(dr[0]) == current_selected_product_ID)
                        {
                            dr["UnitsInStock"] = ((int)dr["UnitsInStock"] - Convert.ToInt32(offsetTextBox.Text));
                        }
                    }
                    mydb.DA.Update(mydt);
                }

               

            }
            catch (Exception)
            {

            }

           
        }
    }
}
