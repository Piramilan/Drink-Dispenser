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
    public partial class SuccessMsg : Form
    {
        public SuccessMsg(String amount,String balance)
        {
            InitializeComponent();
            lblAmount.Text = amount;
            lblBalance.Text = balance;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
