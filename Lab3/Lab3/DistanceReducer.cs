using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class DistanceReducer
    {
        /* Формула может имееть следующий вид: 1000:0 ; 5000:3 ; 0:5;  <=>
         <=> ДО 1000 км сокращения в дистанции нет ; ДО 5000 км сокращение = 3% ; в остальных случаях сокращение = 5% 
         !ВАЖНО! обязательно должно быть условие вида 0:x; иначе будет исключение */
        private Dictionary<int, double> Expressions { get; set; }
        /* Формула может имееть следующий вид: /1000:1; <=>
         <=> каждая 1000 км последовательно уменьшается на 1%, те 990(-1%), 980(-2%), 970(-3%) и тд*/
        private KeyValuePair<int, double> Decrement { get; set; }

        public DistanceReducer(string expression)
        {
            string formula = expression.Replace(" ", "");
            if(!formula.Contains(';'))
                throw new UserException("Invalid Distance Reducer. No ';' signs.");
            if(formula[0]=='/')
            {
                var del = formula.IndexOf(':');
                var substr1 = formula.Substring(1, del - 1);
                var substr2 = formula.Substring(del + 1, formula.Length - del - 2);
                
                if(Int32.TryParse(substr1, out var first) && Double.TryParse(substr2, out var second)){}
                else
                    throw new UserException("Invalid Distance Reducer. Can't parse Decrement.");

                if (second >= 100)
                    second = 99.9;
                Decrement = new KeyValuePair<int, double>(first, second/100);
            }
            else
            {
                Expressions = new Dictionary<int, double>();
                while (formula.Contains(':'))
                {
                    var del = formula.IndexOf(':');
                    var end =  formula.IndexOf(';');
                    var substr1 = formula.Substring(0, del);
                    var substr2 = formula.Substring(del+1, end - del -1);
                    
                    formula = formula.Substring(end + 1, formula.Length - end-1);
                    if(Int32.TryParse(substr1, out var first) && Double.TryParse(substr2, out var second)){}
                    else
                        throw new UserException("Invalid Distance Reducer. Can't parse Decrement.");

                    if (second >= 100)
                        second = 99.9;
                    Expressions.Add(first, second/100);
                }
                if(!Expressions.ContainsKey(0))
                    throw new UserException("Invalid Distance Reducer. Distance Reducer should has 0 key.");
            }
        }

        public double Count(double distance)
        {
            if (Decrement.Equals(new KeyValuePair<int, double>()))
            {
                foreach (var (key, value) in Expressions)
                {
                    if (distance < key)
                        return distance * (1-value);
                }
                return distance * (1-Expressions[0]);
            }
            else
            {
                double newDist = 0.0;
                for (int i = 1; i <= distance / Decrement.Key; i++)
                    newDist += Decrement.Key * (1 - Decrement.Value * i);
                return newDist;
            }
        }

        /*public void Info()
        {
             Console.WriteLine("Expressions");
            foreach (var pair in Expressions)
                Console.WriteLine(pair.Key + " : " + pair.Value);
            //Console.WriteLine("Decrement");
            //Console.WriteLine(Decrement.Key + " : " + Decrement.Value);
        }*/
    }
}