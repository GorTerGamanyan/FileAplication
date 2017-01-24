using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DesctopManager
{
    public static class ScanFile
    {
        public static List<string> GetFileName(string path)
        {
            var scanList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var fi in di.GetDirectories())
            {
                scanList.Add(fi.Name);
            }
            foreach (var fi in di.GetFiles())
            {
                scanList.Add(fi.Name);
            }

            return scanList;
        }

        public static void RemoveUnnecessary(string path, string nameXmlFil)
        {
            var scanList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(path);
            var saveFileName = DeSerializeFromFile<List<string>>(nameXmlFil);

            foreach (var fi in di.GetFiles())
            {
                scanList.Add(fi.Name);
            }
            foreach (var fi in di.GetDirectories())
            {
                scanList.Add(fi.Name);
            }

            for (int i = scanList.Count - 1; i >= 0; i--)
            {
                foreach (var name2 in saveFileName)
                {

                    if (scanList.Count != 0 && scanList[i] == name2)
                    {
                        scanList.Remove(scanList[i]);
                        break;
                    }

                }
            }

            foreach (var item in scanList)
            {
                File.Delete(path + @"\" + item);
            }
        }

        public static void Serialize<T>(T source, string filename) where T : List<string>
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                serializer.Serialize(stream, source);
            }
        }

        public static T DeSerializeFromFile<T>(string filename) where T : List<string>
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    return (T)serializer.Deserialize(stream);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
