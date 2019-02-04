using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace noskhe_drugstore_app.Login
{
    class AppData
    {
        public bool SaveData(string Username , string Password)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Data.nos"))
                {
                    file.WriteLine(string.Format("{0}\r\n{1}", Username, Password));
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }            
        }
        public string[] ReadData()
        {
            string[] data = new string[2];
            try
            {                
                var fileStream = new FileStream("Data.nos", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    data[0] = streamReader.ReadLine();
                    data[1] = streamReader.ReadLine();
                }
                return data;
            }
            catch (Exception)
            {
                return data;
            }

        }
        public bool IsNOtExist()
        {
            if (File.Exists("Data.nos"))
                return false;
            else
                return true;
        }
    }
}
