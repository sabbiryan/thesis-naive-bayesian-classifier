using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relevantAttributeGenerationUsingNB
{
    internal class NumericDataMap
    {
        private Double[][] tableJaggedDataNumeric;



        public Double[][] getMappedData(String[][] data, String[][] defination)
        {
            int row = 0, dataToupleLength;
            int rowData = data.Length;
            int defLenght;
            int DataDefinationLenght;
            List<Double> list;
            tableJaggedDataNumeric = new double[rowData][];
            foreach (String[] dataToupleString in data)
            {
                list = new List<Double>();
                dataToupleLength = dataToupleString.Length;
                for (int ColData = 0; ColData <dataToupleLength; ColData++)
                {
                    defLenght = defination[ColData].Length;
                    for (int ColDef = 0; ColDef < defLenght; ColDef++)
                    {
                        if (defination[ColData][ColDef].CompareTo("numeric") == 0)
                        {
                            list.Add(Convert.ToDouble(dataToupleString[ColData]));
                        }

                        else  if (dataToupleString[ColData].CompareTo(defination[ColData][ColDef])==0)
                        {
                            list.Add(ColDef);
                        }


                    }

                }


               

              
                tableJaggedDataNumeric[row] = list.ToArray();
                row++;
            }
            return tableJaggedDataNumeric;
        }
    }
}


    

