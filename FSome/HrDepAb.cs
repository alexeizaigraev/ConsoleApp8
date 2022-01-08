using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class HrDepAb : Papa
    {
        static SortedDictionary<string, int> dictSum = new SortedDictionary<string, int>();
        static Dictionary<string, List<string[]>> sprDict = new Dictionary<string, List<string[]>>();
        public static void MainHrDepAb()
        {
            #region
            var natasha = MkNatasha();
            string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Адреса;Партнер\n";
            var data = GetSummuryAbData();
            var sizeLine = data[0].Count;


            int count = 0;
            foreach (var u in data)
            {
                try
                {
                    if (u[0] == "" || natasha.IndexOf(u[0]) < 0) continue;

                    count++;
                    string outLine = String.Format("{0}", count) + ";"
                            + u[0] + ";" + u[1] + ";" + u[2];

                    outText += outLine + "\n";
                }
                catch (Exception ex) { SayRed(ex.Message); }
                
            }

            string oFname = dataOutPath + "summury_ab.csv";
            SayGreen($"\n\n\tsumm {count}\n");
            TextToFile(oFname, outText);
            //OpenNote(oFname);
            #endregion
        }

        internal static List<List<string>> GetSummuryAbData()
        {
            #region
            List<List<string>> outList = new List<List<string>>();
            using (var context = new postgresContext())
            {
                var department = context.Departments;
                var terminal = context.Terminals;
                var otbor = context.Otbors;
                var w = department.ToList();

                var lingVar = from dep in department
                              select
                              new
                              {
                                  dep = dep.Department1,
                                  adres = dep.Address,
                                  partner = dep.Partner
                              };

                foreach (var line in lingVar)
                {

                    List<string> lineList = new List<string>();
                    lineList.Add(line.dep);
                    lineList.Add(line.adres);
                    lineList.Add(line.partner);

                    outList.Add(lineList);
                }

            }
            return outList;
            #endregion
        }

    }
}
