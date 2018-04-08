using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using static Win32API.Window.Native;
using static Win32API.Window.Custom;

namespace Win32API.Window
{
    public class Native
    {
        public const Int32 WM_ACTIVATE = 0x0006;        //ウィンドウのアクティブ化・非アクティブ化
        public const Int32 WM_CHAR = 0x0102;        //キーボードからの文字の入力
        public const Int32 WM_CLEAR = 0x0303;        //エディットコントロールのテキストの削除
        public const Int32 WM_COMMAND = 0x0111;        //メニューアイテムの選択・コントロールからの通知
        public const Int32 WM_CONTEXTMENU = 0x007B;        //コンテキストメニューを表示するために受け取る通知
        public const Int32 WM_COPY = 0x0301;        //エディットコントロールのテキストのコピー
        public const Int32 WM_CUT = 0x0300;        //エディットコントロールのテキストの切り取り
        public const Int32 WM_DROPFILES = 0x0233;        //ファイルがドロップされた
        public const Int32 WM_GETFONT = 0x0031;        //コントロールのフォントを取得
        public const Int32 WM_GETICON = 0x007F;        //ウィンドウのアイコンを取得
        public const Int32 WM_GETTEXT = 0x000D;        //ウィンドウタイトルやコントロールのテキストを取得
        public const Int32 WM_GETTEXTLENGTH = 0x000E;        //ウィンドウタイトルやコントロールのテキストのサイズを取得
        public const Int32 WM_KEYDOWN = 0x0100;        //非システムキーが押された
        public const Int32 WM_KEYUP = 0x0101;        //押されていた非システムキーが離された
        public const Int32 WM_LBUTTONDBLCLK = 0x0203;        //マウス左ボタンをダブルクリック
        public const Int32 WM_LBUTTONDOWN = 0x0201;        //マウス左ボタンを押し下げ
        public const Int32 WM_LBUTTONUP = 0x0202;        //マウス左ボタンを離した
        public const Int32 WM_MBUTTONDBLCLK = 0x0209;        //マウス中央ボタンをダブルクリック
        public const Int32 WM_MBUTTONDOWN = 0x0207;        //マウス中央ボタンを押し下げ
        public const Int32 WM_MBUTTONUP = 0x0208;        //マウス中央ボタンを離した
        public const Int32 WM_MENUSELECT = 0x011F;        //メニューアイテムが選択された
        public const Int32 WM_MOVE = 0x0003;        //ウィンドウの移動
        public const Int32 WM_NOTIFY = 0x004E;        //コモンコントロールからの通知
        public const Int32 WM_NULL = 0x0000;        //効果をもたないメッセージ
        public const Int32 WM_PASTE = 0x0302;        //エディットコントロールのテキストの貼り付け
        public const Int32 WM_RBUTTONDBLCLK = 0x0206;        //マウス右ボタンをダブルクリック
        public const Int32 WM_RBUTTONDOWN = 0x0204;        //マウス右ボタンを押し下げ
        public const Int32 WM_RBUTTONUP = 0x0205;        //マウス右ボタンを離した
        public const Int32 WM_SETFONT = 0x0030;        //コントロールのフォントを設定
        public const Int32 WM_SETTEXT = 0x000C;        //ウィンドウタイトルやコントロールのテキストを設定
        public const Int32 WM_SIZE = 0x0005;        //ウィンドウサイズ変更
        public const Int32 WM_SYSCOMMAND = 0x0112;        //システムメニューアイテム選択
        public const Int32 WM_UNDO = 0x0304;        //エディットコントロールの直前の操作を元に戻す
        public const Int32 WM_USER = 0x0400;        //アプリケーション定義メッセージの先頭
        public const Int32 SB_GETPARTS = 0x0406;        //パーツの数と座標を取得
        public const Int32 SB_GETTEXT = 0x0402;        //表示されるテキストを取得
        public const Int32 SB_SETPARTS = 0x0404;        //パーツの数と座標を設定
        public const Int32 SB_SETTEXT = 0x0401;        //表示されるテキストを設定
        public const Int32 SB_SIMPLE = 0x0409;        //ステータスバーの表示モードを設定
        public const Int32 LVM_DELETEALLITEMS = 0x1009;        //すべてのアイテムを削除
        public const Int32 LVM_DELETECOLUMN = 0x101C;        //カラムを削除
        public const Int32 LVM_DELETEITEM = 0x1008;        //アイテムを削除
        public const Int32 LVM_FINDITEM = 0x100D;        //アイテムを検索
        public const Int32 LVM_GETBKCOLOR = 0x1000;        //背景色を取得
        public const Int32 LVM_GETEXTENDEDLISTVIEWSTYLE = 0x1037;        //拡張スタイルを取得
        public const Int32 LVM_GETHEADER = 0x101F;        //ヘッダコントロールを取得
        public const Int32 LVM_GETITEM = 0x1005;        //アイテムの属性を取得
        public const Int32 LVM_GETITEMCOUNT = 0x1004;        //アイテムの数を取得
        public const Int32 LVM_GETNEXTITEM = 0x100C;        //指定した属性を持つアイテムを取得
        public const Int32 LVM_GETTEXTCOLOR = 0x1023;        //テキストの文字色を取得
        public const Int32 LVM_GETTEXTBKCOLOR = 0x1025;        //テキストの背景色を取得
        public const Int32 LVM_INSERTCOLUMN = 0x101B;        //新しいカラム（列）を挿入
        public const Int32 LVM_INSERTITEM = 0x1007;        //新しいアイテムを挿入
        public const Int32 LVM_SETBKCOLOR = 0x1001;        //背景色の設定
        public const Int32 LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1036;        //拡張スタイルの設定
        public const Int32 LVM_SETIMAGELIST = 0x1003;        //イメージリストの割り当て
        public const Int32 LVM_SETITEM = 0x1006;        //アイテム・サブアイテムの属性を設定・変更
        public const Int32 LVM_SETTEXTBKCOLOR = 0x1026;        //テキストの背景色を設定
        public const Int32 LVM_SETTEXTCOLOR = 0x1024;        //テキストの文字色を設定
        public const Int32 TVM_DELETEITEM = 0x1101;        //アイテムを削除
        public const Int32 TVM_EXPAND = 0x1102;        //アイテムを開く・閉じる
        public const Int32 TVM_GETBKCOLOR = 0x111F;        //背景色を取得
        public const Int32 TVM_GETCOUNT = 0x1105;        //アイテム数の取得
        public const Int32 TVM_GETITEM = 0x110C;        //アイテムの属性を取得
        public const Int32 TVM_GETNEXTITEM = 0x110A;        //指定されたアイテムを取得
        public const Int32 TVM_GETTEXTCOLOR = 0x1120;        //文字色を取得
        public const Int32 TVM_GETVISIBLECOUNT = 0x1110;        //表示可能なアイテム数の取得
        public const Int32 TVM_INSERTITEM = 0x1100;        //新しいアイテムを追加
        public const Int32 TVM_SETIMAGELIST = 0x1109;        //イメージリストを設定
        public const Int32 TVM_SETITEM = 0x110D;        //アイテムの属性を設定
        public const Int32 TVM_SORTCHILDREN = 0x1113;        //子アイテムのソート
        public const Int32 TCM_ADJUSTRECT = 0x1328;        //ウィンドウ領域と表示領域を相互に変換
        public const Int32 TCM_DELETEALLITEMS = 0x1309;        //すべてのタブを削除
        public const Int32 TCM_DELETEITEM = 0x1308;        //タブを削除
        public const Int32 TCM_GETCURSEL = 0x130B;        //選択されているタブインデックスを取得
        public const Int32 TCM_GETITEM = 0x1305;        //タブの情報を取得
        public const Int32 TCM_GETITEMCOUNT = 0x1304;        //タブの数を取得
        public const Int32 TCM_INSERTITEM = 0x1307;        //新しいタブを挿入
        public const Int32 TCM_SETCURSEL = 0x130C;        //タブを選択
        public const Int32 TCM_SETIMAGELIST = 0x1303;        //イメージリストを設定
        public const Int32 TCM_SETITEM = 0x1306;        //タブの属性を設定
        public const Int32 UDM_GETPOS = 0x0468;        //現在のポジションを取得
        public const Int32 UDM_GETPOS32 = 0x0472;        //現在のポジション（32ビット値）を取得
        public const Int32 UDM_SETBUDDY = 0x0469;        //バディウィンドウを設定
        public const Int32 UDM_SETPOS = 0x0467;        //現在のポジション（32ビット値）を設定
        public const Int32 UDM_SETPOS32 = 0x0471;        //現在のポジションを設定
        public const Int32 UDM_SETRANGE = 0x0465;        //ポジションの範囲を設定
        public const Int32 UDM_SETRANGE32 = 0x046F;        //ポジションの範囲（32ビット値）を設定
        public const Int32 TB_ADDBITMAP = 0x0413;        //ボタンイメージのリストにビットマップイメージを追加
        public const Int32 TB_ADDBUTTONS = 0x0414;        //新しいボタンを追加
        public const Int32 TB_ADDSTRING = 0x041C;        //文字列のリストに新しい文字列を追加
        public const Int32 TB_AUTOSIZE = 0x0421;        //ツールバーサイズを調整
        public const Int32 TB_BUTTONSTRUCTSIZE = 0x041E;        //TBBUTTON構造体のサイズを設定
        public const Int32 TB_CHECKBUTTON = 0x0402;        //ボタンを押された状態または押されていない状態に設定
        public const Int32 TB_COMMANDTOINDEX = 0x0419;        //コマンド ID からボタンインデックスを取得
        public const Int32 TB_DELETEBUTTON = 0x0416;        //ボタンを削除
        public const Int32 TB_ENABLEBUTTON = 0x0401;        //ボタンの選択可・不可を設定
        public const Int32 TB_GETSTATE = 0x0412;        //ボタンの状態を取得
        public const Int32 TB_HIDEBUTTON = 0x0404;        //ボタンの表示・非表示を設定
        public const Int32 TB_INSERTBUTTON = 0x0415;        //新しいボタンを挿入
        public const Int32 TB_LOADIMAGES = 0x0432;        //システム定義のボタンイメージをロード
        public const Int32 TB_SETBITMAPSIZE = 0x0420;        //ビットマップのサイズを設定
        public const Int32 TB_SETDISABLEDIMAGELIST = 0x0436;        //無効状態にあるボタンのイメージリストを設定
        public const Int32 TB_SETHOTIMAGELIST = 0x0434;        //ホット状態にあるボタンのイメージリストを設定
        public const Int32 TB_SETIMAGELIST = 0x0430;        //デフォルト状態にあるボタンのイメージリストを設定
        public const Int32 TB_SETINDENT = 0x042F;        //インデントを設定
        public const Int32 TB_SETSTATE = 0x0411;        //ボタンの状態を設定
        public const Int32 EM_CANPASTE = 0x0432;        //指定されたクリップボード形式のデータを貼り付けることができるかどうかを取得
        public const Int32 EM_CANUNDO = 0x00C6;        //元に戻すことができるかどうかを取得
        public const Int32 EM_EXGETSEL = 0x0434;        //選択されている範囲を取得
        public const Int32 EM_EXLIMITTEXT = 0x0435;        //テキストサイズの上限を設定
        public const Int32 EM_EXSETSEL = 0x0437;        //選択状態にする範囲を設定
        public const Int32 EM_FINDTEXT = 0x0438;        //文字列を検索
        public const Int32 EM_GETCHARFORMAT = 0x043A;        //文字書式を取得
        public const Int32 EM_GETEVENTMASK = 0x043B;        //イベントマスクを取得
        public const Int32 EM_GETMODIFY = 0x00B8;        //変更フラグ取得
        public const Int32 EM_GETOPTIONS = 0x044E;        //オプションを取得
        public const Int32 EM_GETPARAFORMAT = 0x043D;        //段落書式を取得
        public const Int32 EM_GETSEL = 0x00B0;        //選択されている範囲を取得
        public const Int32 EM_GETSELTEXT = 0x043E;        //選択されているテキストを取得
        public const Int32 EM_SETBKGNDCOLOR = 0x0443;        //背景色を設定
        public const Int32 EM_SETCHARFORMAT = 0x0444;        //文字書式を設定
        public const Int32 EM_SETEVENTMASK = 0x0445;        //イベントマスクを設定
        public const Int32 EM_SETMODIFY = 0x00B9;        //変更フラグを設定
        public const Int32 EM_SETOPTIONS = 0x044D;        //オプションを設定
        public const Int32 EM_SETPARAFORMAT = 0x0447;        //段落書式を設定
        public const Int32 EM_STREAMIN = 0x0449;        //内容をストリームに置き換える
        public const Int32 EM_STREAMOUT = 0x044A;        //内容をストリームに書き出す
        public const Int32 EM_UNDO = 0x00C7;        //直前の操作を元に戻す


