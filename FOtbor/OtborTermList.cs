using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp8
{
    class OtborTermList : Papa
    {
        public static void MainOtborTermList()
        {
            List<string[]> arr = new List<string[]>();
            //string outText = "term;dep\n";

            SayCyan("\n Terminals cross spaces:\nmay only hvost from num dep:\n");
            string choise = Console.ReadLine();
            Say("");
            string[] choiseSplit = choise.Split(" ");
            if (choise.IndexOf(" ") < 0)
            {
                outText += choise + ";" + choise.Substring(0, 7) + "\n";
                arr.Add(outLine.Split(';'));
                goto LabelMe;
            }

            string nos = choiseSplit[0].Substring(0, 4);
            foreach (var term in choiseSplit)
            {
                string myTerm = term;
                if (term.Length < 8)
                {
                    myTerm = nos + term;
                }
                string dep = myTerm.Substring(0, 7);
                outLine = myTerm + ";" + dep;
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
