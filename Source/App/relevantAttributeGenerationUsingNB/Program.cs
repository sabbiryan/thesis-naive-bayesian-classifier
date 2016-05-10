using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relevantAttributeGenerationUsingNB
{
    class Program
    {

        static void Main(string[] args)
        {

            Database d = new Database();
            const string locationData = @"D:\CSE\Thesis\Application\testVS\data.txt";
            const string locationAttributeDefination = @"D:\CSE\Thesis\Application\testVS\attributeDefination.txt";
            String[][] dataJagged= d.fetchDataIntoMem(locationData);
            DataDefination a = new DataDefination();
            String[][] AttributeDefinationJagged = a.getAttributeDefination(locationAttributeDefination);
            int raw = dataJagged.Length;

            NumericDataMap i = new NumericDataMap();
            Double[][]  NumericDataJagged=   i.getMappedData(dataJagged,AttributeDefinationJagged);
            PreCalculation p = new PreCalculation(NumericDataJagged,AttributeDefinationJagged);
          p.LaplacianCorrection();
            Double[][] preCalculatedPriorProbJagged = p.PriorProbabilityOfEveryAttributes;


        }
    }
}
