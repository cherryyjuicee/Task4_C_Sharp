using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tassk4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //условие если не заполнено или заполнено неправильно

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите значения!");
            }
            else
            {
                try
                {
                Cabel cb1 = new Cabel(textBox1.Text, int.Parse(textBox2.Text), float.Parse(textBox3.Text));
                textBox5.Text = cb1.Q().ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введен неверный формат");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите значения!");
            }
            else
            {
                try
                {
                    ModifyCabel cb1 = new ModifyCabel(textBox1.Text, int.Parse(textBox2.Text), float.Parse(textBox3.Text), radioButton1.Checked);
                    textBox6.Text = cb1.Qp().ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введен неверный формат");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите значения!");
            }
            else
            {
                try
                {
                    Cabel cb1 = new Cabel(textBox1.Text, int.Parse(textBox2.Text), float.Parse(textBox3.Text));
                    textBox7.Text = cb1.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введен неверный формат");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите значения!");
            }
            else
            {
                try
                {

                    ModifyCabel cb1 = new ModifyCabel(textBox1.Text, int.Parse(textBox2.Text), float.Parse(textBox3.Text), radioButton1.Checked);
                    textBox8.Text = cb1.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введен неверный формат");
                }
            }
        }
    }

    class Cabel
    {
        protected string type;
        protected int countOfJils;
        protected float diametr;
        public Cabel(string type, int countOfJils, float diametr)
        {
            this.type = type;
            this.countOfJils = countOfJils;
            this.diametr = diametr;
        }

        public float Q()
        {
            return this.diametr / this.countOfJils;
        }

        public override string ToString()
        {
            return $@"Кабель. Тип {this.type}, Количество жил {this.countOfJils}, Диаметр {this.diametr}";
        }
    }

    class ModifyCabel : Cabel
    {
        private bool hasOpletka;

        public ModifyCabel(string type, int countOfJils, float diametr, bool hasOpletka)
            : base(type, countOfJils, diametr)
        {
            this.hasOpletka = hasOpletka;
        }

        public float Qp()
        {
            if (this.hasOpletka)
            {
                return this.Q() * 2;
            }
            else
            {
                return this.Q() * 0.7f;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $@", есть оплетка {this.hasOpletka}";
        }
    }
}
