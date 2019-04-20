using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        string[] petrolNames = new string[] { "А 95+", "А 95", "А 92", "ДТ", "Газ" };
        double[] petrolPrices = new double[] { 31.99,33.99,29.99,29.99,16.69 };
        int[] productPrices = new int[] { 25, 27, 35, 12};

        bool litresActive = false;
        bool moneyActive = false;



        public Form1()
        {
            InitializeComponent();

            cmbBox_Petrols.Items.AddRange(petrolNames);
            txtBox_Price.Enabled = false;
            txtBox_Litres.Enabled = false;
            txtBox_HowMuchInUAN.Enabled = false;

            cmbBox_Petrols.SelectedValueChanged += CmbBox_Petrols_SelectedValueChanged;

            radioB_Litres.CheckedChanged += RadioB_Litres_CheckedChanged;
            radioB_SumUAN.CheckedChanged += RadioB_Litres_CheckedChanged;

            txtBox_Litres.TextChanged += TxtBox_Litres_TextChanged;
            txtBox_HowMuchInUAN.TextChanged += TxtBox_HowMuchInUAN_TextChanged;

            checkB_product_1.CheckedChanged += ChangeCheckProducts;
            checkB_product_2.CheckedChanged += ChangeCheckProducts;
            checkB_product_3.CheckedChanged += ChangeCheckProducts;
            checkB_product_4.CheckedChanged += ChangeCheckProducts;


            txtBox_PriceProduct_1.Text = productPrices[0].ToString();
            txtBox_PriceProduct_2.Text = productPrices[1].ToString();
            txtBox_PriceProduct_3.Text = productPrices[2].ToString();
            txtBox_PriceProduct_4.Text = productPrices[3].ToString();

            txtBox_CountProduct_1.TextChanged += ChangeCountProduct;
            txtBox_CountProduct_2.TextChanged += ChangeCountProduct;
            txtBox_CountProduct_3.TextChanged += ChangeCountProduct;
            txtBox_CountProduct_4.TextChanged += ChangeCountProduct;

            lbl_CafePrice.TextChanged += PriceChange;
            lbl_PetrolPrice.TextChanged += PriceChange;
        }

        private void PriceChange(object sender, EventArgs e)
        {
            if (lbl_CafePrice.Text != "0" && lbl_PetrolPrice.Text != "0")
            {
                double finalPrice = Convert.ToDouble(lbl_CafePrice.Text) + Convert.ToDouble(lbl_PetrolPrice.Text);

                lbl_FinalPrice.Text = finalPrice.ToString();
            }
            
        }

        private void ChangeCountProduct(object sender, EventArgs e)
        {
            int finalPrice = 0;
            if (txtBox_CountProduct_1.Enabled && txtBox_CountProduct_1.Text != "")
            {
                finalPrice += productPrices[0] * Convert.ToInt32(txtBox_CountProduct_1.Text);
            }
            if (txtBox_CountProduct_2.Enabled && txtBox_CountProduct_2.Text != "")
            {
                finalPrice += productPrices[1] * Convert.ToInt32(txtBox_CountProduct_2.Text);
            }
            if (txtBox_CountProduct_3.Enabled && txtBox_CountProduct_3.Text != "")
            {
                finalPrice += productPrices[2] * Convert.ToInt32(txtBox_CountProduct_3.Text);
            }
            if (txtBox_CountProduct_4.Enabled && txtBox_CountProduct_4.Text != "")
            {
                finalPrice += productPrices[3] * Convert.ToInt32(txtBox_CountProduct_4.Text);
            }

            lbl_CafePrice.Text = finalPrice.ToString();

            if (finalPrice == 0)
            {
                txtBox_CountProduct_1.Text = "";
                txtBox_CountProduct_2.Text = "";
                txtBox_CountProduct_3.Text = "";
                txtBox_CountProduct_4.Text = "";
                lbl_CafePrice.Text = "0";
            }

        }

        private void ChangeCheckProducts(object sender, EventArgs e)
        {
            if (checkB_product_1.Checked)
            {
                txtBox_PriceProduct_1.Enabled = true;
                txtBox_CountProduct_1.Enabled = true;
            }
            else
            {
                
                txtBox_CountProduct_1.Text = "";
                txtBox_PriceProduct_1.Enabled = false;
                txtBox_CountProduct_1.Enabled = false;
            }
            if (checkB_product_2.Checked)
            {
                txtBox_PriceProduct_2.Enabled = true;
                txtBox_CountProduct_2.Enabled = true;
            }
            else
            {
                
                txtBox_CountProduct_2.Text = "";
                txtBox_PriceProduct_2.Enabled = false;
                txtBox_CountProduct_2.Enabled = false;
            }
            if (checkB_product_3.Checked)
            {
                txtBox_PriceProduct_3.Enabled = true;
                txtBox_CountProduct_3.Enabled = true;
            }
            else
            {
                
                txtBox_CountProduct_3.Text = "";
                txtBox_PriceProduct_3.Enabled = false;
                txtBox_CountProduct_3.Enabled = false;
            }
            if (checkB_product_4.Checked)
            {
                txtBox_PriceProduct_4.Enabled = true;
                txtBox_CountProduct_4.Enabled = true;
            }
            else
            {
               
                txtBox_CountProduct_4.Text = "";
                txtBox_PriceProduct_4.Enabled = false;
                txtBox_CountProduct_4.Enabled = false;
            }
        }

        private void TxtBox_HowMuchInUAN_TextChanged(object sender, EventArgs e)
        {
            if (moneyActive)
            {
                double litres;
                if (System.Text.RegularExpressions.Regex.IsMatch(txtBox_HowMuchInUAN.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtBox_HowMuchInUAN.Text = txtBox_HowMuchInUAN.Text.Remove(txtBox_HowMuchInUAN.Text.Length - 1);
                }

                if (txtBox_Price.Text != "")
                {
                    if (txtBox_HowMuchInUAN.Text != "")
                    {
                        litres = Convert.ToDouble(txtBox_HowMuchInUAN.Text) / Convert.ToDouble(txtBox_Price.Text);
                        litres = Convert.ToInt32(litres);
                        txtBox_Litres.Text = litres.ToString();
                        lbl_PetrolPrice.Text = txtBox_HowMuchInUAN.Text;
                    }
                    else
                    {
                        txtBox_HowMuchInUAN.Text = "";
                        lbl_PetrolPrice.Text = "0";
                    }
                }
            }
        }

        private void TxtBox_Litres_TextChanged(object sender, EventArgs e)
        {
            if (litresActive)
            {
                double price;
                if (System.Text.RegularExpressions.Regex.IsMatch(txtBox_Litres.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtBox_Litres.Text = txtBox_Litres.Text.Remove(txtBox_Litres.Text.Length - 1);
                }
                if (txtBox_Price.Text != "")
                {
                    if (txtBox_Litres.Text != "")
                    {
                        price = Convert.ToDouble(txtBox_Price.Text) * Convert.ToDouble(txtBox_Litres.Text);
                        txtBox_HowMuchInUAN.Text = price.ToString();
                        lbl_PetrolPrice.Text = price.ToString();
                    }
                    else
                    {
                        txtBox_HowMuchInUAN.Text = "";
                        lbl_PetrolPrice.Text = "0";
                    }
                }
            }
        }

        private void RadioB_Litres_CheckedChanged(object sender, EventArgs e)
        {
            if (radioB_Litres.Checked)
            {
                txtBox_Litres.Enabled = true;
                litresActive = true;
            }
            else
            {
                txtBox_Litres.Enabled = false;
                litresActive = false;
            }

            if (radioB_SumUAN.Checked)
            {
                txtBox_HowMuchInUAN.Enabled = true;
                moneyActive = true;
            }
            else
            {
                txtBox_HowMuchInUAN.Enabled = false;
                moneyActive = false;
            }

        }

        private void CmbBox_Petrols_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBox_Price.Text = petrolPrices[cmbBox_Petrols.SelectedIndex].ToString();
            txtBox_Price.Enabled = false;

            txtBox_Litres.Text = "";
            txtBox_HowMuchInUAN.Text = "";
            lbl_PetrolPrice.Text = "0";
        }

        
    }
}
