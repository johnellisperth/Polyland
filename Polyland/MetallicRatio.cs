
namespace Polyland
{
    public class MetallicRatio
    {
        /// <summary>
        /// @author John Ellis
        /// MetallicRatio 
        /// </summary>
        public int IndexForNumerator { get; set; }
        public int IndexForDenominator { get; set; }
        public double Ratio { get; set; } //actual ratio value eg) golden ratio =1.6...
        public int RatioIndex { get; set; }//0=no ratio, 1=golden, 2=silver, 3=bronze,...

        public override string ToString()
        {
            return string.Format("{0}:{1}/{2}", GetMetallicString(), IndexForNumerator, IndexForDenominator);
        }

        public string GetMetallicString()
        {
            string retVal = "None";
            switch (RatioIndex)
            {
                case 1: retVal = "Golden"; break;
                case 2: retVal = "Silver"; break;
            }
            return retVal;
        }
    }
       
}
