using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invi.Abilities.Base
{
    public static class FileUtils
    {
        public static void CreateFile(string path)
        {
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
        }
    }
}