        /// <summary>
        /// 指定されたウィンドウのタイトルバーのテキストをバッファへコピーします。
        /// 指定されたウィンドウがコントロールの場合は、コントロールのテキストをコピーします。
        /// ただし、他のアプリケーションのコントロールのテキストを取得することはできません。
        /// 他のプロセス内のコントロールのテキストを取得するには、
        /// GetWindowText 関数を呼び出すのではなく、直接 WM_GETTEXT メッセージを送ります。
        /// </summary>
        /// <param name="hWnd">ウィンドウまたはコントロールのハンドル</param>
        /// <param name="strText">テキストバッファ</param>
        /// <param name="maxCount">コピーする最大文字数</param>
        /// <returns>関数が成功すると、コピーされた文字列の文字数が返ります（ 終端の NULL 文字は含められません）。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        /// <summary>
        /// 指定されたウィンドウのタイトルバーテキストの文字数を返します（ そのウィンドウがタイトルバーを持つ場合）。
        /// 指定したウィンドウがコントロールの場合は、コントロール内のテキストの文字数を返します。
        /// ただし、GetWindowTextLength 関数で他のアプリケーションのエディットコントロールのテキストの長さを取得することはできません。
        /// </summary>
        /// <param name="hWnd">ウィンドウまたはコントロールのハンドル</param>
        /// <returns>関数が成功すると、テキストの文字数が返ります。特定の条件の下では、実際のテキスト長よりも大きくなります。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// 画面上のすべてのトップレベルウィンドウを列挙します。
        /// この関数を呼び出すと、各ウィンドウのハンドルが順々にアプリケーション定義のコールバック関数に渡されます。
        /// EnumWindows 関数は、すべてのトップレベルリンドウを列挙し終えるか、
        /// またはアプリケーション定義のコールバック関数から 0（FALSE）が返されるまで処理を続けます。
        /// </summary>
        /// <param name="enumProc">コールバック関数</param>
        /// <param name="data">コールバック関数に渡すアプリケーション定義の値を指定します。</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, ref ArrayList data);

