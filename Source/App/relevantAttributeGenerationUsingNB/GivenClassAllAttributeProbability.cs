using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace relevantAttributeGenerationUsingNB
{
    class GivenClassAllAttributeProbability : ICloneable
    {

        public String ClassName { get; set; }
        public Double[][] PriorProbabilityOfEveryAttributes { get; set; }
        public Double[][] PriorProbabilityOfEveryAttributesAfterlaplaceanCorrection { get; set; }
      
        public Double[][] NumberNforThisClass { get; set; }
        public Double[][] NumberNforThisClassAfterlaplaceanCorrection { get; set; }
        public int TottalOccurrenceInData = 0;
        public int TottalOccurrenceInDataAfterLaplace = 0;
        public Double ProbabilityOfThisClass;
        public int numberN = 0;
        public Double tottal = 0;
        public Double Mean = 0;
        public Double x ;
        public Double tempForSTDcalc=0;
        public Double StanderedDaviation=0;
        public List<Double> list = new List<Double>();
        public List<Double> listForOccurence = new List<Double>();
        public List<Double> listForNumberN = new List<Double>();
        public GivenClassAllAttributeProbability Clone() { return (GivenClassAllAttributeProbability)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }


    }
}
