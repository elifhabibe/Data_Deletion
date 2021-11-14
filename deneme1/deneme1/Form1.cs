using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme1
{
    public partial class Form1 : Form
    {
        bool control;
        int menu_width;
        public Form1()
        {
            InitializeComponent();
            control = false;
            menu_width = panel2.Width;
        }

       private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 delete = new Form2();
            delete.MdiParent = this;
            delete.Show();
                
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (control) 
            {
                panel2.Width = panel2.Width + 10;
                if (panel2.Width>= menu_width)
                {
                    timer1.Stop();
                    control = false;
                    this.Refresh();
                }
            }
            else
                panel2.Width = panel2.Width - 10;
            {
            if(panel2.Width<=0)
                {
                    timer1.Stop();
                    control = true;
                    this.Refresh();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 backup = new Form3();
            backup.MdiParent = this;
            backup.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
