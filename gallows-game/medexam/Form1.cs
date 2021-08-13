using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medexam
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black, 4);
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
     static   Random r = new Random();
        String temp = "";
        String word = "";
         int xr = r.Next(1000);
        string allword = "";
        string[] arrword=new string[10000];
        int gusscount = 8;
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlf = new OpenFileDialog();
            openFileDialog1.Filter = "TEXT FILE|*.txt";
            if (dlf.ShowDialog() == DialogResult.OK) {

                StreamReader file = new StreamReader(dlf.FileName);
                allword = file.ReadToEnd();
                arrword = allword.Split(new char[] { ' ', '\t', '\n', '\r' });
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {if (allword == "") return;
            textBox4.ReadOnly = false;
            textBox4.Enabled = true;
            button1.Enabled = true;
            textBox2.Text = arrword[xr].Length.ToString();
            word = arrword[xr];
            temp = word;
            for (int i = 0; i < arrword[xr].Length; i++)
                textBox1.AppendText("_ ");
            textBox3.Text = "8";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
           
        {
            
            if (word.Contains(textBox4.Text))
            {
                for (int i = 0; i < word.Length; i++) {
                    if (word[i] == textBox4.Text[0])
                    {
                      word=  word.Remove(i,1);
                        textBox1.Text =textBox1.Text.Remove(i,1);
                        textBox1.Text =textBox1.Text.Insert(i, textBox4.Text);
                        break;
                    }
                }
                if (word=="") { MessageBox.Show("you have won ^_^  ");Application.Exit(); }

            }
            else
            {
                

                textBox3.Text = gusscount.ToString();
                switch (gusscount) {

                    case 8:drawTwoLines();break;
                    case 7: drawLine(); break;
                    case 6: drawFace(); break;
                    case 5: drawBody(); break;
                    case 4: drawFirstHand(); break;
                    case 3: drawSecondHand(); break;
                    case 2: drawFirstLeg(); break;
                    case 1: drawSecondLeg();MessageBox.Show("you are a loser my frined"+" the word is "+temp);Application.Exit();
                        break;
                        
                }
                gusscount--;
                textBox5.Text += "  "+textBox4.Text;
            }

           
            textBox3.Text = gusscount.ToString();
            textBox4.Text = "";
        }
        void drawTwoLines()
        {


            g.DrawLine(pen, panel1.Width, 0, panel1.Width, panel1.Height);
            g.DrawLine(pen, 0, 0, panel1.Width, 0);
        }
        void drawLine()
        {
            g.DrawLine(pen, 90, 0, 90, 70);

        }
        void drawFace()
        {
            g.DrawEllipse(pen, 50, 70, 80, 80);
            g.DrawEllipse(pen, 70, 90, 4, 4);
            g.DrawEllipse(pen, 108, 90, 4, 4);
            g.DrawLine(pen, 70, 120, 115, 120);

        }
        void drawBody()
        {
            g.DrawLine(pen, 91, 150, 91, 320);

        }
        void drawFirstHand()
        {
            g.DrawLine(pen, 40, 180, 91, 180);
        }
        void drawSecondHand()
        {
            g.DrawLine(pen, 91, 180, 142, 180);
        }
        void drawSecondLeg()
        {
            g.DrawLine(pen, 91, 318, 142, 370);
        }
        void drawFirstLeg()
        {
            g.DrawLine(pen, 91, 318, 40, 370);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
