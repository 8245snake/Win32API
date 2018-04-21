using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Win32API.Graphic.Native;

namespace Win32API.Graphic
{
    public class Native
    {
        //GetDeviceCapsの第二引数
        public const int DRIVERVERSION = 0;            //デバイスドライバのバージョン
        public const int TECHNOLOGY = 2;            //デバイステクノロジー。以下の値のいずれかが返ります。

        //戻り値
        public const int DT_PLOTTER = 0;            //ベクタプロッタ
        public const int DT_RASDISPLAY = 1;            //ラスタディスプレイ
        public const int DT_RASPRINTER = 2;            //ラスタプリンタ
        public const int DT_RASCAMERA = 3;            //ラスタカメラ
        public const int DT_CHARSTREAM = 4;            //文字ストリーム
        public const int DT_METAFILE = 5;            //メタファイル
        public const int DT_DISPFILE = 6;            //ディスプレイファイル

        public const int HORZSIZE = 4;            //物理画面の幅（ミリメートル単位）
        public const int VERTSIZE = 6;            //物理画面の高さ（ミリメートル単位）
        public const int HORZRES = 8;            //画面の幅（ピクセル単位）
        public const int VERTRES = 10;            //画面の高さ（ピクセル単位）
        public const int BITSPIXEL = 12;            //ピクセルあたりのカラービットの数
        public const int PLANES = 14;            //カラープレーンの数
        public const int NUMBRUSHES = 16;            //デバイス固有のブラシの数
        public const int NUMPENS = 18;            //デバイス固有のペンの数
        public const int NUMMARKERS = 20;            //デバイス固有のマーカーの数
        public const int NUMFONTS = 22;            //デバイス固有のフォントの数
        public const int NUMCOLORS = 24;            //デバイスのカラーテーブルのエントリ数(ピクセルあたり 8 ビットを超える場合は -1 )
        public const int PDEVICESIZE = 26;            //予約されています。
        public const int CURVECAPS = 28;            //デバイスの曲線描画能力。戻り値として次の値の組み合わせの値が返ります。

        //戻り値
        public const int CC_NONE = 0;            //曲線をサポートしない
        public const int CC_CIRCLES = 1;            //円
        public const int CC_PIE = 2;            //扇形
        public const int CC_CHORD = 4;            //弓形
        public const int CC_ELLIPSES = 8;            //楕円
        public const int CC_WIDE = 16;            //太い線
        public const int CC_STYLED = 32;            //スタイル付きの線
        public const int CC_WIDESTYLED = 64;            //スタイル付きの太い線
        public const int CC_INTERIORS = 128;            //内部の塗りつぶしをサポート
        public const int CC_ROUNDRECT = 256;            //角の丸い長方形

        public const int LINECAPS = 30;            //デバイスの直線描画能力。戻り値として次の値の組み合わせの値が返ります。

        //戻り値
        public const int LC_NONE = 0;            //直線をサポートしない
        public const int LC_POLYLINE = 2;            //折れ線
        public const int LC_MARKER = 4;            //マーカー
        public const int LC_POLYMARKER = 8;            //ポリマーカー
        public const int LC_WIDE = 16;            //太い直線
        public const int LC_STYLED = 32;            //スタイル付きの直線
        public const int LC_WIDESTYLED = 64;            //スタイルを持つ太い直線
        public const int LC_INTERIORS = 128;            //内部の塗りつぶしをサポート

        public const int POLYGONALCAPS = 32;            //デバイスの多角形描画能力。戻り値として次の値の組み合わせの値が返ります。

        //戻り値
        public const int PC_NONE = 0;            //多角形をサポートしない
        public const int PC_POLYGON = 1;            //交互モードの塗りつぶし
        public const int PC_RECTANGLE = 2;            //長方形
        public const int PC_WINDPOLYGON = 4;            //全域モードでの塗りつぶし
        public const int PC_TRAPEZOID = 4;            //全域モードでの塗りつぶし
        public const int PC_SCANLINE = 8;            //単一の走査行の描画
        public const int PC_WIDE = 16;            //太い線
        public const int PC_STYLED = 32;            //スタイル付きの線
        public const int PC_WIDESTYLED = 64;            //スタイル付きの太い線
        public const int PC_INTERIORS = 128;            //内部の塗りつぶしをサポート
        public const int PC_POLYPOLYGON = 256;            //ポリポリゴン
        public const int PC_PATHS = 512;            //パス

