using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StatCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] _stringValues = textBox1.Text.Split(' ');
            int[] _intValues = new int[_stringValues.Length];
            for (int i = 0; i < _intValues.Length; ++i)
                _intValues[i] = int.Parse(_stringValues[i]);

            if (radioButton1.Checked)
            {
                double sum = 0.0;

                foreach (int v in _intValues)
                    sum += v;

                textBox2.Text = sum.ToString("F4");
            }

            else if (radioButton2.Checked)
            {
                double product = 1.0;

                foreach (int v in _intValues)
                    product *= (double)v;

                textBox2.Text = product.ToString("F4");
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}