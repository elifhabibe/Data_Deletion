using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace deneme1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // start butonu
        {
            button3.Enabled = false;
            button1.Enabled = true;
            Scheduler scheduler = new Scheduler();
            scheduler.Start();


        }
       // string Secili_Klsaor_Yolu = "";
        private void button4_Click(object sender, EventArgs e) //arama butonu
        {

            FolderBrowserDialog Klasor = new FolderBrowserDialog();
            Klasor.ShowDialog();
          //  Secili_Klsaor_Yolu = Klasor.SelectedPath;
            textBox2.Text = Klasor.SelectedPath;
            
        }
        private void button3_Click(object sender, EventArgs e) //save butonu
        {
            //label4.Text= dateTimePicker1.Text;
            try
            {
                Registry.CurrentUser.CreateSubKey("deneme1"); //regedit alt klasör oluşturma
                //Registry.CurrentUser.CreateSubKey("deneme1").SetValue("date", dateTimePicker1.Text); //alt klasöre veri ekleme
                Registry.CurrentUser.CreateSubKey("deneme1").SetValue("file", textBox2.Text);
                Registry.CurrentUser.CreateSubKey("deneme1").SetValue("extension", textBox1.Text);
                label4.Text = "Kaydedildi";
                AnaFormuGuncelle();
            }
            catch (Exception ex)
            {

                label4.Text = "Bir sorun var. - " + ex.Message;
            }
          
            
        }

        private void button2_Click(object sender, EventArgs e) //stop butonu
        {
            button3.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AnaFormuGuncelle();

        }

        
        public void AnaFormuGuncelle()
        {
            // if (Registry.CurrentUser.OpenSubKey("deneme1").GetValue("file").ToString() != null)
            if (Registry.CurrentUser.OpenSubKey("deneme1") != null)
            {
               // dateTimePicker1.Text = Registry.CurrentUser.OpenSubKey("deneme1").GetValue("date").ToString();
                textBox2.Text = Registry.CurrentUser.OpenSubKey("deneme1").GetValue("file").ToString();
                textBox1.Text = Registry.CurrentUser.OpenSubKey("deneme1").GetValue("extension").ToString();
                label5.Text = Registry.CurrentUser.OpenSubKey("deneme1").GetValue("file").ToString();// regeditten veri okuma
            }
        }

        public void Calistir()
        {
            button3.Enabled = false;
            button1.Enabled = true;

            //string file = (textBox2.Text.Substring(3));
            //Directory.Delete("C:\\" + file);
            //MessageBox.Show(file);
            DirectoryInfo directory = new DirectoryInfo(Registry.CurrentUser.OpenSubKey("deneme1").GetValue("file").ToString());
            FileInfo[] Files = directory.GetFiles("*." + Registry.CurrentUser.OpenSubKey("deneme1").GetValue("extension").ToString());
            foreach (FileInfo file in Files)
            {
                // MessageBox.Show(file.Name + " - " + file.CreationTime.ToString());
                if (file.LastWriteTime < DateTime.Now.AddDays(-60))
                {
                    //MessageBox.Show(Convert.ToDateTime(Registry.CurrentUser.OpenSubKey("deneme1").GetValue("date")).ToString());
                    MessageBox.Show("Seçilen tarihden eskileri yakaladım." + file.CreationTime);
                    File.Delete(file.DirectoryName + "\\" + file.Name);

                }
                //DateTime baslangic = Convert.ToDateTime(Registry.CurrentUser.OpenSubKey("deneme1").GetValue("date"));
                //int res = DateTime.Compare(Convert.ToDateTime(Registry.CurrentUser.OpenSubKey("deneme1").GetValue("date")), file.CreationTime);
                //MessageBox.Show(res.ToString());

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
