using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class RefreshAll : Papa
    {
        internal static void MainRefreshAll()
        {
            try
            {
                Process proc = new Process();

                proc.StartInfo.FileName = @"C:\SharpForPy\SharpForPy.exe"; proc.Start();
                proc.WaitForExit();
            }
            catch { }

            DbOtborMet.RefreshOtborFromFile();
            Say("otbor refreshed");
            DbDepMeth.RefreshDepartment();
            Say("dep refreshed");
            DbTermMeth.RefreshTerminal();
            Say("term refreshed");
            Say("\n\tall refreshed");
        }
    }
}
