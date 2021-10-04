using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.a.ToString();
            textBox2.Text = Properties.Settings.Default.nums3.ToString();
            textBox3.Text = Properties.Settings.Default.s1.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                int a;
                try
                {
                   
                    a = int.Parse(this.textBox1.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var max = Logic.Compare(a);

                if (max == int.MinValue)
                {
                    MessageBox.Show("Введите правильное значение");
                }
                else
                {
                    MessageBox.Show("Наибольшая цифра:"+ Logic.Compare(a));

                }


            }
       

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int[] nums3;
                try
                {
                string[] strArr3 = textBox2.Text.Split(" ");
                nums3 = strArr3.Select(x => int.Parse(x)).ToArray();
            }
            catch (FormatException)
                {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var outMessage = Logic2.Compare2(nums3);

                
                    MessageBox.Show(outMessage);
                

         /*   {
                int[] nums3 = new int[] { -1, -5, -6, -4, -10 };
                Console.WriteLine("Числовой ряд ");
                for (int i = 1; i < nums3.Length; i++)
                {
                    Console.Write(nums3[i] + " ");
                }
                Console.WriteLine(" ");



                var outMessage = Logic.Compare(nums3);


                Console.WriteLine(outMessage);
            }
         */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = "";

            try
            {
                var s2 = textBox3.Text;
                s1 = s2;

            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var outMessage = Logic3.Amount(s1);

            MessageBox.Show(outMessage);


        }
    }
    public class Logic
    {


        public static int Compare(int a)
        {

            if (((a > 99) && (a < 1000)) || ((a < -99) && (a > -1000)))
            {
                int b = a % 10;
                int c = a / 10 % 10;
                int max = int.MinValue;
                a = a / 100;
                if (b < 0)
                {
                    b = b * -1;
                }
                if (c < 0)
                {
                    c = c * -1;
                }
                if (a > b)
                {
                    if (a > c)
                    {
                        { max = a; }
                    }
                    else { max = c; }
                }
                else if (b > c)
                {
                    max = b;
                }
                else { max = c; }
                return max;
            }

            else
            {
                return int.MinValue;
            }

        }

       
    }

    public class Logic2
    {
        public static string Compare2(int[] nums3)
        {
            string outMessage = "";
            int plus = 0;
            int sign = 0;
            for (int i = 1; i < nums3.Length; i++)
            {
                sign = nums3[0];
                if (((nums3[i] > 0) && (nums3[i - 1] < 0)) || (nums3[i] < 0) && (nums3[i - 1] > 0))
                {
                    plus++;
                }
            }
            if (plus == 0)
            {
                if (sign < 0)
                {
                    outMessage = "Числа всегда отрицательные";
                }
                if (sign > 0)
                {
                    outMessage = "Числа всегда положительные";
                }

            }
            else
                outMessage = plus.ToString();


            return outMessage;
        }

    }

    public class Logic3
    {
        public static string Amount(string s1)
        {
            string outMessage = "";
            s1 = s1.ToLower();

            StringBuilder sb = new StringBuilder( s1);
            int sum = 1;
            double num = 0;
            int i, j;
            for (i = 0; i < sb.Length; i++)
            {
                if ((sb[i] >= 'a' && sb[i] <= 'z') || (sb[i] >= 'а' && sb[i] <= 'я'))
                {
                    num++;
                }

            }

            if (num == 0)
            {
                outMessage = "Введены цифры или другие символы";

            }
            else
            {

                for (i = 0; i < sb.Length; i++)

                {

                    if ((sb[i] >= 'a' && sb[i] <= 'z') || (sb[i] >= 'а' && sb[i] <= 'я'))
                    {
                        for (j = 1; j < sb.Length; j++)
                        {
                            if ((sb[i] == sb[j]) && (i != j))
                            {
                                sb[j] = ' ';
                                sum++;
                            }
                        }
                        string s2 = sb[i].ToString();
                        outMessage += $"{s2} ={Math.Round(sum / num * 100, 2)}%; ";
                        sum = 1;


                    }

                }
            }
            return outMessage;

        }


    }


}
