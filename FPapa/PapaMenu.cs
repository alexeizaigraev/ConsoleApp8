using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    partial class Papa : Program
    {
        public delegate void delegateMenu();
        public static Dictionary<string, delegateMenu> delegateMenuDict = new Dictionary<string, delegateMenu>();
        public static void MkMenu(Dictionary<string, delegateMenu> delegateMenuDict)
        {
            #region
            try
            {
                //Console.Clear();
                SayBlue("\n\n\n");
                int count = 1;
                List<string> menuArr = new List<string>();
                foreach (var item in delegateMenuDict.Keys) menuArr.Add(item);

                foreach (string point in menuArr)
                {
                    if (count == delegateMenuDict.Count) SayGreen("\t" + count + " " + point + "\t");
                    else SayBlue("\t" + count + " " + point + "\t");
                    count += 1;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n -> ");
                string input = Console.ReadLine();
                if ("0" == input)
                    System.Environment.Exit(0);
                var ind = Convert.ToInt32(input);
                string keyChoised = menuArr[ind - 1];

                Console.Clear();
                Console.WriteLine("\n\n\n");
                delegateMenuDict[keyChoised]();
            }
            catch { MenuMain(); }
            #endregion
        }


        public static void MkMenu(Dictionary<string, delegateMenu> delegateMenuDict, int paint)
        {
            #region
            try
            {
                //Console.Clear();
                SayBlue("\n\n\n");
                int count = 1;
                List<string> menuArr = new List<string>();
                foreach (var item in delegateMenuDict.Keys) menuArr.Add(item);

                foreach (string point in menuArr)
                {
                    if (count == paint) SayGreen("\t" + count + " " + point + "\t");
                    else SayBlue("\t" + count + " " + point + "\t");
                    count += 1;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n -> ");

                string input = Console.ReadLine();
                if ("0" == input)
                    System.Environment.Exit(0);
                var ind = Convert.ToInt32(input);
                string keyChoised = menuArr[ind - 1];

                Console.Clear();
                Console.WriteLine("\n\n\n");
                delegateMenuDict[keyChoised]();
            }
            catch { MenuMain(); }
            #endregion
        }


        public static string Ask(List<string> points)
        {
            #region
            //Console.Clear();
            string choise = "";
            try
            {
                SayBlue("\n\n\n");
                int count = 1;

                foreach (string point in points)
                {
                    SayCyan("\t" + count + " " + point + "\t");
                    count += 1;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n -> ");

                string input = Console.ReadLine();
                if ("0" == input)
                    System.Environment.Exit(0);
                var ind = Convert.ToInt32(input);
                choise = points[ind - 1];

            }
            catch { }
            //catch { MenuMain(); }
            Console.Clear();
            Console.WriteLine("\n\n\n");
            return choise;
            #endregion
        }



    }
}
