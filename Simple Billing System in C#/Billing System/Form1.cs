using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CafeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //test
        }

        private void button3_Click(object sender, EventArgs e)
        { //btnReset
            txtLatte.Text = "0";
            txtEspresso.Text = "0";
            txtMocha.Text = "0";
            txtValeCoffee.Text = "0";
            txtCappu.Text = "0";
            txtAfricanCoffee.Text = "0";
            txtMilkTea.Text = "0";
            txtChineseTea.Text = "0";
            txtCoffeCake.Text = "0";
            txtRedValvetCake.Text = "0";
            txtBlackForestCake.Text = "0";
            txtBostonCream.Text = "0";
            txtLagosChoco.Text = "0";
            txtKillburnChoco.Text = "0";
            txtCheeseCake.Text = "0";
            txtRainbowCake.Text = "0";
            lblCakeCost.Text = "0";
            lblDrinkCost.Text = "0"; 
            lblSvcCharge.Text = "2";
            lblTax.Text = "0";
            lblSubTotal.Text = "0";
            lblTotal.Text = "0";

            chkLatte.Checked = false;
            chkEspresso.Checked = false;
            chkMocha.Checked = false;
            chkValeCoffee.Checked = false;
            chkCappucino.Checked = false;
            chkAfricanCoffe.Checked = false;
            chkMilkTea.Checked = false;
            chkChineseTea.Checked = false;
            chkRedValvet.Checked = false;
            chkCoffe.Checked = false;
            chkBlackForest.Checked = false;
            chkBostonCream.Checked = false;
            checkBox13.Checked = false;
            chkKilburnChoco.Checked = false;
            chkCheese.Checked = false;
            chkRainbowCake.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Use a fixed-width font for accurate alignment
            rtfReceipt.Clear();
            rtfReceipt.Font = new Font("Courier New", 10, FontStyle.Regular);

            // Header
            rtfReceipt.AppendText("------------------------------------------------\n");
            rtfReceipt.AppendText("                   SN Cafe House                \n");
            rtfReceipt.AppendText("------------------------------------------------\n");
            rtfReceipt.AppendText($"{lblTimer.Text,-15}{lblDate.Text,25}\n");
            rtfReceipt.AppendText(string.Format("{0,-22}{1,8}{2,12}\n", "Item", "Qty", "Amount"));
            rtfReceipt.AppendText("------------------------------------------------\n");

            // Helper method for consistent spacing
            // Modified helper method to check if checkbox is checked
            void AddLineIfSelected(string qtyText, string item, double price, CheckBox chk)
            {
                if (chk.Checked && double.TryParse(qtyText, out double qty) && qty > 0)
                {
                    double amount = price * qty;
                    rtfReceipt.AppendText(string.Format("{0,-22}{1,8}{2,12}\n", item, qty, "₹" + amount.ToString("0.00")));
                }
            }


            // Item prices
            double lat = 40, mocha = 50, espr = 40, vale = 45, cappu = 70, afri = 50, mTea = 45, cTea = 30;
            double cCake = 130, rValvet = 120, bFor = 130, bCream = 190, lChoco = 150, kChoco = 140, cheese = 130, rain = 110;

            AddLineIfSelected(txtLatte.Text, "Latte", lat, chkLatte);
            AddLineIfSelected(txtEspresso.Text, "Espresso", espr, chkEspresso);
            AddLineIfSelected(txtMocha.Text, "Mocha", mocha, chkMocha);
            AddLineIfSelected(txtValeCoffee.Text, "Vale Coffee", vale, chkValeCoffee);
            AddLineIfSelected(txtCappu.Text, "Cappuccino", cappu, chkCappucino);
            AddLineIfSelected(txtAfricanCoffee.Text, "African Coffee", afri, chkAfricanCoffe);
            AddLineIfSelected(txtMilkTea.Text, "Milk Tea", mTea, chkMilkTea);
            AddLineIfSelected(txtChineseTea.Text, "Chinese Tea", cTea, chkChineseTea);

            AddLineIfSelected(txtCoffeCake.Text, "Coffee Cake", cCake, chkCoffe);
            AddLineIfSelected(txtRedValvetCake.Text, "Red Velvet Cake", rValvet, chkRedValvet);
            AddLineIfSelected(txtBlackForestCake.Text, "Black Forest Cake", bFor, chkBlackForest);
            AddLineIfSelected(txtBostonCream.Text, "Boston Cream Cake", bCream, chkBostonCream);
            AddLineIfSelected(txtLagosChoco.Text, "Lagos Chocolate Cake", lChoco, checkBox13);
            AddLineIfSelected(txtKillburnChoco.Text, "Kilburn Chocolate Cake", kChoco, chkKilburnChoco);
            AddLineIfSelected(txtCheeseCake.Text, "Cheese Cake", cheese, chkCheese);
            AddLineIfSelected(txtRainbowCake.Text, "Rainbow Cake", rain, chkRainbowCake);


            // Footer
            rtfReceipt.AppendText("------------------------------------------------\n");

            double svcCharge = ParseCurrency(lblSvcCharge.Text);
            double tax = ParseCurrency(lblTax.Text);
            double subTotal = ParseCurrency(lblSubTotal.Text);
            double total = ParseCurrency(lblTotal.Text);

            rtfReceipt.AppendText(string.Format("{0,-25}{1,12}\n", "Service Charge", "₹" + svcCharge.ToString("0.00")));
            rtfReceipt.AppendText(string.Format("{0,-25}{1,12}\n", "Tax", "₹" + tax.ToString("0.00")));
            rtfReceipt.AppendText(string.Format("{0,-25}{1,12}\n", "Sub Total", "₹" + subTotal.ToString("0.00")));
            rtfReceipt.AppendText(string.Format("{0,-25}{1,12}\n", "Total Cost", "₹" + total.ToString("0.00")));
            rtfReceipt.AppendText("------------------------------------------------\n");
        }

        // Helper method
        private double ParseCurrency(string text)
        {
            if (double.TryParse(text.Replace("₹", "").Trim(), NumberStyles.Any, new CultureInfo("en-IN"), out double val))
                return val;
            return 0;
        }




        private void button1_Click(object sender, EventArgs e)
        { //btnTotal

            double lat, mocha, espr, vale, cappu, afri, mTea, cTea;
            double cCake, rValvet, bFor, bCream, lChoco, kChoco, cheese, rain;
            double tax;
            tax = 4;

            lat = 40; mocha = 50; espr = 40; vale = 45; cappu = 70; afri = 50; mTea = 45; cTea = 30; //coffee pries
            cCake = 130; rValvet = 120; bFor = 130; bCream = 190; lChoco = 150; kChoco = 140; cheese = 130; rain = 110; //cake prices


            //Coffee
            double latteeCof = Convert.ToDouble(txtLatte.Text);
            double mochaCof = Convert.ToDouble(txtMocha.Text);
            double espressoCof = Convert.ToDouble(txtEspresso.Text);
            double valeCoffee = Convert.ToDouble(txtValeCoffee.Text);
            double cappCof = Convert.ToDouble(txtCappu.Text);
            double afriCof = Convert.ToDouble(txtAfricanCoffee.Text);
            double miTea = Convert.ToDouble(txtMilkTea.Text);
            double cineseTea = Convert.ToDouble(txtChineseTea.Text);
            //Cakes
            double cofCake = Convert.ToDouble(txtCoffeCake.Text);
            double redValvet = Convert.ToDouble(txtRedValvetCake.Text);
            double bForest = Convert.ToDouble(txtBlackForestCake.Text);
            double bostonCream = Convert.ToDouble(txtBostonCream.Text);
            double lagosChoco = Convert.ToDouble(txtLagosChoco.Text);
            double kilbChoco = Convert.ToDouble(txtKillburnChoco.Text);
            double cheeseCak = Convert.ToDouble(txtCheeseCake.Text);
            double rainbow = Convert.ToDouble(txtRainbowCake.Text);

            Cafe eat_in_cafe = new Cafe(latteeCof, mochaCof, espressoCof, valeCoffee, cappCof, afriCof, miTea, cineseTea,
                cofCake, redValvet, bForest, bostonCream, lagosChoco, kilbChoco, cheeseCak, rainbow);

            double drinkCosts = (latteeCof * lat) + (mochaCof * mocha) + (espressoCof * espr) + (valeCoffee * vale) + (cappCof * cappu) + (afriCof * afri) + (miTea * mTea) + (cineseTea * cTea);
            lblDrinkCost.Text = Convert.ToString(drinkCosts);
            double cakeCosts = (cofCake * cCake) + (redValvet * rValvet) + (bForest * bFor) + (bostonCream * bCream) + (lagosChoco * lChoco) + (kilbChoco * kChoco) + (cheeseCak * cheese) + (rainbow * rain);
            lblCakeCost.Text = Convert.ToString(cakeCosts);

            double svcCharge = ParseCurrency(lblSvcCharge.Text);


            lblSubTotal.Text = Convert.ToString(cakeCosts + drinkCosts + svcCharge);
            lblTax.Text = Convert.ToString(((cakeCosts + drinkCosts + svcCharge) * tax) / 100);
            double totalAftTax = Convert.ToDouble(lblTax.Text);
            lblTotal.Text = Convert.ToString(cakeCosts + drinkCosts + svcCharge + totalAftTax);

            lblDrinkCost.Text = String.Format(new CultureInfo("en-IN"), "{0:C}", drinkCosts);
            lblCakeCost.Text = String.Format(new CultureInfo("en-IN"), "{0:C}", cakeCosts);
            lblSvcCharge.Text = String.Format(new CultureInfo("en-IN"), "{0:C}", svcCharge);
            lblSubTotal.Text = String.Format(new CultureInfo("en-IN"), "{0:C}", (cakeCosts + drinkCosts + svcCharge));
            lblTax.Text = String.Format(new CultureInfo("en-IN"), "{0:C}", totalAftTax);
            lblTotal.Text = String.Format(new CultureInfo("en-IN"), "{0:C}", (cakeCosts + drinkCosts + svcCharge + totalAftTax));

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
            double latteeCof = Convert.ToDouble(txtLatte.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start();


            txtLatte.Text = "0";
            txtEspresso.Text = "0";
            txtMocha.Text = "0";
            txtValeCoffee.Text = "0";
            txtCappu.Text = "0";
            txtAfricanCoffee.Text = "0";
            txtMilkTea.Text = "0";
            txtChineseTea.Text = "0";
            txtCoffeCake.Text = "0";
            txtRedValvetCake.Text = "0";
            txtBlackForestCake.Text = "0";
            txtBostonCream.Text = "0";
            txtLagosChoco.Text = "0";
            txtKillburnChoco.Text = "0";
            txtCheeseCake.Text = "0";
            txtRainbowCake.Text = "0";
            lblCakeCost.Text = "0";
            lblDrinkCost.Text = "0";
            lblSvcCharge.Text = "2";
            lblSubTotal.Text = "0";
            lblTax.Text = "0";
            lblTotal.Text = "0";

            txtLatte.Enabled = false;
            txtEspresso.Enabled = false; ;
            txtMocha.Enabled = false;
            txtValeCoffee.Enabled = false;
            txtCappu.Enabled = false;
            txtAfricanCoffee.Enabled = false;
            txtMilkTea.Enabled = false;
            txtChineseTea.Enabled = false;
            txtCoffeCake.Enabled = false;
            txtRedValvetCake.Enabled = false;
            txtBlackForestCake.Enabled = false;
            txtBostonCream.Enabled = false;
            txtLagosChoco.Enabled = false;
            txtKillburnChoco.Enabled = false;
            txtCheeseCake.Enabled = false;
            txtRainbowCake.Enabled = false;

            chkLatte.Checked = false;
            chkEspresso.Checked = false;
            chkMocha.Checked = false;
            chkValeCoffee.Checked = false;
            chkCappucino.Checked = false;
            chkAfricanCoffe.Checked = false;
            chkMilkTea.Checked = false;
            chkChineseTea.Checked = false;
            chkRedValvet.Checked = false;
            chkCoffe.Checked = false;
            chkBlackForest.Checked = false;
            chkBostonCream.Checked = false;
            checkBox13.Checked = false;
            chkKilburnChoco.Checked = false;
            chkCheese.Checked = false;
            chkRainbowCake.Checked = false;

            rtfReceipt.Clear();

        }

        private void chkLatte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLatte.Checked==true)
            {
                txtLatte.Enabled = true;
            }
            else
            {
                txtLatte.Enabled = false;
                txtLatte.Text = "0";
            }
        }    

        private void txtLatte_Click(object sender, EventArgs e)
        {
            txtLatte.Text = "";
            txtLatte.Focus();
        }

        private void chkEspresso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEspresso.Checked == true)
            {
               txtEspresso.Enabled = true;
            }
            else
            {
                txtEspresso.Enabled = false;
                txtEspresso.Text = "0";
            }
        }

        private void txtEspresso_Click(object sender, EventArgs e)
        {
            txtEspresso.Text = "";
            txtEspresso.Focus();
        }

        private void chkMocha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMocha.Checked == true)
            {
                txtMocha.Enabled = true;
            }
            else
            {
                txtMocha.Enabled = false;
                txtMocha.Text = "0";
            }
        }

        private void txtMocha_Click(object sender, EventArgs e)
        {
            txtMocha.Text = "";
            txtMocha.Focus();
        }

        private void chkValeCoffee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValeCoffee.Checked == true)
            {
                txtValeCoffee.Enabled = true;
            }
            else
            {
                txtValeCoffee.Enabled = false;
                txtValeCoffee.Text = "0";
            }
        }

        private void txtValeCoffee_Click(object sender, EventArgs e)
        {
            txtValeCoffee.Text = "";
            txtValeCoffee.Focus();
        }

        private void chkCappucino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCappucino.Checked == true)
            {
                txtCappu.Enabled = true;
            }
            else
            {
                txtCappu.Enabled = false;
                txtCappu.Text = "0";
            }
        }

        private void txtCappu_Click(object sender, EventArgs e)
        {
            txtCappu.Text = "";
            txtCappu.Focus();
        }

        private void chkAfricanCoffe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAfricanCoffe.Checked == true)
            {
                txtAfricanCoffee.Enabled = true;
            }
            else
            {
                txtAfricanCoffee.Enabled = false;
                txtAfricanCoffee.Text = "0";
            }
        }

           private void txtAfricanCoffee_Click(object sender, EventArgs e)
        {
            txtAfricanCoffee.Text = "";
            txtAfricanCoffee.Focus();
        }

        private void chkMilkTea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMilkTea.Checked == true)
            {
                txtMilkTea.Enabled = true;
            }
            else
            {
                txtMilkTea.Enabled = false;
                txtMilkTea.Text = "0";
            }
        }

        private void txtMilkTea_Click(object sender, EventArgs e)
        {
            txtMilkTea.Text = "";
            txtMilkTea.Focus();
        }

        private void chkChineseTea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChineseTea.Checked == true)
            {
                txtChineseTea.Enabled = true;
            }
            else
            {
                txtChineseTea.Enabled = false;
                txtChineseTea.Text = "0";
            }
        }

        private void txtChineseTea_Click(object sender, EventArgs e)
        {
            txtChineseTea.Text = "";
            txtChineseTea.Focus();
        }

        private void chkCoffe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCoffe.Checked == true)
            {
                txtCoffeCake.Enabled = true;
            }
            else
            {
                txtCoffeCake.Enabled = false;
                txtCoffeCake.Text = "0";
            }
        }

        private void txtCoffeCake_Click(object sender, EventArgs e)
        {
            txtCoffeCake.Text = "";
            txtCoffeCake.Focus();
        }

        private void chkRedValvet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRedValvet.Checked == true)
            {
                txtRedValvetCake.Enabled = true;
            }
            else
            {
                txtRedValvetCake.Enabled = false;
                txtRedValvetCake.Text = "0";
            }
        }

        private void txtRedValvetCake_Click(object sender, EventArgs e)
        {
            txtRedValvetCake.Text = "";
            txtRedValvetCake.Focus();
        }


        private void chkBlackForest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlackForest.Checked == true)
            {
                txtBlackForestCake.Enabled = true;
            }
            else
            {
                txtBlackForestCake.Enabled = false;
                txtBlackForestCake.Text = "0";
            }
        }

        private void txtBlackForestCake_Click(object sender, EventArgs e)
        {
            txtBlackForestCake.Text = "";
            txtBlackForestCake.Focus();
        }

        private void chkBostonCream_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBostonCream.Checked == true)
            {
                txtBostonCream.Enabled = true;
            }
            else
            {
                txtBostonCream.Enabled = false;
                txtBostonCream.Text = "0";
            }
        }

        private void txtBostonCream_Click(object sender, EventArgs e)
        {
            txtBostonCream.Text = "";
            txtBostonCream.Focus();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
               txtLagosChoco.Enabled = true;
            }
            else
            {
                txtLagosChoco.Enabled = false;
                txtLagosChoco.Text = "0";
            }
        }

        private void txtLagosChoco_Click(object sender, EventArgs e)
        {
            txtLagosChoco.Text = "";
            txtLagosChoco.Focus();
        }

        private void chkKilburnChoco_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKilburnChoco.Checked == true)
            {
                txtKillburnChoco.Enabled = true;
            }
            else
            {
                txtKillburnChoco.Enabled = false;
                txtKillburnChoco.Text = "0";
            }
        }


        private void txtKillburnChoco_Click(object sender, EventArgs e)
        {
            txtKillburnChoco.Text = "";
            txtKillburnChoco.Focus();
        }

        private void chkCheese_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheese.Checked == true)
            {
                txtCheeseCake.Enabled = true;
            }
            else
            {
                txtCheeseCake.Enabled = false;
                txtCheeseCake.Text = "0";
            }
        }


        private void txtCheeseCake_Click(object sender, EventArgs e)
        {
            txtCheeseCake.Text = "";
            txtCheeseCake.Focus();
        }

        private void chkRainbowCake_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRainbowCake.Checked == true)
            {
               txtRainbowCake.Enabled = true;
            }
            else
            {
                txtRainbowCake.Enabled = false;
                txtRainbowCake.Text = "0";
            }
        }

        private void txtRainbowCake_Click(object sender, EventArgs e)
        {
            txtRainbowCake.Text = "";
            txtRainbowCake.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
        }

        private int currentLineIndex = 0; // for pagination

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Courier New", 8);
            float lineHeight = printFont.GetHeight(e.Graphics);
            float topMargin = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float y = topMargin;

            string[] lines = rtfReceipt.Text.Split(new[] { '\n' }, StringSplitOptions.None);
            int linesPerPage = (int)(e.MarginBounds.Height / lineHeight);

            while (currentLineIndex < lines.Length && linesPerPage > 0)
            {
                string line = lines[currentLineIndex];

                // Optional truncation if too long
                int maxChars = (int)(e.MarginBounds.Width / printFont.SizeInPoints * 1.6f);
                if (line.Length > maxChars)
                    line = line.Substring(0, maxChars);

                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, y);
                y += lineHeight;
                currentLineIndex++;
                linesPerPage--;
            }

            e.HasMorePages = currentLineIndex < lines.Length;

            if (!e.HasMorePages)
                currentLineIndex = 0;
        }



        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PaperSize receiptPaper = new PaperSize("Receipt", 315, 800); // 80mm width
            printDocument1.DefaultPageSettings.PaperSize = receiptPaper;
            printDocument1.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }



        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Paste();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //this code will open text files
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                rtfReceipt.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //this code will save text files
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            
            
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName))
                    sw.WriteLine(rtfReceipt.Text);
            }
        }

        
    }
}