        /// <summary>
        /// 指定された親ウィンドウに属する子ウィンドウを列挙します。
        /// </summary>
        /// <param name="window">親ウィンドウのハンドル</param>
        /// <param name="callback">コールバック関数へのポインタ</param>
        /// <param name="list">アプリケーション定義の値</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowsProc callback, ref ArrayList list);

        //コールバック関数のデリゲート
        public delegate bool EnumWindowsProc(IntPtr hWnd, ref ArrayList data);

        /// <summary>
        /// 指定されたウィンドウの表示状態を調べます。
        /// </summary>
        /// <param name="hWnd">調査するウィンドウのハンドルを指定します。</param>
        /// <returns>指定されたウィンドウ、その親ウィンドウ、そのさらに上位の親ウィンドウのすべてが
        /// WS_VISIBLE スタイルを持つ場合は、0 以外の値が返ります。それ以外の場合は、0 が返ります。</returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// 指定されたウィンドウが属するクラスの名前を取得します。
        /// </summary>
        /// <param name="hWnd">ウィンドウのハンドル</param>
        /// <param name="lpClassName">バッファへのポインタを指定します。このバッファに、クラスの名前が文字列で格納されます。</param>
        /// <param name="nMaxCount">クラス名バッファのサイズ</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// 指定された文字列と一致するクラス名とウィンドウ名を持つトップレベルウィンドウ（ 親を持たないウィンドウ）のハンドルを返します。
        /// この関数は、子ウィンドウは探しません。検索では、大文字小文字は区別されません。
        /// </summary>
        /// <param name="lpClassName">クラス名</param>
        /// <param name="lpWindowName">ウィンドウ名</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);

