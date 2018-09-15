using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// レジストリやiniファイルを扱う
/// </summary>
namespace Win32API.Registry
{
    public class Native
    {
        /// <summary>
        /// 指定された .ini ファイルの指定されたセクション内にある、指定されたキーに関連付けられている整数を取得します。
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpKeyName">キー名</param>
        /// <param name="nDefault">キー名が見つからなかった場合に返すべき値</param>
        /// <param name="lpFileName">.ini ファイルの名前</param>
        /// <returns>関数が成功すると、指定した .ini ファイルの指定したセクション内にある、指定したキーに関連付けられている文字列に相当する整数が返ります。指定したキーが見つからない場合、nDefault パラメータで指定した既定の値が返ります。キーの値が負の場合、0 が返ります。</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        /// <summary>
        /// ini ファイル（初期化ファイル）から、指定されたセクション内のすべてのキーと値を取得します。
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpszReturnBuffer">情報が格納されるバッファ</param>
        /// <param name="nSize">情報バッファのサイズ</param>
        /// <param name="lpFileName">.ini ファイルの名前</param>
        /// <returns>バッファに格納された文字数が返ります（終端の 1 つの NULL 文字を除く）。バッファのサイズが不足して、指定したセクション内のキー名と値のペアの一部を格納できない場合、nSize-2 の値が返ります。</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpszReturnBuffer, uint nSize, string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

    }

    public class Custom
    {
        /// <summary>
        /// 指定したセクションのキーと値のセットを配列で返す
        /// </summary>
        /// <param name="iniFileName">ファイルパス</param>
        /// <param name="section">セクション</param>
        /// <returns>[キー]=[値]の配列</returns>
        public static string[] GetIniAllKey(string iniFileName, string section)
        {
            uint MAX_BUFFER = 32767;
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);
            uint bytesReturned = Native.GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, iniFileName);
            if (bytesReturned == 0)
            {
                Marshal.FreeCoTaskMem(pReturnedString);
                return null;
            }
            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);
            //use of Substring below removes terminating null for split
            return local.Substring(0, local.Length - 1).Split('\0');
        }

        public static string ReadIni(string iniFilePath, string appName, string key)
        {
            StringBuilder sb = new StringBuilder(1024);

            Native.GetPrivateProfileString(appName, key, null, sb, (uint)sb.Capacity, iniFilePath);

            return sb.ToString();
        }

        public static void WriteIni(string iniFilePath, string appName, string key, string value)
        {
            Native.WritePrivateProfileString(appName, key, value, iniFilePath);
        }

        public static void DeleteSection(string iniFilePath, string appName)
        {
            Native.WritePrivateProfileString(appName, null, null, iniFilePath);
        }

        public static void DeleteKey(string iniFilePath, string appName, string key)
        {
            Native.WritePrivateProfileString(appName, key, null, iniFilePath);
        }
    }
}
