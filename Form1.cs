using System;
using System.Collections.Generic;
using System.Collections;
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
                int lenght = input.Length;
                for(int i =0; i < input1.Length-lenght+1; i++)      
                {
                    string tmp = input1.Substring(i,lenght).Trim();
                    if (String.Compare(tmp, input.Trim())==0){
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
                int tmp0 = i / 1000;
                int tmp1 = i % 10;
                int tmp2 = (i % 100) / 10;
                int tmp3 = (i % 1000) / 100;
                if(tmp1+tmp0 == tmp2 + tmp3)
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox11.Text = "";
            List<bool> bits1 = new List<bool>();
            List<bool> bits2 = new List<bool>();
            List<bool> bits_res = new List<bool>();
            for (int i =0; i <textBox6.Text.Length; i++)
            {
                string tmp = textBox6.Text.Substring(i, 1).Trim();
                byte[] bytes1 = Encoding.ASCII.GetBytes(tmp);
                var bits = new BitArray(bytes1);

                for (int j = bits.Length - 1; j >= 0; j--)
                {
                    textBox8.Text += (bits[j] == true ? 1 : 0);
                    bits1.Add(bits[j]);
                }
                for (int j = 0; j < bits.Length; j++)
                {
                    //bits1.Add(bits[j]);
                }
                if (i!=textBox6.Text.Length-1) textBox8.Text += " ";
            }
            for (int i = 0; i < textBox7.Text.Length; i++)
            {
                string tmp = textBox7.Text.Substring(i, 1).Trim();
                byte[] bytes2 = Encoding.ASCII.GetBytes(tmp);
                var bits = new BitArray(bytes2);
                for (int j = bits.Length - 1; j >= 0; j--)
                {
                    textBox9.Text += (bits[j] == true ? 1 : 0);
                    bits2.Add(bits[j]);
                }
                for(int j =0; j <bits.Length; j++)
                {
                    //bits2.Add(bits[j]);
                }
                if (i != textBox7.Text.Length - 1) textBox9.Text += " ";
            }
            
            int lenght = 0;
            int sw = 0;
            if (bits1.Count > bits2.Count)
            {
                lenght = bits1.Count;
                sw = 1;
            }
            else
            {
                if (bits1.Count < bits2.Count)
                {
                    lenght = bits2.Count;
                    sw = 2;
                }
                else
                {
                    if (bits1.Count == bits2.Count)
                        lenght = bits1.Count;
                    sw = 3;
                }
            }

            switch (sw)
            {
                case 3:
                    for (int i = 0; i < lenght; i++)
                    {
                        bits_res.Add(bits1[i] | bits2[i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i < bits1.Count; i++)
                    {
                        bits_res.Add(bits1[i] | bits2[i]);
                    }
                    for (int i = bits1.Count; i < bits2.Count; i++)
                    {
                        bits_res.Add(bits2[i]);
                    }
                    break;
                case 1:
                    for (int i = 0; i < bits2.Count; i++)
                    {
                        bits_res.Add( bits1[i] | bits2[i]);
                    }
                    for (int i = bits2.Count; i < bits1.Count; i++)
                    {
                        bits_res.Add(bits1[i]);
                    }
                    break;
            }

            int cnt = 0;
            for (int i = 0; i < bits_res.Count; i++)
            {
                
                textBox10.Text += (bits_res[i] == true ? 1 : 0);
                cnt++;
                if(cnt==8)
                {
                    textBox10.Text += " ";
                    cnt = 0;
                }
            }
            cnt = 0;
            int[] bitss = new int[8];
            for(int i =0; i < bits_res.Count; i++)
            {
                bitss[cnt] = (bits_res[i]==true? 1:0);
                cnt++;
                if (cnt == 8)
                {
                    cnt = 0;
                    byte b = (byte)((bitss[0] << 7)
                                | (bitss[1] << 6)
                                | (bitss[2] << 5)
                                | (bitss[3] << 4)
                                | (bitss[4] << 3)
                                | (bitss[5] << 2)
                                | (bitss[6] << 1)
                                | (bitss[7] << 0));
                    textBox11.Text += ((char)b);
                    textBox11.Text += " ";
                }
                
            }
        }
    }
}
