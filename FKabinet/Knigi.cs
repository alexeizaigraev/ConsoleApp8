﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Knigi : PapaKabinet
    {

        private static List<List<string>> GetKnigiData()
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
                              join term in terminal on dep.Department1 equals term.Department
                              join otb in otbor on term.Termial equals otb.Term
                              select
                              new
                              {
                                  fiscal = term.FiscalNumber,
                                  model = term.Model,
                                  serial = term.SerialNumber,
                                  soft = term.Soft,
                                  rne = term.RneRro,
                                  dep = term.Department,
                                  adres = dep.Address,
                                  koatu = dep.Koatu,
                                  taxId = dep.TaxId,
                                  oroNum = term.OroNumber,
                                  oroSerial = term.OroSerial,
                                  distrCity = dep.DistrictCity,
                                  city = dep.City,
                                  terminal = term.Termial,
                              };

                foreach (var line in lingVar)
                {

                    List<string> lineList = new List<string>();
                    lineList.Add(line.fiscal);
                    lineList.Add(line.model);
                    lineList.Add(line.serial);
                    lineList.Add(line.soft);
                    lineList.Add(line.rne);
                    lineList.Add(line.dep);
                    lineList.Add(line.adres);
                    lineList.Add(line.koatu);
                    lineList.Add(line.taxId);
                    lineList.Add(line.oroNum);
                    lineList.Add(line.oroSerial);
                    lineList.Add(line.distrCity);
                    lineList.Add(line.city);
                    lineList.Add(line.terminal);

                    outList.Add(lineList);
                }

            }
            return outList;
            #endregion
        }

        public static void MainKnigi()
        {
            List<List<string>> data = new List<List<string>>();
            data = GetKnigiData();
            //var data = AccBase.AccGetKabinetOtmenaData();

            foreach (var u in data)
            {
                string shablon = "<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"no\"?>\n" +
"<DECLAR xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"J1311304.xsd\">\n" +
    @"<DECLARHEAD>
        <TIN>40243180</TIN>
        <C_DOC>J13</C_DOC>
        <C_DOC_SUB>113</C_DOC_SUB>
        <C_DOC_VER>4</C_DOC_VER>
        <C_DOC_TYPE>0</C_DOC_TYPE>
        <C_DOC_CNT>51</C_DOC_CNT>
        <C_REG>26</C_REG>
        <C_RAJ>50</C_RAJ>
        <PERIOD_MONTH>12</PERIOD_MONTH>
        <PERIOD_TYPE>1</PERIOD_TYPE>
        <PERIOD_YEAR>2021</PERIOD_YEAR>
        <C_STI_ORIG>2650</C_STI_ORIG>
        <C_DOC_STAN>1</C_DOC_STAN>\n" +
        "<LINKED_DOCS xsi:nil=\"true\"/>" + @"
        <D_FILL>15122021</D_FILL>
        <SOFTWARE>CABINET 0.5.0</SOFTWARE>
    </DECLARHEAD>
  <DECLARBODY>
<HKORO>1</HKORO>
<HR>1</HR>
<HKSTI>2650</HKSTI>
<HSTI>ГОЛОВНЕ УПРАВЛІННЯ ДФС У М.КИЄВІ, ДПІ У ГОЛОСІЇВСЬКОМУ РАЙОНІ (ГОЛОСІЇВСЬКИЙ РАЙОН М.КИЄВА)</HSTI>
" + "<HNAME>ТОВАРИСТВО З ОБМЕЖЕНОЮ ВIДПОВIДАЛЬНIСТЮ \"ЕЛЕКТРУМ ПЕЙМЕНТ СІСТЕМ\"</HNAME>" + @"
<HTIN>40243180</HTIN>
<R0301G1S>" + u[0] + @"</R0301G1S>
<R0302G1>451</R0302G1>
<R0302G1S>" + u[1] + @"</R0302G1S>
<R0303G1S>" + u[2] + @"</R0303G1S>
<R0304G1>1255</R0304G1>
<R0304G1S>" + u[3] + @"</R0304G1S>
<R0307G1S>" + u[4] + @"</R0307G1S>
<R0401G1S>Відділення №" + u[5] + @"</R0401G1S>
<R0402G1S>" + u[6] + @"</R0402G1S>
<R0403G1>" + u[7] + @"</R0403G1>
<R0403G2>" + Koatu2.MkKoatuNew(u[11], u[12], u[7]) + @"</R0403G2>
<R0404G1S>" + u[8] + @"</R0404G1S>
<R0501G1>1035</R0501G1>
<R0501G1S>ГУ ДПС У КИЇВСЬКІЙ ОБЛАСТІ  (М.ФАСТІВ)</R0501G1S>
<R0601G1S>" + u[0] + @"р</R0601G1S>
<R0601G2S>" + u[9] + @"</R0601G2S>
<R0602G1S>" + u[10] + @"</R0602G1S>
<R0603G1>40</R0603G1>
<M01>1</M01>
<HKBOS>2903722436</HKBOS>
<HBOS>ПОЖАРСЬКИЙ ВЯЧЕСЛАВ ЮХИМОВИЧ</HBOS>
<HFILL>" + DateNow() + @"</HFILL>
</DECLARBODY>
</DECLAR>
";

                string ofname = kabinetPath + u[5] + "_knigi_" + u[2] + ".xml";
                TextToFileCP1251(ofname, shablon);
            }
            //Loger("knigi");
        }

    }
}
