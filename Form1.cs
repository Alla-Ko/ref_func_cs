using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_ref.Properties;

namespace WindowsFormsApp_ref
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += digitssonly_KeyPress;
            textBox5.KeyPress += textBox5_KeyPress;
            textBox6.KeyPress += textBox6_KeyPress;
            this.Icon = Resources.book_icon;

        }

        private void digitssonly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&e.KeyChar!=(char)Keys.Back) { e.Handled = true; }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString();
            if (Regex.IsMatch(str, @"^[-]?[\\d](0,6)"))
            {
                e.Handled = true;
            }
            if (textBox5.Text == "")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString();
            if (Regex.IsMatch(str, @"^[-]?[\\d](0,6)"))
            {
                e.Handled = true;
            }
            if (textBox6.Text == "")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int start = 0;
            int end = 0;
            Int32.TryParse(textBox5.Text, out start);
            Int32.TryParse(textBox6.Text, out end);
            if (end<start){
                textBox6.Text = start.ToString();
                    
            }
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int start = 0;
            int end = 0;
            Int32.TryParse(textBox5.Text, out start);
            Int32.TryParse(textBox6.Text, out end);
            if (end < start)
            {
                textBox5.Text = end.ToString();

            }
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

        }
        private void min_max(ref int[] mas, ref int min, ref int max)
        {
            min= 0;
            max= 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (i == 0)
                {
                    min = mas[i];
                    max = mas[i];
                }
                else
                {
                    if (mas[i] < min) min = mas[i];
                    if (mas[i] > max) max = mas[i];
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            int start = 0;
            int end = 0;
            int min = 0;
            int max = 0;
            
            Random rnd = new Random();
            if (Int32.TryParse(textBox1.Text, out n) && n > 0)
            {
                if (!Int32.TryParse(textBox5.Text, out start))
                    MessageBox.Show("Введіть нижню межу для чисел", "Повідомлення про помилку", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Int32.TryParse(textBox6.Text, out end);


                int[] mas = new int[n];
                for(int i = 0; i < n; i++)
                {
                    mas[i] = rnd.Next(start,end+1);
                    textBox2.Text += mas[i].ToString();
                    if (i < n - 1) textBox2.Text += "; ";
                
                }
                min_max(ref mas, ref min, ref max);
                textBox3.Text= min.ToString();
                textBox4.Text= max.ToString();
            }
            else MessageBox.Show("Введіть розмірність масиву більше 0!", "Повідомлення про помилку", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
