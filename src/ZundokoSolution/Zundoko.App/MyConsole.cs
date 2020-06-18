using System;
using System.Diagnostics;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.App
{
    public class MyConsole : IConsole
    {
        public IConsole Write(string text)
        {
            Console.Write(text);
            Debug.Write(text);
            return this;
        }

        public IConsole WriteLine()
        {
            Console.WriteLine();
            Debug.WriteLine("");
            return this;
        }

        public IConsole WriteLine(string text)
        {
            Console.WriteLine(text);
            Debug.WriteLine(text);
            return this;
        }
    }
}
