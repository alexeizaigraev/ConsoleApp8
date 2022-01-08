using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp8
{
    class Otpusk : PeoplePapa
    {
        public static void MainOtpusk()
        {
            outLine = "";
            outText = "";
            loginOk = false;

            colFioOne = 0;
            colFioTwo = 2;
            colLoginTwo = 0;
            colDepTwo = 3;
            colDepOne = 3;

            fierd = mkFierd();
            //myKassAll = mkKassAllShort();
            kassAllHash = MkKassAllHash();
            string unfind = "";


            string fOutName = "OutOtpuskUvol.csv";
            string[] lines = FileToVec(dataInPath + "otpusk_uvol.csv");
            foreach (string line in lines)
            {
                workVec = line.Split(';');
                string myLogin = LoginSearchHash();
                //string myLogin = LoginSearchHash();
                if (!loginOk)
                {
                    unfind += workVec[0] + "\t" + workVec[3] + "\t" + ";" + Dates() + "\n";
                    continue;
                }
                else
                {
                    outText += myLogin + ";" + Dates() + "\n";
                }
            }


            TextToFile(dataOutPath + fOutName, unfind + outText);

            if (unfind != "")
            {
                SayRed("\n\tBed\n");
                OpenNote(dataOutPath + fOutName);
            }
            else SayYellow("\n\tWell\n");
        }

        private static List<string> MkGoodArr(string[] arr)
        {
            List<string> outList = new List<string>();
            foreach (string el in arr)
            {
                if (el.IndexOf('№') > -1)
                    outList.Add(el);
            }
            return outList;
        }



        static string Dates()
        {
            string datesOut;
            string status;
            if (workVec[2] == "") status = "uvolnenie";
            else status = "otpusk";

            int colStart = 1;
            int colFinish = 2;

            if (workVec[colStart].Length != 10
                || (workVec[colStart].IndexOf('.') == workVec[colStart].LastIndexOf('.')))
                Sos("Error first date", String.Join(" ", workVec));

            if (status == "otpusk")
            {
                if (workVec[colFinish].Length != 10
                || (workVec[colFinish].IndexOf('.') == workVec[colFinish].LastIndexOf('.')))
                    Sos("Error second date", workVec[colFinish]);

                string[] dateStartOtpusk0 = workVec[colStart].Split('.');
                string dd = dateStartOtpusk0[0];
                string mm = dateStartOtpusk0[1];
                string yy = dateStartOtpusk0[2];

                string dateStartOtpusk = yy + "-"
                    + mm + "-" + dd + " "
                    + "00:00:01";

                string[] dateFinishOtpusk0 = workVec[colFinish].Split('.');
                string dd2 = dateFinishOtpusk0[0];
                string mm2 = dateFinishOtpusk0[1];
                string yy2 = dateFinishOtpusk0[2];
                string dateFinishOtpusk = yy2 + "-"
                    + mm2 + "-" + dd2 + " "
                    + "23:59:59";

                string dateActiveStart = "2021-01-01 00:00:01";
                string dateActiveFinish = "2051-01-01 00:00:01";

                datesOut = dateStartOtpusk + ";"
                    + dateFinishOtpusk + ";"
                    + "" + ";"
                    + dateActiveStart + ";"
                    + dateActiveFinish;
                return datesOut;
            }

            if (status == "uvolnenie")
            {
                if (workVec[colStart].Length != 10
                || (workVec[colStart].IndexOf('.') == workVec[colStart].LastIndexOf('.')))
                    Sos("Error first date", workVec[colStart]);

                string dateStartOtpusk = "";
                string dateFinishOtpusk = "";

                string[] dateUvol0 = workVec[colStart].Split('.');
                string dd = dateUvol0[0];
                string mm = dateUvol0[1];
                string yy = dateUvol0[2];

                string dateUvol = yy + "-" + mm + "-" + dd
                    + " " + "23:59:59";
                string dateActiveStart = "2021-01-01 00:00:01";
                string dateActiveFinish = dateUvol;

                datesOut = dateStartOtpusk + ";"
                    + dateFinishOtpusk + ";"
                    + dateUvol + ";"
                    + dateActiveStart + ";"
                    + dateActiveFinish;
                return datesOut;
            }
            return "BED_DATES";
        }

    }
}
