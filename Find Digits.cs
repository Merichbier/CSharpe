using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    //static void Main(String[] args)
    //{
    //    Int64 nbTest = Int64.Parse(Console.ReadLine());
    //    for (int test = 0; test < nbTest; ++test)
    //    {
    //        Int64 N = Int64.Parse(Console.ReadLine());
    //        solve(N);
    //    }
    //    Console.ReadLine();
    //}

    static void solve(Int64 number)
    {
        String numberStr = number.ToString();
        Int64 count = 0;
        for (int index = 0; index < numberStr.Length; ++index)
        {
            int divider = Int16.Parse(numberStr.Substring(index, 1));
            if (divider != 0 && number % divider == 0) ++count;
        }
        Console.WriteLine(count);
    }
}