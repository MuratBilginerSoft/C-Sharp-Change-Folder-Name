using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace MB_Klasör_Adı_Değiştirme_v1._0
{
    public partial class Form1 : Form
    {

        #region Metodlar

        #endregion

        #region Tanımlamalar

        DirectoryInfo klasörbilgisi,klasörbilgisi2;
        DirectoryInfo[] klasöradı,klasöradı2;
        string[] kelimeler,kelimeler2;
        #endregion

        #region Değişkenler

        string klasöryolu,klasöryolu2, ilkharf, tümkelime, kelime1;
        int a;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            klasöryolu = textBox1.Text;
            a = int.Parse(textBox2.Text);
            klasörbilgisi2 = new DirectoryInfo(klasöryolu);
            klasöradı2 = klasörbilgisi2.GetDirectories();

            for (int k = 0; k < klasöradı2.Length; k++)
            {

                kelimeler2 = klasöradı2[k].ToString().Split(' ');

                tümkelime = "";

                for (int l = 0; l < kelimeler2.Length; l++)
                {
                    kelime1 = kelimeler2[l].ToLower();

                    ilkharf = kelime1[0].ToString().ToUpper();

                    if (tümkelime == "")
                    {
                        tümkelime = ilkharf;
                    }

                    else
                    {
                        tümkelime += " " + ilkharf;
                    }

                    for (int d = 1; d < kelime1.Length; d++)
                    {
                        tümkelime = tümkelime + kelime1[d];
                    }

                }

                Directory.Move(klasöryolu + "\\" + klasöradı2[k], klasöryolu + "\\" + a + " " + tümkelime);

                a++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            klasöryolu2 = textBox3.Text;
            klasörbilgisi = new DirectoryInfo(klasöryolu2);
            klasöradı = klasörbilgisi.GetDirectories();

            for (int i = 0; i < klasöradı.Length; i++)
            {
                kelimeler=klasöradı[i].ToString().Split(' ');

                tümkelime = kelimeler[1].ToString();

                for (int j = 2; j < kelimeler.Length; j++)
                {
                    tümkelime += " " + kelimeler[j];

                }

                Directory.Move(klasöryolu2 + "\\" + klasöradı[i], klasöryolu2 + "\\" + tümkelime);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}