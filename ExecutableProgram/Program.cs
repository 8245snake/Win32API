using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Win32API.Window;
using static Win32API.Window.Custom;
using System.Text.RegularExpressions;

namespace ExecutableProgram
{
    class Program
    {

        static void Main(string[] args)
        {

            //foreach (IntPtr parent in GetWindowHandles())
            //{
            //    Window wnd = new Window(parent);
            //    foreach (Window child in wnd.GetChildren())
            //    {
            //        Console.WriteLine(child.ToString());
            //    }

            //    Console.WriteLine("");
            //}

            foreach (IntPtr handle in FindWindowHandlesByText(".*追加.*", IntPtr.Zero, RegexOptions.IgnoreCase ))
            {
                Window wnd = new Window(handle);
                Console.WriteLine(wnd.ToString());
            }


            Console.ReadKey();

        }
    }
}
