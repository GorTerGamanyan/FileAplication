using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopManager
{
    public static class ScanFile
    {
        public static List<string> GetFileName(string path)
        {
            var scanList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\admin\Desktop\temp1");

            foreach (var fi in di.GetFiles())
            {
                scanList.Add(fi.Name);
            }

            return scanList;
        }

        public static void RemoveUnnecessary(string path, List<string> saveFileName)
        {
            var scanList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(path);


            foreach (var fi in di.GetFiles())
            {
                scanList.Add(fi.Name);
            }

            for (int i = scanList.Count - 1; i >= 0; i--)
            {
                foreach (var name2 in saveFileName)
                {
                    if (scanList[i] == name2)
                    {
                        scanList.Remove(scanList[i]);
                    }
                }
            }

            foreach (var item in scanList)
            {
                File.Delete(path + @"\" + item);
            }
        }
    }
}
