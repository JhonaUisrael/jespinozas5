using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace jespinozaS5.Helpers
{
    public class FileAccessHelper
    {
        public static string GetLocalPath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory,filename);
        }
    }
}
