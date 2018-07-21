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

namespace XnbConverter
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if( openFileDialog1.ShowDialog()==  DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach(var f in openFileDialog1.FileNames)
                {
                    if (Path.GetExtension(f).ToLower()==".xnb")
                    { 
                    listBox1.Items.Add(f);
                    label4.Text = Path.GetDirectoryName(f);
                    }
                }
            }                

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                label4.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            foreach (string f in listBox1.Items)
                l.Add(f);
            int format = radioButton1.Checked ? 0 : 1;

            using (var game = new Game1(l, format, label4.Text))
                game.Run();
        }
    }
}