        public const int TEXTCAPS = 34;            //デバイスのテキスト表示能力。戻り値として次の値の組み合わせの値が返ります。

        //戻り値
        public const int TC_OP_CHARACTER = 0x00000001;            //キャラクタの出力精度
        public const int TC_OP_STROKE = 0x00000002;            //ストロークの出力精度
        public const int TC_CP_STROKE = 0x00000004;            //ストローククリップの精度
        public const int TC_CR_90 = 0x00000008;            //キャラクタの 90 度回転
        public const int TC_CR_ANY = 0x00000010;            //キャラクタの任意の角度の回転
        public const int TC_SF_X_YINDEP = 0x00000020;            //x 方向と y 方向の両方の独立したスケーリング
        public const int TC_SA_DOUBLE = 0x00000040;            //キャラクタの 2 倍のスケーリング
        public const int TC_SA_INTEGER = 0x00000080;            //キャラクタの整数倍のスケーリング
        public const int TC_SA_CONTIN = 0x00000100;            //キャラクタの任意の倍率のスケーリング
        public const int TC_EA_DOUBLE = 0x00000200;            //太字
        public const int TC_IA_ABLE = 0x00000400;            //イタリック体
        public const int TC_UA_ABLE = 0x00000800;            //下線
        public const int TC_SO_ABLE = 0x00001000;            //取り消し線
        public const int TC_RA_ABLE = 0x00002000;            //ラスタフォント
        public const int TC_VA_ABLE = 0x00004000;            //ベクトルフォント
        public const int TC_RESERVED = 0x00008000;            //予約済み
        public const int TC_SCROLLBLT = 0x00010000;            //ビットブロック転送によるスクロールをサポートしない

        public const int CLIPCAPS = 36;            //デバイスのクリッピング能力。戻り値として、長方形のクリップをサポートする場合は 1 が、それ以外の場合は 0 が返ります。
        public const int RASTERCAPS = 38;            //デバイスのラスタ能力。戻り値として次の値の組み合わせの値が返ります。
        
        //戻り値
        public const int RC_BITBLT = 1;            //ビットマップの転送
        public const int RC_BANDING = 2;            //バンド処理のサポートが必要
        public const int RC_SCALING = 4;            //スケーリング
        public const int RC_BITMAP64 = 8;            //64KB より大きいビットマップ
        public const int RC_DI_BITMAP = 0x0080;            //SetDIBits 関数と GetDIBits 関数
        public const int RC_PALETTE = 0x0100;            //デバイスはパレットベースのデバイスである
        public const int RC_DIBTODEV = 0x0200;            //SetDIBitsToDevice 関数
        public const int RC_STRETCHBLT = 0x0800;            //StretchBlt 関数
        public const int RC_FLOODFILL = 0x1000;            //塗りつぶし
        public const int RC_STRETCHDIB = 0x2000;            //StretchDIBits 関数

        public const int ASPECTX = 40;            //線の描画に使うデバイスピクセルの相対幅
        public const int ASPECTY = 42;            //線の描画に使うデバイスピクセルの相対高さ
        public const int ASPECTXY = 44;            //線の描画に使うデバイスピクセルの対角線の長さ
        public const int SHADEBLENDCAPS = 45;            //Windows 98/2000 以降： デバイスのシェードとブレンドの能力を示す値
        public const int LOGPIXELSX = 88;            //論理インチ当たりの画面の水平方向のピクセル数
        public const int LOGPIXELSY = 90;            //論理インチ当たりの画面の垂直方向のピクセル数
        public const int SIZEPALETTE = 104;            //システムパレット内のエントリ数
        public const int NUMRESERVED = 106;            //システムパレット内の予約エントリ数
        public const int COLORRES = 108;            //デバイスの実際のカラー解像度を表す、ピクセル当たりのビット数
        public const int PHYSICALWIDTH = 110;            //物理的なページ全体の幅（デバイス単位）（印刷デバイス用）
        public const int PHYSICALHEIGHT = 111;            //物理的なページ全体の高さ（デバイス単位）（印刷デバイス用）
        public const int PHYSICALOFFSETX = 112;            //物理的なページの左辺から印刷可能領域の左辺までの距離（デバイス単位）（印刷デバイス用）
        public const int PHYSICALOFFSETY = 113;            //物理的なページの上辺から印刷可能領域の上辺までの距離（デバイス単位）（印刷デバイス用）
        public const int SCALINGFACTORX = 114;            //x 軸のスケーリングファクター
        public const int SCALINGFACTORY = 115;            //y 軸のスケーリングファクター
        public const int VREFRESH = 116;            //Windows NT/2000/XP のみ： 現在のディスプレイ出力の垂直周波数(Hz)。 0 または 1 はディスプレイのデフォルト周波数を示します。
        public const int DESKTOPVERTRES = 117;            //Windows NT/2000/XP のみ： 仮想デスクトップの高さ（ピクセル単位）
        public const int DESKTOPHORZRES = 118;            //Windows NT/2000/XP のみ： 仮想デスクトップの幅（ピクセル単位）
        public const int BLTALIGNMENT = 119;            //Windows NT/2000/XP のみ： デバイスに適した水平方向のアラインメント。適したアラインメントが特にないときは 0 。

