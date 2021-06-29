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
    public partial class calculator : Form
    {
        bool Memory = true;
        string operation = "";

        public calculator()
        {
            InitializeComponent();
        }

        void plustablo(char symvol)
        {
            if (Memory)
                result.Text = "";
            if (result.Text == "0")
                result.Text = "";
            result.Text += symvol.ToString();
            Memory = false;
        }

        private void runOperationTablo(string oper)
        {
            double tablo;
            if (oper == "")
                return;
            try
            {
                tablo = Convert.ToDouble(result.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невиконувана операція", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result.Text = "0";
                return;
            }
            switch (oper)
            {
                case "sqrt":
                    if (tablo < 0)
                    {
                        MessageBox.Show("Невиконувана операція", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result.Text = "0";
                        return;
                    }
                    tablo = Math.Sqrt(tablo);
                    break;
                case "%":
                    tablo *= 0.01;
                    break;
                case "1/x":
                    if (tablo == 0)
                    {
                        MessageBox.Show("Невиконувана операція : Ділення на нуль", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = 1 / tablo;
                    break;
                case "+/-":
                    tablo *= -1;
                    break;
                case "Pi":
                    {
                        tablo = Math.PI;
                        break;
                    }
                case "sinx":
                    {
                        tablo = Math.Sin(tablo);
                        break;
                    }
                case "cosX":
                    {
                        tablo = Math.Cos(tablo);
                        break;
                    }
                case "| |":
                    {
                        tablo = Math.Abs(tablo);
                        break;
                    }
            }
            result.Text = tablo.ToString();
            Memory = true;
        }

        private void runOperationMemory()
        {
            double Tablo, Memor;
            if (operation == "")
                return;
            try
            {
                Tablo = Convert.ToDouble(result.Text);
                Memor = Convert.ToDouble(TabloMemory.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невиконувана операція", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result.Text = TabloMemory.Text = "0";
                return;
            }
            switch (operation)
            {
                case "+":
                    Tablo += Memor;
                    Memor = Tablo;
                    break;
                case "-":
                    Tablo = Memor - Tablo;
                    Memor = Tablo;
                    break;
                case "*":
                    Tablo *= Memor;
                    Memor = Tablo;
                    break;
                case "/":
                    if (Tablo == 0)
                    {
                        MessageBox.Show("Невиконувана операція : Ділення на нуль", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Tablo = Memor / Tablo;
                    Memor = Tablo;
                    break;
                case "M+":
                    Memor += Tablo;
                    break;
                case "M-":
                    Memor -= Tablo;
                    break;
                case "MC":
                    Memor = 0;
                    break;
                case "MR":
                    Tablo = Memor;
                    break;
                case "MT":
                    Memor = Tablo;
                    break;
                case "C":
                    Tablo = 0;
                    Memor = 0;
                    break;
            }
            operation = "";
            result.Text = Tablo.ToString();
            TabloMemory.Text = Memor.ToString();
            Memory = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            plustablo('0');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            plustablo('1');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            plustablo('2');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            plustablo('3');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            plustablo('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            plustablo('5');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plustablo('6');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plustablo('7');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plustablo('8');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plustablo('9');
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "C";
            runOperationMemory();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Memory)
                result.Text = "0";
            bool available = false;
            int i, len;
            len = result.Text.Length;
            for (i = 0; i < len; i++)
                if (result.Text[i] == ',')
                {
                    available = true;
                    break;
                }
            if (!available)
                result.Text += ",";
            Memory = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Memory)
                result.Text = "0";
            else
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            if (result.Text == "")
                result.Text = "0";
            Memory = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "*";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
            operation = "/";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            runOperationTablo("sqrt");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            runOperationTablo("%");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            runOperationTablo("1/x");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            runOperationTablo("Pi");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            runOperationTablo("+/-");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            runOperationTablo("sinx");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "M-";
            runOperationMemory();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "M+";
            runOperationMemory();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MC";
            runOperationMemory();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MR";
            runOperationMemory();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            runOperationMemory();
            operation = "MT";
            runOperationMemory();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Button30_Click(object sender, EventArgs e)
        {
            runOperationTablo("cosX");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button31_Click(object sender, EventArgs e)
        {
            runOperationTablo("| |");
        }
    }
}
