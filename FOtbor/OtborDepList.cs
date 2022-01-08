using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp8
{
    class OtborDepList : Papa
    {
        public static void MainOtborDepList()
        {
            List<string[]> arr = new List<string[]>();
            //string outText = "term;dep\n";

            SayCyan("\n Deps cross spaces:\nmay only hvost\nstart from num dep:\n");
            string choise = Console.ReadLine();
            Say("");
            string[] choiseSplit = choise.Split(' ');
            if (choise.IndexOf(' ') < 0)
            {
                outLine = $"{choise}1;{choise}";
                arr.Add(outLine.Split(';'));
                goto LabelMe;
            }

            string nos = choiseSplit[0].Substring(0, 4);
            foreach (string depdep in choiseSplit)
            {
                string myDep = depdep;
                if (depdep.Length < 7)
                {
                    myDep = nos + depdep;
                }
                string term = myDep + "1";
                outLine = term + ";" + myDep;
                arr.Add(outLine.Split(';'));

                pBlue(outLine);
            }

        LabelMe:


            //TextToFile(Path.Combine(dataInPath, "otbor.csv"), outText);

            DbOtborMet.AddManyOtbor(arr);
            //SayGreen(outText);
        }

    }
}
