using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp8
{
    class Perevod : PeoplePapa
    {
        public static void MainPerevod()
        {
            outLine = "";
            outText = "";
            loginOk = false;

            colFioOne = 0;
            colFioTwo = 2;
            colLoginTwo = 0;
            colDepTwo = 3;
            colDepOne = 1;

            fierd = mkFierd();
            //myKassAll = mkKassAllShort();
            kassAllHash = MkKassAllHash();

            string fOutName = "OutPerevod.csv";
            string[] lines = FileToVec(dataInPath + "perevod.csv");

            string unfind = "";

            foreach (string line in lines)
            {
                workVec = line.Split(';');
                string myLogin = LoginSearchHash();
                //string myLogin = LoginSearchHash();
                if (!loginOk)
                {
                    unfind += workVec[0] + ";" + workVec[1] + ";" + workVec[2] + "\n";
                    continue;
                }
                else
                {
                    outText += myLogin + ";" + workVec[1] + ";" + workVec[2] + "\n";
                }


            }

            TextToFile(dataOutPath + fOutName, unfind + outText);
            SayBlue("\n\n" + outText + "\n");
            SayGreen(unfind + "\n");

            if (unfind != "") SayRed("\n\tBed\n");
            else SayYellow("\n\tWell\n");
            OpenNote(dataOutPath + fOutName);
        }

    }
}