        /// <summary>
        /// ピクセルで形成された長方形に対応するカラーデータを、
        /// 指定の送信元デバイスコンテキストから送信先デバイスコンテキストにビットブロック転送します。
        /// </summary>
        /// <param name="hdcDest">送信先デバイスコンテキストのハンドルを指定します。</param>
        /// <param name="nXOriginDest">送信先長方形の左上の頂点の x 座標を論理単位で指定します。</param>
        /// <param name="nYOriginDest">送信先長方形の左上の頂点の y 座標を論理単位で指定します。</param>
        /// <param name="nWidthDest">送信先長方形の幅を論理単位で指定します。</param>
        /// <param name="hHeightDest">送信先長方形の高さのハンドルを論理単位で指定します。</param>
        /// <param name="hdcSrc">送信元のデバイスコンテキストのハンドルを指定します。</param>
        /// <param name="nXOriginSrc">送信元長方形の x 座標を論理単位で指定します。</param>
        /// <param name="nYOriginSrc">送信元長方形の y 座標を論理単位で指定します。</param>
        /// <param name="nWidthSrc">送信元長方形の幅を論理単位で指定します。</param>
        /// <param name="nHeightSrc">送信元長方形の高さのハンドルを論理単位で指定します。</param>
        /// <param name="crTransparent">透過として処理する送信元ビットマップの RGB カラーを指定します。</param>
        /// <returns>関数が成功すると、TRUE が返ります。</returns>
        [DllImport("msimg32.dll", SetLastError = false)]
        public static extern bool TransparentBlt([In] IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int hHeightDest, [In] IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint crTransparent);

        /// <summary>
        /// 指定されたデバイスコンテキストで、指定された 1 個のオブジェクトを選択します。
        /// 新しいオブジェクトは、同じタイプの以前のオブジェクトを置き換えます。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="hgdiobj">オブジェクトのハンドル</param>
        /// <returns>リージョン以外のオブジェクトを指定した場合に関数が成功すると、置き換えが発生する前のオブジェクトのハンドルが返ります。</returns>
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

        /// <summary>
        /// ペン、ブラシ、フォント、ビットマップ、リージョン、パレットのいずれかの論理オブジェクトを削除し、そのオブジェクトに関連付けられていたすべてのシステムリソースを解放します。
        /// オブジェクトを削除した後は、指定されたハンドルは無効になります。
        /// </summary>
        /// <param name="hObject">グラフィックオブジェクトのハンドル</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        /// <summary>
        /// 指定された色の論理ブラシを作成します。
        /// </summary>
        /// <param name="crColor">ブラシの色を表す値</param>
        /// <returns>関数が成功すると、論理ブラシのハンドルが返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(uint crColor);

        /// <summary>
        /// 指定されたスタイル、幅、色を持つ論理ペンを作成します。
        /// その後、デバイスコンテキストでこのペンを選択し、直線と曲線を描画する際に利用できます。
        /// </summary>
        /// <param name="fnPenStyle">ペンのスタイル</param>
        /// <param name="nWidth">ペンの幅</param>
        /// <param name="crColor">ペンの色</param>
        /// <returns>関数が成功すると、論理ペンのハンドルが返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(PenStyle fnPenStyle, int nWidth, uint crColor);

