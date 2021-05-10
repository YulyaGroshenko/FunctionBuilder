using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder.Logic
{
    class InfoWorker
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
            List<double> xRange = new List<double>();
            for (double i = double.Parse(range.Split(" ")[0]); i <= double.Parse(range.Split(" ")[2]); i+= step)
            {
                xRange.Add(i);
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
