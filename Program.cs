using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp8
{
    class Program
    {


        public static void ClearScreen()
        {
            #region #ClearScreen
            Console.Clear();
            Console.WriteLine();
            #endregion
        }

        public static void Main(string[] args)
        {
            #region #Main

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //PgBase.TermFromFile();
            //PgBase.OtborFromFile();
            //PgBase.DepFromFile();
            //Console.ReadLine();
            //__________________

            /*
            Console.ForegroundColor = ConsoleColor.Black;
            string say = "";
            while (say != "123")
                say = Console.ReadLine();

            Console.WriteLine(" * C# designed by Alexei Zaigraev neya1969@gmail.com * ");
            */

            MenuMain();
            #endregion
        }

        public static void MenuMain()
        {
            #region #MenuMain
            Console.Clear();

            

            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine("\t\t\t\t\t * C# Alexei Zaigraev neya1969@gmail.com * ");


            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "People", new Papa.delegateMenu(MenuPeople) },
                { "Some", new Papa.delegateMenu(MenuSome) },
                { "Monitor", new Papa.delegateMenu(MenuMonitor) },
                { "Kabinet", new Papa.delegateMenu(MenuKabinet) },
                //{ "Doc", new Papa.delegateMenu(MenuDoc) },
                { "DataBase", new Papa.delegateMenu(MenuDb) }

            };
            do
            {
                Papa.MkMenu(Papa.delegateMenuDict);
            } while (true);
            
            #endregion
        }

        

       
        protected static void MenuPeople()
        {
            #region #MenuPeople
            Console.Clear();
            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "Priem", new Papa.delegateMenu(Priem.MainPriem) },
                { "Otpusk", new Papa.delegateMenu(Otpusk.MainOtpusk)},
                { "Perevod", new Papa.delegateMenu(Perevod.MainPerevod)},
                { "PostAll", new Papa.delegateMenu(PostAll.MainPostAll)}
            };
            do { Papa.MkMenu(Papa.delegateMenuDict); } while (true);
            #endregion
        }



        protected static void MenuSome()
        {
            #region #MenuSome
            Console.Clear();
            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "Terminals", new Papa.delegateMenu(Term.MainTerm) },
                {"Hr_Dep_Otbor", new Papa.delegateMenu(HrDep.MainHrDep) },
                { "Hr_dep_AB", new Papa.delegateMenu(HrDepAb.MainHrDepAb)},
                //{ "Site_Regimes", new Papa.delegateMenu(SiteNewRegimes.MainSiteRegimes) },
                { "Site", new Papa.delegateMenu(SiteNew.MainSiteNew) },
                {"Natasha", new Papa.delegateMenu(Natasha.MainNatasha) }

            };
            do { Papa.MkMenu(Papa.delegateMenuDict, 3); } while (true);
            #endregion
        }



        protected static void MenuMonitor()
        {
            #region #MenuMonitor
            Console.Clear();
            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "Walker", new Papa.delegateMenu(Rasklad.MainRasklad) },
                { "AccBack", new Papa.delegateMenu(AccBack.MainAccBack)},
                { "Monitor", new Papa.delegateMenu(Monitor.MainMonitor)},
                { "Get_RP_Otbor", new Papa.delegateMenu(GetRp.MainGetRp)},
                { "Get_RP_Agent", new Papa.delegateMenu(GetRpAll.MainGetRpAll)},
                { "Gnetz", new Papa.delegateMenu(Gnetz.MainGnetz)},
                { "GdrieBackUp", new Papa.delegateMenu(GdriveBackUp.MainGdriveBackUp)}
            };
            do { Papa.MkMenu(Papa.delegateMenuDict, 3); } while (true);
            #endregion
        }



        protected static void MenuKabinet()
        {
            #region
            Console.Clear();
            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "Rro", new Papa.delegateMenu(Rro.MainRro) },
                { "Pereezd", new Papa.delegateMenu(Pereezd.MainPereezd)},
                { "Otmena", new Papa.delegateMenu(Otmena.MainOtmena)},
                { "Prro", new Papa.delegateMenu(Prro.MainPrro)},
                { "Knigi", new Papa.delegateMenu(Knigi.MainKnigi)}
            };
            do { Papa.MkMenu(Papa.delegateMenuDict); } while (true);
            #endregion
        }


        protected static void MenuDb()
        {
            #region #MenuOtbor
            Console.Clear();
            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "Refresh", new Papa.delegateMenu(RefreshAll.MainRefreshAll) },
                { "Otbor_From_To_Deps", new Papa.delegateMenu(OtborDepFromTo.MainOtborDepFromTo) },
                { "Otbor_Dep_List", new Papa.delegateMenu(OtborDepList.MainOtborDepList) },
                { "Otbor_Term_List", new Papa.delegateMenu(OtborTermList.MainOtborTermList) }
            };
            do { Papa.MkMenu(Papa.delegateMenuDict); } while (true);
            #endregion
        }

        /*
        protected static void MenuDoc()
        {
            #region #MenuOtbor
            Console.Clear();
            Papa.delegateMenuDict = new Dictionary<string, Papa.delegateMenu>
            {
                { "Activaciya", new Papa.delegateMenu(Activaciya.MainActivaciya)},
                { "Act_Peredachi", new Papa.delegateMenu(ActPeredachi.MainActPeredachi) },
                { "Dep_To_File", new Papa.delegateMenu(DepToFile.MainDepToFile) },
                { "Term_To_File", new Papa.delegateMenu(TermToFile.MainTermToFile) },
                { "Logi_To_File", new Papa.delegateMenu(LogiToFile.MainLogiToFile) }
            };
            do { Papa.MkMenu(Papa.delegateMenuDict); } while (true);
            #endregion
        }
        */


        #region #Color Print
        internal static void pRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
        }

        internal static void pGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
        }

        internal static void pYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
        }

        internal static void pGray(string text)
        {

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
        }

        internal static void pDarkGray(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
        }

        internal static void pBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
        }

        internal static void pDarkBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(text);
        }

        internal static void pCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(text);
        }
        protected static void pMagenta(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
        }
        #endregion

    }
}
