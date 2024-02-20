using System;
using System.Diagnostics;

class Program
{

    public double process(double aval, double bval)
    {
        return aval / 2 + bval;
    }
    static void Main(string[] args)
    {
        int pagination = 10;
        int i = 1;
        while (i >= pagination)
        {
            Console.WriteLine(i);
            i++;
        }
    }
}