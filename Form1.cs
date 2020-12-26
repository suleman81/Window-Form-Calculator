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
        Double resultValue = 0;
        string operatr = "";
        bool isoperatr = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || isoperatr)
                textBox_Result.Clear();

            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            
            isoperatr = false;
        }

        private void opertor_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(resultValue != 0)
            {
                buttonEqual.PerformClick();
                operatr = button.Text;
                CurrentOperation.Text = resultValue + " " + operatr;
                isoperatr = true;
            }
            else
            {
                operatr = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                CurrentOperation.Text = resultValue + " " + operatr;
                isoperatr = true;
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            switch (operatr)
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "x":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            CurrentOperation.Text = "";
        }
    }
}