        /// <summary>
        /// 1 つまたは複数のウィンドウへ、指定されたメッセージを送信します。
        /// この関数は、指定されたウィンドウのウィンドウプロシージャを呼び出し、そのウィンドウプロシージャがメッセージを処理し終わった後で、制御を返します。
        /// </summary>
        /// <param name="hWnd">送信先ウィンドウのハンドル</param>
        /// <param name="Msg">メッセージ</param>
        /// <param name="wParam">メッセージの最初のパラメータ</param>
        /// <param name="lParam">メッセージの 2 番目のパラメータ</param>
        /// <returns>メッセージ処理の結果が返ります。この戻り値の意味は、送信されたメッセージにより異なります。</returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam, ref COPYDATASTRUCT lParam);

        /// <summary>
        /// 1 つまたは複数のウィンドウへ、指定されたメッセージを送信します。
        /// この関数は、指定されたウィンドウのウィンドウプロシージャを呼び出し、そのウィンドウプロシージャがメッセージを処理し終わった後で、制御を返します。
        /// </summary>
        /// <param name="hWnd">送信先ウィンドウのハンドル</param>
        /// <param name="Msg">メッセージ</param>
        /// <param name="wParam">メッセージの最初のパラメータ</param>
        /// <param name="lParam">メッセージの 2 番目のパラメータ</param>
        /// <returns>メッセージ処理の結果が返ります。この戻り値の意味は、送信されたメッセージにより異なります。</returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);

