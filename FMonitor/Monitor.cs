using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Monitor : Papa
    {
        public static void MainMonitor()
        {
            #region
            string[] monitorDirs = File.ReadAllLines(dataConfigDirPath + "PathMonitor.txt");
            if (statusExit) goto LabelExit;

            string monitorOut = File.ReadAllLines(dataConfigDirPath + "PathMonitorOut.txt")[0];
            if (statusExit) goto LabelExit;

            foreach (string dir in monitorDirs)
            {

                Console.ForegroundColor = Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(dir);
                Mover(dir, monitorOut);
            }

        LabelExit:
            return;
            #endregion
        }

    }
}
