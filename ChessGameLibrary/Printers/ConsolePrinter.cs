﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary.Printers
{
    class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public string GetInsertedText()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo GetInsertedKey()
        {
            return Console.ReadKey();
        }
    }
}
