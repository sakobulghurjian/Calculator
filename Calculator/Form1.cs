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
        private string first;
        private string result;
        private Calc calc;

        public Form1()
        {
            InitializeComponent();
            ResultBox.Enabled = false;
            Box.Enabled = false;
        }
        #region Operations
        #region PutCalc
        private void plas_Click(object sender, EventArgs e)
        {
            if (Check())
                calc = Calc.plus;
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (Check())
                calc = Calc.minus;
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            if (Check())
                calc = Calc.multi;
        }
        private void Divis_Click(object sender, EventArgs e)
        {
            if (Check())
                calc = Calc.plus;
        }
        private bool Check()
        {
            if (Box.Text == "")
                return false;

            if (result != null)
            {
                if (Box.Text[Box.Text.Length - 1] == '.')
                {
                    Box.Text += '0';
                }
                Box.Text = null;
                first = result;
                return true;
            }

            if (first == null)
            {
                first = Box.Text;
                Box.Text = null;
                return true;
            }
            return true;
        }
        #endregion
        #region PutNumbers       
        private void button11_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == null)
                return;

            Box.Text += b.Text;
            Calculate(calc);
        }
        private void Calculate(Calc calc1)
        {
            if (first == null)
                return;

            double x = Convert.ToDouble(first);
            double y = Convert.ToDouble(Box.Text);
            switch (calc1)
            {
                case Calc.plus:
                    result = Convert.ToString(x + y);
                    break;
                case Calc.minus:
                    result = Convert.ToString(x - y);
                    break;
                case Calc.multi:
                    result = Convert.ToString(x * y);
                    break;
                case Calc.divis:
                    result = Convert.ToString(x / y);
                    break;
            }
            ResultBox.Text = result;
        }
        #endregion
        private void Clear_Click(object sender, EventArgs e)
        {
            Box.Text = null;
            ResultBox.Text = null;
            first = null;
            result = null;
        }

        private void Point_Click(object sender, EventArgs e)
        {
            if(Box.Text == "")
                return;

            foreach (char c in Box.Text)
            {
                if (c == '.')
                    return;
            }
            Box.Text += ".";
        }

        private void Result_Click(object sender, EventArgs e)
        {
            Box.Text = result;
        }
        #endregion
    }

    public enum Calc
    {
        plus,
        minus,
        multi,
        divis
    }
}
