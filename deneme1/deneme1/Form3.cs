using FileCopyTool;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace deneme1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static void CopyDirectory(string SourceFolderPath, string TargetFolderPath)
        {
            String[] files;

            if (TargetFolderPath[TargetFolderPath.Length - 1] != Path.DirectorySeparatorChar)
            {
                TargetFolderPath += Path.DirectorySeparatorChar;
            }

            // parametre olarak verilen hedef dizin yok ise oluştur.
            if (!Directory.Exists(TargetFolderPath))
            {
                Directory.CreateDirectory(TargetFolderPath);
            }

            // kaynak dizindeki tüm alt dizin ve dosya adlarını al.
            files = Directory.GetFileSystemEntries(SourceFolderPath);

            foreach (string file in files)
            {
                // alt dizinler
                if (Directory.Exists(file))
                {
                    // metot öz yineleme (recursive) kullanarak kaynak dizinde dosya bulunduğu
                    // müddetçe dizindeki tüm dosyalar hedef dizine kopyalanmaya devam ediyor.
                    CopyDirectory(file, TargetFolderPath + Path.GetFileName(file));
                }

                // dizindeki dosyalar
                else
                {
                    File.Copy(file, TargetFolderPath + Path.GetFileName(file), true);

                }
                {

                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Klasor = new FolderBrowserDialog();
            Klasor.ShowDialog();
            //  Secili_Klsaor_Yolu = Klasor.SelectedPath;
            textBox2.Text = Klasor.SelectedPath;

        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            AnaFormuGuncelle();
        }
        public void AnaFormuGuncelle()
        {
            // if (Registry.CurrentUser.OpenSubKey("deneme1").GetValue("file").ToString() != null)
            if (Registry.CurrentUser.OpenSubKey("Backup") != null)
            {
                try
                {
                    // dateTimePicker1.Text = Registry.CurrentUser.OpenSubKey("deneme1").GetValue("date").ToString();
                    textBox2.Text = Registry.CurrentUser.OpenSubKey("Backup").GetValue("file").ToString();// regeditten veri okuma
                   
                    textBox3.Text = Registry.CurrentUser.OpenSubKey("Backup").GetValue("target").ToString();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("Backup"); //regedit alt klasör oluşturma
                //Registry.CurrentUser.CreateSubKey("deneme1").SetValue("date", dateTimePicker1.Text); //alt klasöre veri ekleme
                Registry.CurrentUser.CreateSubKey("Backup").SetValue("file", textBox2.Text);

                Registry.CurrentUser.CreateSubKey("Backup").SetValue("target", textBox3.Text);
                label4.Text = "Kaydedildi";
                AnaFormuGuncelle();
            }
            catch (Exception ex)
            {

                label4.Text = "Bir sorun var. - " + ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyAnotherComputer c = new CopyAnotherComputer();
            
            foreach (var file in c.GetFiles(textBox2.Text))
            {
                c.CopyFile(file.ToString(),Path.GetFileName(file), textBox3.Text);
            }

        }
    }
}

