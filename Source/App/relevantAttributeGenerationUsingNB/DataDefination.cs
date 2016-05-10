using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relevantAttributeGenerationUsingNB
{
    class DataDefination
    {
/*
@attribute DGN {DGN3,DGN2,DGN4,DGN6,DGN5,DGN8,DGN1}
@attribute PRE4 numeric
@attribute PRE5 numeric
@attribute PRE6 {PRZ2,PRZ1,PRZ0}
@attribute PRE7 {T,F}
@attribute PRE8 {T,F}
@attribute PRE9 {T,F}
@attribute PRE10 {T,F}
@attribute PRE11 {T,F}
@attribute PRE14 {OC11,OC14,OC12,OC13}
@attribute PRE17 {T,F}
@attribute PRE19 {T,F}
@attribute PRE25 {T,F}
@attribute PRE30 {T,F}
@attribute PRE32 {T,F}
@attribute AGE numeric
@attribute Risk1Yr {T,F}
*/


 private String[][] tableJaggedDataDefinationStr;

        private String trimBraces(String st)
        {
           int startIndex= st.IndexOf('{');
           int endIndex = st.IndexOf('}');
            startIndex = startIndex + 1;
           st = st.Substring(startIndex, endIndex - startIndex);
           return st;
        }
        
                public String[][] getAttributeDefination(string locationOfAttributeInfo)
                {

                    String[] lines = System.IO.File.ReadAllLines(locationOfAttributeInfo);
                    int tottalNumbeOfRaw = lines.Count();
                    tableJaggedDataDefinationStr = new string[tottalNumbeOfRaw][];

                    int RawCount = 0, spliter;
                    Char[] atomicData = new char[10];
                   // StringBuilder sb = new StringBuilder();
                    foreach ( String line in lines)
                    {

                        List<String> list = new List<String>();
                        spliter = 0;
                        int TrimmedLineLength;
         
                            if (line.Contains("numeric"))
                            {
                                list.Add("numeric");
                               
                            }
                            else if (line.Contains("{"))
                            {
                                string TrimmedLine = trimBraces(line);
                                TrimmedLineLength = TrimmedLine.Length;
                                for (int col = 0; col < TrimmedLineLength; col++)
                                {

                                    atomicData[spliter] = TrimmedLine[col];
                                    spliter++;
                                    if (col + 1 == TrimmedLineLength)
                                    {
                                        atomicData[spliter + 1] = '\0';
                                        String st = new string(atomicData);
                                        list.Add(st);
                                        col = col + 1;
                                        atomicData = new char[10];
                                    }
                                    else if (TrimmedLine[col + 1] == ',')
                                    {
                                        atomicData[spliter + 1] = '\0';
                                        String st = new string(atomicData);
                                        list.Add(st);
                                        col = col + 1;
                                        spliter = 0;

                                        atomicData = new char[10];
                                    }

                                }
                            }
                            tableJaggedDataDefinationStr[RawCount] = list.ToArray();
                        RawCount++;
                    }

                    return tableJaggedDataDefinationStr;
                }
         
        }





    }

