using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace relevantAttributeGenerationUsingNB
{
    class Database
    {



        private String[][] tableJaggedDataStr;
        public String[][] fetchDataIntoMem(string locationOfData)
        {

            String[] lines = System.IO.File.ReadAllLines(locationOfData);
            int tottalNumbeOfRaw = lines.Count();
        //    String[][] tableJaggedDataStr = new string[tottalNumbeOfRaw][];
            tableJaggedDataStr = new string[tottalNumbeOfRaw][];

            int RawCount = 0, spliter;
            Char[] atomicData = new char[10];
           // StringBuilder sb = new StringBuilder();
            foreach (String line in lines)
            {

                List<String> list = new List<String>();
                spliter = 0;
                int lineLength = line.Length;
                for (int col = 0; col < lineLength; col++)
                {
                    
                        atomicData[spliter] = line[col];
                         spliter++;
                    if (col+1==lineLength)
                    {
                        atomicData[spliter + 1] = '\0';
                        String st = new string(atomicData);
                        list.Add(st);
                        col = col + 1;
                        atomicData = new char[10];
                    }
                    else if (line[col + 1] == ',')
                    {
                        atomicData[spliter + 1] = '\0';
                        String st =new string(atomicData);
                        list.Add(st);
                        col = col + 1;
                        spliter = 0;

                        atomicData = new char[10];
                    }
                   
                }              
                tableJaggedDataStr[RawCount] = list.ToArray();
                RawCount++;
            }

            return tableJaggedDataStr;
        }
    }
}
