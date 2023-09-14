using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2PAndExcelDataApp
{
    public class FileManager
    {
        public virtual string openDialog()
        {
            return null;
        }
        public virtual DataTable readFile(string path)
        {
            return null;
        }
        public virtual DataTable readFile(string path,string selectedSheetName)
        {
            return null;
        }
    }
}
