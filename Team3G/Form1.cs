using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3G
{
    public partial class Form1 : Form
    {

        int txt1, txt2, txt3;
        int quantity1, quantity2, quantity3;
        int total1, total2, total3;
        int total_q = 0, total_p = 0;
        int drinks1=50, drinks2=50, drinks3=50;
        int addDrinksTime1=0, addDrinksTime2 = 0, addDrinksTime3 = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void BtnDrink1_Click(object sender, EventArgs e)
        {
            try
            {
                txt1 = int.Parse(textBox1.Text);
                if (txt1 <= 0 || txt1 > 50)
                {
                    MessageBox.Show("Please Enter Between Minmum & Maximum Available Quantity Drinks", 
                    "Quantity Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    textBox1.Text = "";
                }
                else if (drinks1 >= txt1)
                {
                    drinks1 -= txt1;
                    quantity1 += txt1;
                    total1 += quantity1 * 150;
                    AddDataOnTable("Coca Cola", quantity1, 150, total1);
                    textBox1.Text = "";
                    lbl1.Text = drinks1.ToString();
                    CalculateTotal();
                }
                else if (drinks1 < txt1)
                    AddDrinksTimer1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message, "Input Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }

            int drinks1More = int.Parse(lbl1.Text);
            if (drinks1More >= 0 && drinks1More <= 10)
            {
                AddDrinksTimer1();
            }
        }

        private void BtnDrink2_Click(object sender, EventArgs e)
        {
            try
            {
                txt2 = int.Parse(textBox2.Text);
                if (txt2 <= 0 || txt2 > 50)
                {
                    MessageBox.Show("Please Enter Between Minmum & Maximum Available Quantity Drinks", "Quantity Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                }
                else if (drinks2 >= txt2)
                {
                    drinks2 -= txt2;
                    quantity2 += txt2;
                    total2 += quantity2 * 100;
                    AddDataOnTable("Apricot", quantity2, 100, total2);
                    textBox2.Text = "";
                    lbl2.Text = drinks2.ToString();
                    CalculateTotal();
                }
                else if (drinks2 < txt2)
                    AddDrinksTimer2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }

            int drinks2More = int.Parse(lbl2.Text);
            if (drinks2More >= 0 && drinks2More <= 10)
            {
                AddDrinksTimer2();
            }
        }

        private void BtnDrink3_Click(object sender, EventArgs e)
        {
            try {
                txt3 = int.Parse(textBox3.Text);
                if (txt3 <= 0 || txt3 > 50)
                {
                    MessageBox.Show("Please Enter Between Minmum & Maximum Available Quantity Drinks", "Quantity Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    textBox3.Text = "";
                }
                else if (drinks3 >= txt3)
                {
                    drinks3 -= txt3;
                    quantity3 += txt3;
                    total3 += quantity3 * 75;
                    AddDataOnTable("Leamon", quantity3, 75, total3);
                    textBox3.Text = "";
                    lbl3.Text = drinks3.ToString();
                    CalculateTotal();
                }
                else if (drinks3 < txt3)
                    AddDrinksTimer3();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
            }

            int drinks3More = int.Parse(lbl3.Text);
            if (drinks3More >= 0 && drinks3More <= 10)
            {
                AddDrinksTimer3();
            }

        }

        private void BtnBalance_Click(object sender, EventArgs e)
        {
            try
            {
                int amount = int.Parse(textBoxAmount.Text);
                int balance = amount - total_p;
                if (balance > 0)
                {
                    Form SuccessMsg = new SuccessMsg(total_p.ToString(),balance.ToString());
                    SuccessMsg.ShowDialog();
                    ClearValues();
                    ValuesZero();
                }
                else
                    MessageBox.Show("Please Enter Correct Amount", "Amount Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message, "Input Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxAmount.Text = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearValues();
            ValuesRearange();
            ValuesZero();
        }
        private void AddDataOnTable(String drink_name, int quantity, int unit_price, int total_price)
        {
            CheckRowValue(drink_name);
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = drink_name;
            row.Cells[1].Value = quantity;
            row.Cells[2].Value = unit_price;
            row.Cells[3].Value = total_price;
            dataGridView1.Rows.Add(row);
        }

        private void CheckRowValue(String drink_name)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool v = row.Cells[0].Value == drink_name;
                if (v)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void CalculateTotal()
        {
            total_q = quantity1 + quantity2 + quantity3;
            total_p = total1 + total2 + total3;
            lbl_TotalQuantity.Text = (total_q).ToString();
            lbl_TotalPrice.Text = (total_p).ToString();
        }
        private void ClearValues()
        {
            dataGridView1.Rows.Clear();
            lbl_TotalQuantity.Text = "0";
            lbl_TotalPrice.Text = "0";
        }

        private void ValuesZero()
        {
            quantity1 = 0;
            quantity2 = 0;
            quantity3 = 0;
            total1 = 0;
            total2 = 0;
            total3 = 0;
        }

        private void ValuesRearange()
        {
            drinks1 += quantity1;
            drinks2 += quantity2;
            drinks3 += quantity3;
            lbl1.Text = drinks1.ToString();
            lbl2.Text = drinks2.ToString();
            lbl3.Text = drinks3.ToString();
        }

        // TIMER
        private void AddDrinksTimer1()
        {
            addDrinksTime1 = 90;
            AddDrinks1.Start();
        }

        private void AddDrinks1_Tick(object sender, EventArgs e)
        {
            BtnDrink1.Enabled = false;
            lblWait1.Text = "Please Wait...";
            lblAddDrink1.Text = addDrinksTime1--.ToString();
            if (addDrinksTime1 == 0)
            {
                AddDrinks1.Stop();
                lblAddDrink1.Text = "";
                lblWait1.Text = "";
                BtnDrink1.Enabled = true;
                lbl1.Text = "50";
                drinks1 = 50;
            }
        }

        private void AddDrinksTimer2()
        {
            addDrinksTime2 = 90;
            AddDrinks2.Start();
        }

        private void AddDrinksTimer3()
        {
            addDrinksTime3 = 90;
            AddDrinks3.Start();
        }

        private void AddDrinks2_Tick(object sender, EventArgs e)
        {
            BtnDrink2.Enabled = false;
            lblWait2.Text = "Please Wait...";
            lblAddDrink2.Text = addDrinksTime2--.ToString();
            if (addDrinksTime2 == 0)
            {
                AddDrinks2.Stop();
                lblAddDrink2.Text = "";
                lblWait2.Text = "";
                BtnDrink2.Enabled = true;
                lbl2.Text = "50";
                drinks2 = 50;
            }
        }

        private void AddDrinks3_Tick(object sender, EventArgs e)
        {
            BtnDrink3.Enabled = false;
            lblWait3.Text = "Please Wait...";
            lblAddDrink3.Text = addDrinksTime3--.ToString();
            if (addDrinksTime3 == 0)
            {
                AddDrinks3.Stop();
                lblAddDrink3.Text = "";
                lblWait3.Text = "";
                BtnDrink3.Enabled = true;
                lbl3.Text = "50";
                drinks3 = 50;
            }
        }

    }
}