        /// <summary>
        /// COPYDATASTRUCT構造体 
        /// </summary>
        public struct COPYDATASTRUCT
        {
            public Int32 dwData;      //送信する32ビット値
            public Int32 cbData;   //lpDataのバイト数
            public string lpData;   //送信するデータへのポインタ(0も可能)
        }
    }

    public class Custom
    {
        /// <summary>
        /// EnumWindowsとEnumChildWindowsのコールバック関数
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool CallBackEnumWindowsHandle(IntPtr hWnd, ref ArrayList data)
        {
            data.Add(hWnd);
            return true;
        }

        /// <summary>
        /// ウィンドウハンドルからテキストを取得します。
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル</param>
        /// <returns>ウィンドウのテキスト</returns>
        public static string WindowHandleToText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(size);
            GetWindowText(hWnd, sb, size);
            return sb.ToString();
        }

        /// <summary>
        /// ウィンドウハンドルからクラス名を取得します。
        /// </summary>
        /// <param name="hWnd">ウィンドウハンドル</param>
        /// <returns>クラス名</returns>
        public static string WindowHandleToClassName(IntPtr hWnd)
        {
            int size = 128;
            StringBuilder sb = new StringBuilder(size);
            GetClassName(hWnd, sb, size);
            string stRtn = sb.ToString();
            return stRtn.TrimEnd('\0');
        }

