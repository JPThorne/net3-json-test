using BenchmarkDotNet.Running;
using System;

namespace net3_json_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BenchmarkRunner.Run<PersonSerializer>());
        }
    }
}