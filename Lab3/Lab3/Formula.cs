using System;
using System.Linq;
namespace Lab3
{
    public class Formula
    {
        // Формула задаётся строкой вида: 5+3n;n<2 (аналогична 5 + 3*n ; n < 2)
        // или просто числом без условий: 2
        private double Y;
        private double K;
        private int N;
        private char Math;
        
        public Formula(string expression)
        {
            string formula = expression.Replace(" ", ""); 
            formula = formula.Replace("*", "");
            if (!formula.Contains('<'))
                if (Double.TryParse(formula, out Y))
                    K = 0;
                else 
                    throw new UserException("Invalid Formula. Can't parse Y.");
            else
            {
                char[] mathSigns = {'+', '-', '/' }; 
                var mathInd = formula.IndexOfAny(mathSigns);
                Math = formula[mathInd];
                if(mathInd==-1)
                    throw new UserException("Invalid Formula. No known math signs. Consider using +, -, *, /");
                var comp = formula.IndexOf('<');
                var del = formula.IndexOf(';');

                var str1 = formula.Substring(0, mathInd);
                var str2 = formula.Substring(mathInd + 1, del - mathInd-2);
                var str3 = formula.Substring(comp + 1, formula.Length - comp - 1);

                if (Double.TryParse(str1, out Y) &&
                    Double.TryParse(str2, out K) &&
                    Int32.TryParse(str3, out N)){}
                else
                    throw new UserException("Invalid Formula. Can't parse Y, K, or N .");
            }
        }

        public double Count(int n)
        {
            if (n < N)
                switch (Math)
                {
                    case '+':
                        return Y + K * n;
                    case '-':
                        if (Y - K * n < 0)
                            return 0;
                        return Y - K * n;
                    case '/':
                        if(K==0)
                            throw new UserException("Invalid Formula. Division by zero");
                        return Y / (K * n);
                    default:
                        return -1;
                }
            else
                switch (Math)
                {
                    case '+':
                        return Y + K * (N - 1);
                    case '-':
                        if (Y - K * (N - 1) < 0)
                            return 0;
                        return Y - K * (N - 1);
                    case '/':
                        if(K==0)
                            throw new UserException("Invalid Formula. Division by zero");
                        return Y / (K * (N - 1));
                    default:
                        return -1;
                }
        }
        
        /*public void Info()
        {
            Console.WriteLine("Y: " + Y);
            Console.WriteLine("K: " + K);
            Console.WriteLine("N: " + N);
            Console.WriteLine("Math: " + Math);
        }*/
        
    }
}