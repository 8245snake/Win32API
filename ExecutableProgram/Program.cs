using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Win32API.Window;
using static Win32API.Window.Custom;
using static Win32API.Window.Native;
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


            //int x = 0;
            //int y = 0;
            //bool blRtn = false;
            //while (true) {
            //    blRtn = GetCursorPosition(out x, out y);
            //    Console.WriteLine(string.Format("x = {0}, y = {1} Rtn = {2}", x, y, blRtn));
            //}

            IntPtr hWnd = IntPtr.Zero;
            System.Drawing.Point sp;
            Window window = new Window(hWnd);
            while (true)
            {
                sp = System.Windows.Forms.Cursor.Position;
                hWnd = WindowFromPoint(sp);
                window = new Window(hWnd);
                Console.WriteLine(window.ToString());
            }

        }
    }
}
