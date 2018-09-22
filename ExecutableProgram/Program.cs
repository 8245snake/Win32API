using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Win32API.Window;
using static Win32API.Window.Native;
using static Win32API.Window.Custom;
using static Win32API.Registry.Custom;

namespace ExecutableProgram
{
    class Program
    {

        static void Main(string[] args)
        {

            string iniFilePath = @"C:\Users\Shingo\Desktop\ini\setting.ini";
            Console.WriteLine(ReadIni(iniFilePath, "Dir", "path1"));
            string[] arr = GetKeys(iniFilePath, "layout");
            //arr = GetIniAllKeyValueSet(iniFilePath, "layout");

            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine(ReadIni(iniFilePath,"A","a1"));
            //Console.WriteLine(ReadIni(iniFilePath, "A", "a2"));
            //Console.WriteLine(ReadIni(iniFilePath, "B", "b1"));
            //Console.WriteLine(ReadIni(iniFilePath, "B", "b2"));

            Console.ReadKey();

        }
    }
}
