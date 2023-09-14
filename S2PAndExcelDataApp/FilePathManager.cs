using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2PAndExcelDataApp
{
    public class FilePathManager
    {
        public FilePathManager()
        {
               
        }
        /**
         * @brief : Dosyayolundan dosya ismini dönderir.
         * 
         * @param : path:string, dosyayolu
         * 
         * @return : dosya ismi yada null
         */
        public string pathName(string path)
        {
            if (path != null)
            {
                return Path.GetFileNameWithoutExtension(path);
            }
            else
            {
                return null;
            }
        }
    }
}
