using System;
using System.IO;

namespace FileCopyTool
{
    public class CopyAnotherComputer
    {
        /// <summary>
        /// Seçilen klasördeki ve uzantıdaki dosyaları hedef bilgisayara kopyalar.
        /// </summary>
        /// <param name="Source">Kopyalanacak dosyaların bulunduğu klasör</param>
        /// <param name="FileType">Dosyanın uzantısı</param>
        /// <param name="Destination">Kopyalanacak hedef makina</param>
        /// <returns></returns>
        public string CopyFile(string Source, string FileName, string Destination)
        {
            try
            {
                File.Copy(Source, @"\\"+Destination+"\\"+FileName,true);
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
            return "OK";
        }

        /// <summary>
        /// Seçilen hedefteki dosyaların listesini döndürür.
        /// </summary>
        /// <param name="Destination">Hedef dizin</param>
        /// <returns></returns>

        public string[] GetFiles(string Destination)
        {
            string[] fileEntries = Directory.GetFiles(Destination);
            return fileEntries;
        }
    }
}