        /// <summary>
        /// 現在選択されているフォント、背景色、および文字の色を使って、指定された場所に文字列を描画します。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="nXStart">開始位置（基準点）の x 座標</param>
        /// <param name="nYStart">開始位置（基準点）の y 座標</param>
        /// <param name="lpString">文字列</param>
        /// <param name="cbString">文字数</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);

        /// <summary>
        /// 現在の位置を更新して、指定された点を新しい現在の位置にします。オプションで、それまでの現在の位置を返すこともできます。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="X">新しい現在の位置の x 座標</param>
        /// <param name="Y">新しい現在の位置の y 座標</param>
        /// <param name="lpPoint">それまでの現在の位置</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);

        /// <summary>
        /// 現在の位置と、指定された終点を結ぶ直線を描画します。ただし、終点は描画に含めません。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="nXEnd">終点の x 座標</param>
        /// <param name="nYEnd">終点の y 座標</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);

        /// <summary>
        /// 指定されたブラシを使って、1 個の長方形を塗りつぶします。
        /// 長方形の左辺と上辺は塗りつぶしますが、右辺と下辺は塗りつぶしの対象になりません。
        /// </summary>
        /// <param name="hDC">デバイスコンテキストのハンドル</param>
        /// <param name="lprc">長方形</param>
        /// <param name="hbr">ブラシのハンドル</param>
        /// <returns>関数が成功すると、TRUE が返ります。</returns>
        [DllImport("user32.dll")]
        public static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

        /// <summary>
        /// 指定されたデバイスと互換性のあるメモリデバイスコンテキストを作成します。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <returns>関数が成功すると、作成されたメモリデバイスコンテキストのハンドルが返ります。</returns>
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        /// <summary>
        /// 指定されたデバイスコンテキストに関連付けられているデバイスと互換性のある、ビットマップを作成します。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="nWidth">ピクセル単位のビットマップの幅</param>
        /// <param name="nHeight">ピクセル単位のビットマップの高さ</param>
        /// <returns>関数が成功すると、ビットマップのハンドルが返ります。</returns>
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap([In] IntPtr hdc, int nWidth, int nHeight);

        /// <summary>
        /// Sets the process-default DPI awareness to system-DPI awareness. 
        /// </summary>
        /// <returns>If the function succeeds, the return value is nonzero. Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        /// <summary>
        /// 指定されたデバイスに関するデバイス固有の情報を取得します。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="nIndex">能力のインデックス</param>
        /// <returns>要求した項目に対応する値が返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        /// <summary>
        /// 指定されたデバイスコンテキストのテキストの色を指定された色に設定します。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <param name="crColor">テキストの色</param>
        /// <returns>関数が成功すると、以前のテキストの色が 値で返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern uint SetTextColor(IntPtr hdc, uint crColor);

        /// <summary>
        /// 指定されたデバイスのデバイスコンテキストを、指定の名前で作成します。
        /// </summary>
        /// <param name="lpszDriver">ドライバ名</param>
        /// <param name="lpszDevice">デバイス名</param>
        /// <param name="lpszOutput">未使用、NULL にするべき</param>
        /// <param name="lpInitData">オプションのプリンタデータ</param>
        /// <returns>関数が成功すると、指定したデバイスに関連するデバイスコンテキストのハンドルが返ります。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

        /// <summary>
        /// 指定されたデバイスコンテキストを削除します。
        /// </summary>
        /// <param name="hdc">デバイスコンテキストのハンドル</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC([In] IntPtr hdc);

