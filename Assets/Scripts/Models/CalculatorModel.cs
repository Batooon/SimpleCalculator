//Author: Anton Rozum
using System;

namespace Models
{
    [Serializable]
    public class CalculatorModel
    {
        public string Expression;
        public double LatestResult;

        public CalculatorModel(string expression, double latestResult)
        {
            Expression = expression;
            LatestResult = latestResult;
        }
    }
}