        /// <summary>
        /// 全親ウィンドウのハンドルを返します。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IntPtr> GetWindowHandles()
        {
            ArrayList list = new ArrayList();
            EnumWindows(CallBackEnumWindowsHandle, ref list);
            foreach (IntPtr item in list)
            {
                yield return item;
            }
        }

        /// <summary>
        /// 子ウィンドウを列挙する
        /// </summary>
        /// <param name="hWnd">親ウィンドウのハンドル</param>
        /// <returns></returns>
        public static IEnumerable<IntPtr> GetChildWindowHandles(IntPtr hWnd)
        {
            ArrayList list = new ArrayList();
            EnumChildWindows(hWnd, CallBackEnumWindowsHandle, ref list);
            foreach (IntPtr item in list)
            {
                yield return item;
            }
        }

        /// <summary>
        /// クラス名の正規表現で検索して結果を列挙する
        /// </summary>
        /// <param name="stRegex">正規表現</param>
        /// <param name="hWnd">親ウィンドウのハンドル。0なら全てから探す</param>
        /// <returns></returns>
        public static IEnumerable<IntPtr> FindWindowHandlesByClassName(string stRegex, IntPtr hWnd, RegexOptions options = RegexOptions.None)
        {
            Window window;

            foreach (IntPtr hParent in GetWindowHandles())
            {
                window = new Window(hParent);
                if (Regex.IsMatch(window.ClassName, stRegex, options))
                {
                    yield return window.Handle;
                };

                if (hWnd == IntPtr.Zero)
                {
                    window = new Window(hParent);
                    foreach (Window child in window.GetChildren())
                    {
                        if (Regex.IsMatch(child.ClassName, stRegex, options))
                        {
                            yield return child.Handle;
                        };
                    }
                }
                else
                {
                    window = new Window(hWnd);
                    foreach (Window child in window.GetChildren())
                    {
                        if (Regex.IsMatch(child.ClassName, stRegex, options))
                        {
                            yield return child.Handle;
                        };
                    }
                    break;
                }
            }
        }


        public static IEnumerable<IntPtr> FindWindowHandlesByText(string stRegex, IntPtr hWnd, RegexOptions options = RegexOptions.None)
        {
            Window window;

            foreach (IntPtr hParent in GetWindowHandles())
            {
                window = new Window(hParent);
                if (Regex.IsMatch(window.Text, stRegex, options))
                {
                    yield return window.Handle;
                };

                if (hWnd == IntPtr.Zero)
                {
                    window = new Window(hParent);
                    foreach (Window child in window.GetChildren())
                    {
                        if (Regex.IsMatch(child.Text , stRegex, options))
                        {
                            yield return child.Handle;
                        };
                    }
                }
                else
                {
                    window = new Window(hWnd);
                    foreach (Window child in window.GetChildren())
                    {
                        if (Regex.IsMatch(child.Text, stRegex, options))
                        {
                            yield return child.Handle;
                        };
                    }
                    break;
                }
            }
        }

    }


    public class Window
    {
        private IntPtr ChWnd;
        private string CstText;
        private string CstClassName;

        public IntPtr Handle { get { return ChWnd; } }
        public string Text { get { return CstText; } }
        public string ClassName { get { return CstClassName; } }

        public Window(IntPtr hWnd)
        {
            ChWnd = hWnd;
            CstText = WindowHandleToText(hWnd);
            CstClassName = WindowHandleToClassName(hWnd);
        }

        public IEnumerable<Window> GetChildren()
        {
            foreach (IntPtr hWnd in GetChildWindowHandles(ChWnd))
            {
                yield return new Window(hWnd);
            }
        }

        public override string ToString()
        {
            return string.Format("Handle = {0}, Text = {1}, Class = {2}", ChWnd, CstText, CstClassName);
        }
    }
}
