using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.TextChanged += textBox3_TextChanged;
            textBox4.TextChanged += textBox4_TextChanged;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Text = "Введите натуральное число";
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "Введите натуральное загаданное число";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox3.Text;
            int n;
            int cnt = 0;
            try
            {
                n = Int32.Parse(input);
                while (n>0)
                {
                    int tmp = n % 10;
                    if (tmp % 2 == 0 && tmp != 0)
                        cnt++;
                    n /= 10;
                }
                textBox1.Text = cnt.ToString();
            }
            catch (FormatException)
            {
                label4.Text = "Ошибка ввода, повторите снова";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input1 = textBox3.Text;
            int n1;
            string input = textBox4.Text;
            int n;
            int cnt = 0;
            try
            {
                n1 = Int32.Parse(input1);
                n = Int32.Parse(input);
                for(int i =0; i < input1.Length; i++)      
                {
                    string tmp = input1[i].ToString();
                    if (String.Compare(tmp, input)==0){
                        cnt++;
                    }
                }
                if(cnt >= 2)
                {
                    textBox2.Text = "ДА - вот столько раз " + cnt.ToString();
                    textBox2.BackColor = Color.Green;
                }
                else
                {
                    textBox2.Text = "НЕТ";
                    textBox2.BackColor = Color.Red;
                }
               
            }
            catch (FormatException)
            {
                label4.Text = "Ошибка ввода, повторите снова";
                label5.Text = "Ошибка ввода, повторите снова";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<int> mas = new List<int>();
            for(int i = 1000; i<=9999; i++)
            {
                int tmp1 = i % 10;
                int tmp2 = (i % 100) / 10;
                int tmp3 = (i % 1000) / 100;
                if(tmp1+tmp2 == tmp2 + tmp3)
                {
                    if (i % 6 == 0 && i % 27 == 0) mas.Add(i);
                }
            }
            if (mas.Count != 0) {
                textBox5.Text = "";
                for (int i = 0; i < mas.Count; i++)
                {
                    textBox5.Text = textBox5.Text + mas[i].ToString() +", ";
                }
            }
        }
    }
}
