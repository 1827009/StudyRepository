using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace datadrivenTest.GameOctopus
{
    class Utility
    {
        /// <summary>
        /// svcファイル読み出し。アクセスはすべて文字列
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string>> ReadCSV(string file)
        {
            List<List<string>> list = new List<List<string>>();
            
            StreamReader streamReader = new StreamReader(file);
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] values = line.Split(",");

                list.Add(new List<string>(values));
            }

            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
            for (int i = 1; i < list.Count; i++)
            {
                Dictionary<string, string> dc = new Dictionary<string, string>();
                for (int j = 1; j < list[0].Count; j++)
                {
                    dc.Add(list[0][j], list[i][j]);
                }
                result.Add(list[i][0], dc);
            }

            return result;
        }
    }
}
