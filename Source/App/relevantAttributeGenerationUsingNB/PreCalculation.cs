using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace relevantAttributeGenerationUsingNB
{
    class PreCalculation
    {
        double tempX;
        private Double[][] NumericDataJagged;
        private String[][] AttributeDefinationJagged;
        public Double TottalNumberOfDataTupple{ get; private set;}
        public Double[][] PriorProbabilityOfEveryAttributes { get; private set; }
        public Double TottalNumberOfAttributes { get; private set; }
        List<GivenClassAllAttributeProbability> listOfClassProbabilities = new List<GivenClassAllAttributeProbability>();
        public GivenClassAllAttributeProbability[] arrayOfClassProbabilities;
        public GivenClassAllAttributeProbability[] arrayOfClassProbabilitiesAfterLaplec;
        public int TottalNumberOfClasses;

        private void calculate()
        {
            int colIndexOfClass = AttributeDefinationJagged.Length - 1;
            TottalNumberOfClasses =AttributeDefinationJagged[colIndexOfClass].Length;
            arrayOfClassProbabilities= new GivenClassAllAttributeProbability[TottalNumberOfClasses];
            for (int i = 0; i < TottalNumberOfClasses; i++)
            {
                arrayOfClassProbabilities[i]= new GivenClassAllAttributeProbability();
            }
            int ColNumberOfClassInData = AttributeDefinationJagged.Length - 1;
            int iteration = 0;
            foreach (double[] touple in NumericDataJagged)
            {
                arrayOfClassProbabilities[(int)((touple[ColNumberOfClassInData]))].TottalOccurrenceInData++;
              
            }
          
            int rowOfDefination=0;
           
            int numberOfAttributeValues;
            int temp;
            bool IsNumeric;
            Double tottal,Mean,StanderedDaviation;
            String tempEachAttributeValue;
            List<Double> list = new List<Double>();
            TottalNumberOfDataTupple = NumericDataJagged.Length;
            TottalNumberOfAttributes = AttributeDefinationJagged.Length;
            for (int i = 0; i < TottalNumberOfClasses; i++)
            {
                arrayOfClassProbabilities[i].PriorProbabilityOfEveryAttributes = new double[Convert.ToInt32(TottalNumberOfAttributes)][];
               // arrayOfClassProbabilities[i].TottalNumberofOccurenceForThisClass = new double[Convert.ToInt32(TottalNumberOfAttributes)][];
                arrayOfClassProbabilities[i].NumberNforThisClass = new double[Convert.ToInt32(TottalNumberOfAttributes)][];
            }
    

            foreach (String[] SingleAttributeValues in AttributeDefinationJagged)
            {
                for (int i = 0; i < TottalNumberOfClasses; i++)
                {   arrayOfClassProbabilities[i].listForNumberN.Clear();
                    arrayOfClassProbabilities[i].list.Clear();
                }
               

                
                numberOfAttributeValues = SingleAttributeValues.Length;
                for (int attributeValueNumber = 0; attributeValueNumber < numberOfAttributeValues; attributeValueNumber++)
                {
                    
                    tottal = 0;
                    Mean = 0;
                    
                    IsNumeric = false;
                    tempEachAttributeValue = SingleAttributeValues[attributeValueNumber];
                    foreach (double[] touple in NumericDataJagged)
                    {
                        if (tempEachAttributeValue == "numeric")
                        {
                            arrayOfClassProbabilities[(int)touple[colIndexOfClass]].x = touple[rowOfDefination];
                            tempX = touple[rowOfDefination];
                            arrayOfClassProbabilities[(int)touple[colIndexOfClass]].tottal = arrayOfClassProbabilities[(int)touple[colIndexOfClass]].tottal + touple[rowOfDefination];
                            IsNumeric = true;
                            arrayOfClassProbabilities[(int)touple[colIndexOfClass]].numberN = arrayOfClassProbabilities[(int)touple[colIndexOfClass]].numberN + 1;
                        }
                        else  if (touple[rowOfDefination]==attributeValueNumber)
                        {

                            arrayOfClassProbabilities[(int)touple[colIndexOfClass]].numberN = arrayOfClassProbabilities[(int)touple[colIndexOfClass]].numberN + 1;

                        }
                        
                        
                    }
                  

                    for (int i = 0; i < TottalNumberOfClasses; i++)
                    {
                        if (IsNumeric)
                        {

                                   for (int j = 0; j < TottalNumberOfClasses; j++)
                                    {
                                        arrayOfClassProbabilities[j].tempForSTDcalc = 0;

                                    }
                            
                            arrayOfClassProbabilities[i].Mean = arrayOfClassProbabilities[i].tottal / arrayOfClassProbabilities[i].numberN;
                            foreach (Double[] touple in NumericDataJagged)
                            {

                                arrayOfClassProbabilities[(int)touple[colIndexOfClass]].tempForSTDcalc = Math.Pow((touple[rowOfDefination] - arrayOfClassProbabilities[(int)touple[colIndexOfClass]].Mean), 2) +  arrayOfClassProbabilities[(int)touple[colIndexOfClass]].tempForSTDcalc;

                            }
                            arrayOfClassProbabilities[i].StanderedDaviation =Math.Sqrt(arrayOfClassProbabilities[i].tempForSTDcalc / arrayOfClassProbabilities[i].numberN);
                            arrayOfClassProbabilities[i].list.Add(arrayOfClassProbabilities[i].Mean);
                            arrayOfClassProbabilities[i].list.Add(arrayOfClassProbabilities[i].StanderedDaviation);
                            arrayOfClassProbabilities[i].listForNumberN.Add(arrayOfClassProbabilities[i].Mean);
                            arrayOfClassProbabilities[i].listForNumberN.Add(arrayOfClassProbabilities[i].StanderedDaviation);
                            // list.Add(StanderedDaviation);



                        }
                        else
                        {

                            arrayOfClassProbabilities[i].list.Add((Double)arrayOfClassProbabilities[i].numberN / (Double)arrayOfClassProbabilities[i].TottalOccurrenceInData);
                            //arrayOfClassProbabilities[i].list.Add((Double)arrayOfClassProbabilities[i].numberN);
                            //arrayOfClassProbabilities[i].list.Add(arrayOfClassProbabilities[i].TottalOccurrenceInData);
                            arrayOfClassProbabilities[i].listForNumberN.Add((Double)arrayOfClassProbabilities[i].numberN);


                        }

                    }
                    for (int i = 0; i < TottalNumberOfClasses; i++)
                    {
                        arrayOfClassProbabilities[i].numberN = 0;

                    }
                    


                    
                }
                for (int i = 0; i < TottalNumberOfClasses; i++)
                {
                   arrayOfClassProbabilities[i].PriorProbabilityOfEveryAttributes[rowOfDefination] = arrayOfClassProbabilities[i].list.ToArray();
                   arrayOfClassProbabilities[i].NumberNforThisClass[rowOfDefination] = arrayOfClassProbabilities[i].listForNumberN.ToArray();
                }

                rowOfDefination++;
                for (int i = 0; i < TottalNumberOfClasses; i++)
                {
                    arrayOfClassProbabilities[i].numberN = 0;
                    arrayOfClassProbabilities[i].tottal = 0;

                }

            }



        }

        public double[][] CopyArrayLinq(double[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }
        public void LaplacianCorrection()
        {
            int TottalNumberOfAttributeValues=0,row=0;
            GivenClassAllAttributeProbability[] arrayOfClassProbabilitiesTempLaplec;
            arrayOfClassProbabilitiesTempLaplec = (GivenClassAllAttributeProbability[]) arrayOfClassProbabilities;
            
            for (int i = 0; i < TottalNumberOfClasses; i++)
            {
                arrayOfClassProbabilitiesTempLaplec[i].TottalOccurrenceInDataAfterLaplace = arrayOfClassProbabilitiesTempLaplec[i].TottalOccurrenceInData;
                arrayOfClassProbabilitiesTempLaplec[i].NumberNforThisClassAfterlaplaceanCorrection = CopyArrayLinq(arrayOfClassProbabilitiesTempLaplec[i].NumberNforThisClass);
                row = 0;
                Double[][] NumberN = arrayOfClassProbabilitiesTempLaplec[i].NumberNforThisClass;
               // Double[][] NumberNCorrected = new double[NumberN.Length][];
                foreach (double[] FullAttributes in NumberN)
                {
                    
                    TottalNumberOfAttributeValues = FullAttributes.Length;
                    if (TottalNumberOfAttributeValues>2)
                    {
                        for (int j = 0; j < TottalNumberOfAttributeValues; j++)
                        {
                            if (FullAttributes[j]==0.00)
                            {
                                arrayOfClassProbabilitiesTempLaplec[i].NumberNforThisClassAfterlaplaceanCorrection[row][j] = 1.00;
                                arrayOfClassProbabilitiesTempLaplec[i].TottalOccurrenceInDataAfterLaplace = arrayOfClassProbabilitiesTempLaplec[i].TottalOccurrenceInDataAfterLaplace + TottalNumberOfAttributeValues;
                                for (int k = 0; k < TottalNumberOfAttributeValues; k++)
                                {
                                    if (FullAttributes[k] != 0.00)
                                    {
                                        arrayOfClassProbabilitiesTempLaplec[i].NumberNforThisClassAfterlaplaceanCorrection[row][k]++;
                                    }
                                }


                            }
                            


                        }
                        
                    }
                    row++;


                }





            }
            
        }

        public GivenClassAllAttributeProbability[] getPrecalculations()
        {
            return arrayOfClassProbabilities;
        }


        public  PreCalculation(Double[][] data,String[][] defination)
        {
            NumericDataJagged = data;
            AttributeDefinationJagged = defination;
            calculate();

        }

       




    }
}