        /// <summary>
        /// 関数呼び出し時にキーが押されているかどうか、
        /// また、前回の GetAsyncKeyState 関数呼び出し以降にキーが押されたかどうかを判定します。
        /// </summary>
        /// <param name="vKey">仮想キーコード</param>
        /// <returns>関数が成功すると、前回の GetAsyncKeyState 関数呼び出し以降にキーが押されたかどうか、
        /// およびキーが現在押されているかどうかを示す値が返ります。
        /// 最上位ビットがセットされたときは現在そのキーが押されていることを示し、最下位ビットがセットされたときは
        /// 前回の GetAsyncKeyState 関数呼び出し以降にそのキーが押されたことを示します。</returns>
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        /// <summary>
        /// 指定されたウィンドウの更新リージョンに 1 個の長方形を追加します。
        /// 更新リージョンとは、ウィンドウのクライアント領域のうち、再描画しなければならない部分のことです。
        /// </summary>
        /// <param name="hWnd">ウィンドウのハンドル</param>
        /// <param name="lpRect">長方形の座標</param>
        /// <param name="bErase">消去するかどうかの状態</param>
        /// <returns>関数が成功すると、0 以外の値が返ります。</returns>
        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        public enum PenStyle : int
        {
            PS_SOLID = 0, //The pen is solid.
            PS_DASH = 1, //The pen is dashed.
            PS_DOT = 2, //The pen is dotted.
            PS_DASHDOT = 3, //The pen has alternating dashes and dots.
            PS_DASHDOTDOT = 4, //The pen has alternating dashes and double dots.
            PS_NULL = 5, //The pen is invisible.
            PS_INSIDEFRAME = 6,// Normally when the edge is drawn, it’s centred on the outer edge meaning that half the width of the pen is drawn
                               // outside the shape’s edge, half is inside the shape’s edge. When PS_INSIDEFRAME is specified the edge is drawn 
                               //completely inside the outer edge of the shape.
            PS_USERSTYLE = 7,
            PS_ALTERNATE = 8,
            PS_STYLE_MASK = 0x0000000F,

            PS_ENDCAP_ROUND = 0x00000000,
            PS_ENDCAP_SQUARE = 0x00000100,
            PS_ENDCAP_FLAT = 0x00000200,
            PS_ENDCAP_MASK = 0x00000F00,

            PS_JOIN_ROUND = 0x00000000,
            PS_JOIN_BEVEL = 0x00001000,
            PS_JOIN_MITER = 0x00002000,
            PS_JOIN_MASK = 0x0000F000,

            PS_COSMETIC = 0x00000000,
            PS_GEOMETRIC = 0x00010000,
            PS_TYPE_MASK = 0x000F0000
        }

        public enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000 //only if WinVer >= 5.0.0 (see wingdi.h)
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left, Top, Right, Bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

        public int X
        {
            get { return Left; }
            set { Right -= (Left - value); Left = value; }
        }

        public int Y
        {
            get { return Top; }
            set { Bottom -= (Top - value); Top = value; }
        }

        public int Height
        {
            get { return Bottom - Top; }
            set { Bottom = value + Top; }
        }

        public int Width
        {
            get { return Right - Left; }
            set { Right = value + Left; }
        }

        public System.Drawing.Point Location
        {
            get { return new System.Drawing.Point(Left, Top); }
            set { X = value.X; Y = value.Y; }
        }

        public System.Drawing.Size Size
        {
            get { return new System.Drawing.Size(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }

        public static implicit operator System.Drawing.Rectangle(RECT r)
        {
            return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
        }

        public static implicit operator RECT(System.Drawing.Rectangle r)
        {
            return new RECT(r);
        }

        public static bool operator ==(RECT r1, RECT r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(RECT r1, RECT r2)
        {
            return !r1.Equals(r2);
        }

        public bool Equals(RECT r)
        {
            return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
        }

        public override bool Equals(object obj)
        {
            if (obj is RECT)
                return Equals((RECT)obj);
            else if (obj is System.Drawing.Rectangle)
                return Equals(new RECT((System.Drawing.Rectangle)obj));
            return false;
        }

        public override int GetHashCode()
        {
            return ((System.Drawing.Rectangle)this).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Left={0},Top={1},Right={2},Bottom={3}", Left, Top, Right, Bottom);
        }
    }

    public class Custom 
    {

        //対象のボタンが押されているとGetAsyncKeyStateの返り値の最上位ビットが1になる
        public static bool IsOnPush(System.Windows.Forms.Keys vKey)
        {
            return (Convert.ToString(GetAsyncKeyState(vKey), 2).ToCharArray()[0] == '1') ? true : false;
        }

        //直前に対象のボタンが押されているとGetAsyncKeyStateの返り値の最下位ビットが1になる
        public static bool IsFirstPush(System.Windows.Forms.Keys vKey)
        {
            return ((GetAsyncKeyState(vKey) & 1) == 0 && IsOnPush(vKey)) ? true : false;
        }

        /// <summary>
        /// System.Drawing.Colorオブジェクトをuintに変換する
        /// </summary>
        /// <param name="cColor">Colorオブジェクト</param>
        /// <returns></returns>
        public static uint ColorToUint(System.Drawing.Color cColor)
        {
            return (uint)(cColor.R + cColor.G * 256 + cColor.B * 256 * 256);
        }
    }
}
