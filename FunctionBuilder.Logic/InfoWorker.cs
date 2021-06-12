using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder.Logic
{
    public class InfoWorker
    {
        public double[] XRange { get; private set; }
        public List<Calculator> RPNs { get; private set; }
        public InfoWorker(string expression, string range, string step)
        {
            XRange = GetRange(range, double.Parse(step));
            RPNs = GetRPNs($"|{expression}|");
        }
        private double[] GetRange(string range, double step)
        {
            double startRange = double.Parse(range.Split(" ")[0]);
            double EndRange = double.Parse(range.Split(" ")[2]);
            List<double> xRange = new List<double>();
            for (double i = startRange; i <= EndRange; i+= step)
            {
                xRange.Add(i);
            }
            for (int i = 0; i < xRange.Count; i++)
            {
                xRange[i] = Math.Round(xRange[i], 1);
            }
            return xRange.ToArray();
        }
        private List<Calculator> GetRPNs(string expression)
        {
            List<Calculator> rpns = new List<Calculator>();
            for (int i = 0; i < XRange.Length; i++)
            {
                Calculator rpn = new Calculator(expression, XRange[i]);
                rpns.Add(rpn);
            }
            return rpns;
        }
    }
}
