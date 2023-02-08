using Invi.Abilities.Base;
using System.IO;

namespace Invi.Abilities.JsonAbilities
{
    internal static class JsonReader
    {
        public static string Read(string path)
        {
            string text = "";

            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                using (var reader = new StreamReader(path))
                {
                    text = reader.ReadToEnd();
                }
            }
            else 
            {
                FileUtils.CreateFile(path);
            }

            return text;
        }
    }
}
