using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // Base elements setup
        Double result = 0;
        String operation = "";
        bool input = false;
        string first_num, second_num;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_only(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(txtDisplay.Text == "0" || input)
            {
                txtDisplay.Text = "";
            }
            input = false;

            if(b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + b.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if(result != 0)
            {
                btnEquals.PerformClick();
                input = true;
                operation = b.Text;
                lblShowOp.Text = result + "  " + operation;
            }
            else
            {
                operation = b.Text; ;
                result = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOp.Text = result + "  " + operation;
                
            }
            switch (operation)
            {
                case "x²":
                    first_num = result + "  ";
                    break;
                default:
                    first_num = lblShowOp.Text;
                    break;
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblShowOp.Text = "";
            result = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            second_num = txtDisplay.Text;
            string sqr = "";
            lblShowOp.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "x":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "÷":
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "x²":
                    txtDisplay.Text = (Math.Pow(result, 2)).ToString();
                    second_num = " ";
                    sqr = "sqr ";
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtDisplay.Text);
            operation = "";

            btnClearHistory.Visible = true;
            rtbDisplayHistory.AppendText(sqr + first_num + "  " + second_num + " = " + "\n");
            rtbDisplayHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            lblHistoryDisplay.Text = "";
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            rtbDisplayHistory.Clear();
            if(lblHistoryDisplay.Text == "")
            {
                lblHistoryDisplay.Text = "There's no history yet";
                btnClearHistory.Visible = false;
            }
            rtbDisplayHistory.ScrollBars = 0;
        }

        private void rtbDisplayHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if(txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
    }
}
