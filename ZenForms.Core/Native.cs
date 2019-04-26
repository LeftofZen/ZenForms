using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace ZenForms.Core
{
	public enum HitTestValues
	{
		HTERROR = -2,
		HTTRANSPARENT = -1,
		HTNOWHERE = 0,
		HTCLIENT = 1,
		HTCAPTION = 2,
		HTSYSMENU = 3,
		HTGROWBOX = 4,
		HTMENU = 5,
		HTHSCROLL = 6,
		HTVSCROLL = 7,
		HTMINBUTTON = 8,
		HTMAXBUTTON = 9,
		HTLEFT = 10,
		HTRIGHT = 11,
		HTTOP = 12,
		HTTOPLEFT = 13,
		HTTOPRIGHT = 14,
		HTBOTTOM = 15,
		HTBOTTOMLEFT = 16,
		HTBOTTOMRIGHT = 17,
		HTBORDER = 18,
		HTOBJECT = 19,
		HTCLOSE = 20,
		HTHELP = 21
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MARGINS
	{
		public int leftWidth;
		public int rightWidth;
		public int topHeight;
		public int bottomHeight;
	}

	// https://docs.microsoft.com/en-us/windows/desktop/winmsg/wm-seticon
	public enum IconType
	{
		SMALL = 0,
		BIG = 1
	}

	public static class ErrorCodes
	{
		// windows error codes, without 'ERROR_' prefix
		public const int SUCCESS = 0;
		public const int INVALID_PARAMETER = 87;
		public const int ALREADY_EXISTS = 183;
		public const int IO_PENDING = 997;
		public const int INVALID_WINDOW_HANDLE = 1400;
	}

	public enum WindowMessages
	{
		WM_NULL = 0x0000,
		WM_CREATE = 0x0001,
		WM_DESTROY = 0x0002,
		WM_MOVE = 0x0003,
		WM_SIZE = 0x0005,
		WM_ACTIVATE = 0x0006,
		WM_SETFOCUS = 0x0007,
		WM_KILLFOCUS = 0x0008,
		WM_ENABLE = 0x000A,
		WM_SETREDRAW = 0x000B,
		WM_SETTEXT = 0x000C,
		WM_GETTEXT = 0x000D,
		WM_GETTEXTLENGTH = 0x000E,
		WM_PAINT = 0x000F,
		WM_CLOSE = 0x0010,

		WM_QUIT = 0x0012,
		WM_ERASEBKGND = 0x0014,
		WM_SYSCOLORCHANGE = 0x0015,
		WM_SHOWWINDOW = 0x0018,

		WM_ACTIVATEAPP = 0x001C,

		WM_SETCURSOR = 0x0020,
		WM_MOUSEACTIVATE = 0x0021,
		WM_GETMINMAXINFO = 0x24,
		WM_WINDOWPOSCHANGING = 0x0046,
		WM_WINDOWPOSCHANGED = 0x0047,

		WM_CONTEXTMENU = 0x007B,
		WM_STYLECHANGING = 0x007C,
		WM_STYLECHANGED = 0x007D,
		WM_DISPLAYCHANGE = 0x007E,
		WM_GETICON = 0x007F,
		WM_SETICON = 0x0080,

		// non client area
		WM_NCCREATE = 0x0081,
		WM_NCDESTROY = 0x0082,
		WM_NCCALCSIZE = 0x0083,
		WM_NCHITTEST = 0x84,
		WM_NCPAINT = 0x0085,
		WM_NCACTIVATE = 0x0086,

		WM_GETDLGCODE = 0x0087,

		WM_SYNCPAINT = 0x0088,

		// non client mouse
		WM_NCMOUSEMOVE = 0x00A0,
		WM_NCLBUTTONDOWN = 0x00A1,
		WM_NCLBUTTONUP = 0x00A2,
		WM_NCLBUTTONDBLCLK = 0x00A3,
		WM_NCRBUTTONDOWN = 0x00A4,
		WM_NCRBUTTONUP = 0x00A5,
		WM_NCRBUTTONDBLCLK = 0x00A6,
		WM_NCMBUTTONDOWN = 0x00A7,
		WM_NCMBUTTONUP = 0x00A8,
		WM_NCMBUTTONDBLCLK = 0x00A9,

		// keyboard
		WM_KEYDOWN = 0x0100,
		WM_KEYUP = 0x0101,
		WM_CHAR = 0x0102,

		WM_SYSCOMMAND = 0x0112,

		// menu
		WM_INITMENU = 0x0116,
		WM_INITMENUPOPUP = 0x0117,
		WM_MENUSELECT = 0x011F,
		WM_MENUCHAR = 0x0120,
		WM_ENTERIDLE = 0x0121,
		WM_MENURBUTTONUP = 0x0122,
		WM_MENUDRAG = 0x0123,
		WM_MENUGETOBJECT = 0x0124,
		WM_UNINITMENUPOPUP = 0x0125,
		WM_MENUCOMMAND = 0x0126,

		WM_CHANGEUISTATE = 0x0127,
		WM_UPDATEUISTATE = 0x0128,
		WM_QUERYUISTATE = 0x0129,

		// mouse
		WM_MOUSEFIRST = 0x0200,
		WM_MOUSEMOVE = 0x0200,
		WM_LBUTTONDOWN = 0x0201,
		WM_LBUTTONUP = 0x0202,
		WM_LBUTTONDBLCLK = 0x0203,
		WM_RBUTTONDOWN = 0x0204,
		WM_RBUTTONUP = 0x0205,
		WM_RBUTTONDBLCLK = 0x0206,
		WM_MBUTTONDOWN = 0x0207,
		WM_MBUTTONUP = 0x0208,
		WM_MBUTTONDBLCLK = 0x0209,
		WM_MOUSEWHEEL = 0x020A,
		WM_MOUSELAST = 0x020D,

		WM_PARENTNOTIFY = 0x0210,
		WM_ENTERMENULOOP = 0x0211,
		WM_EXITMENULOOP = 0x0212,

		WM_NEXTMENU = 0x0213,
		WM_SIZING = 0x0214,
		WM_CAPTURECHANGED = 0x0215,
		WM_MOVING = 0x0216,

		WM_ENTERSIZEMOVE = 0x0231,
		WM_EXITSIZEMOVE = 0x0232,

		WM_MOUSELEAVE = 0x02A3,
		WM_MOUSEHOVER = 0x02A1,
		WM_NCMOUSEHOVER = 0x02A0,
		WM_NCMOUSELEAVE = 0x02A2,

		WM_MDIACTIVATE = 0x0222,
		WM_HSCROLL = 0x0114,
		WM_VSCROLL = 0x0115,

		WM_SYSMENU = 0x313,

		WM_PRINT = 0x0317,
		WM_PRINTCLIENT = 0x0318,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int left;
		public int top;
		public int right;
		public int bottom;

		public RECT(int left, int top, int right, int bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		public static RECT FromXYWH(int x, int y, int width, int height)
		{
			return new RECT(x, y, x + width, y + height);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWPOS
	{
		public IntPtr hWnd;
		public IntPtr hWndInsertAfter;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public uint flags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct POINTS
	{
		public short X;
		public short Y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct APPBARDATA
	{
		public int cbSize; // initialize this field using: Marshal.SizeOf(typeof(APPBARDATA));
		public IntPtr hWnd;
		public uint uCallbackMessage;
		public uint uEdge;
		public RECT rc;
		public int lParam;
	}

	public static class SafeNativeMethods
	{
		[SuppressMessage("CargoWiseOne", "CW1021:StaticFieldsAreThreadStaticRule")]
		static readonly HashSet<int> safeToIgnoreErrors = new HashSet<int>
		{
			ErrorCodes.INVALID_PARAMETER,
			ErrorCodes.ALREADY_EXISTS,
			ErrorCodes.IO_PENDING,
			ErrorCodes.INVALID_WINDOW_HANDLE
		};

		[SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "internal use")]

		static int SafeWrapNative(int result)
		{
			var lastError = Marshal.GetLastWin32Error();
			if (result < 0 || (result > 0 && lastError != 0))
			{
				if (!safeToIgnoreErrors.Contains(lastError))
				{
					var errStr = $"native call result: {result} last error: {lastError}"; // SuppressCodeSmell Reason = not visible to user
					throw new Win32Exception(lastError, errStr);
				}
			}

			return result;
		}

		[SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", Justification = "internal use")]

		static bool SafeWrapNative(bool result)
		{
			var lastError = Marshal.GetLastWin32Error();
			if (!result || (result && lastError != 0))
			{
				if (!safeToIgnoreErrors.Contains(lastError))
				{
					var errStr = $"native call result: {result} last error: {lastError}"; // SuppressCodeSmell Reason = not visible to user
					throw new Win32Exception(lastError, errStr);
				}
			}

			return result;
		}

		public static int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam)
		{
			return SafeWrapNative(UnsafeNativeMethods.SendMessage(hWnd, wMsg, wParam, lParam));
		}

		public static int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam)
		{
			return SafeWrapNative(UnsafeNativeMethods.SendMessage(hWnd, wMsg, wParam, lParam));
		}

		public static int SendMessage(IntPtr hWnd, int wMsg, int wParam, POINTS pos)
		{
			return SafeWrapNative(UnsafeNativeMethods.SendMessage(hWnd, wMsg, wParam, pos));
		}
	}

	public static class UnsafeNativeMethods
	{
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		public static extern IntPtr SetCapture(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetCapture();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

		[DllImport("user32.dll")]
		public static extern Int32 TrackPopupMenuEx(IntPtr hMenu, UInt32 fuFlags, Int32 x, Int32 y, IntPtr hWnd, IntPtr lptpm);

		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "3")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2")]
		[DllImport("user32.dll")]
		public static extern Int32 SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, Int32 lParam);

		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return")]
		[DllImport("user32.dll")]
		public static extern Int32 SendMessage(IntPtr hWnd, Int32 wMsg, IntPtr wParam, IntPtr lParam);

		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "3")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2")]
		[DllImport("user32.dll")]
		public static extern Int32 SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, POINTS pos);

		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "3")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2")]
		[DllImport("user32.dll")]
		public static extern Int32 PostMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, Int32 lParam);

		[DllImport("user32.dll")]
		public static extern Int32 PostMessage(IntPtr hWnd, Int32 wMsg, IntPtr wParam, IntPtr lParam);

		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "3")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2")]
		[DllImport("user32.dll")]
		public static extern Int32 PostMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, POINTS pos);

		[DllImport("user32.dll")]
		public static extern Int32 SetWindowRgn(IntPtr hWnd, IntPtr hrgn, [MarshalAs(UnmanagedType.Bool)] bool bRedraw);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateRectRgn(Int32 nLeftRect, Int32 nTopRect, Int32 nRightRect, Int32 nBottomRect);

		[DllImport("user32.dll")]
		public static extern Int32 GetWindowRgn(IntPtr hWnd, IntPtr hrgn);

		[DllImport("gdi32.dll")]
		public static extern Int32 GetRgnBox(IntPtr hrgn, out RECT lprc);

		[DllImport("user32.dll")]
		public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 Offset);

		[DllImport("user32.dll")]
		public static extern Int32 GetSystemMetrics(Int32 smIndex);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(
			IntPtr parentHandle,
			IntPtr childAfter,
			[MarshalAs(UnmanagedType.LPWStr)] string className,
			[MarshalAs(UnmanagedType.LPWStr)] string windowTitle);

		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return")]
		[DllImport("shell32.dll")]
		public static extern Int32 SHAppBarMessage(UInt32 dwMessage, [In] ref APPBARDATA pData);

		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject(IntPtr hObj);
	}

	public static class NativeConstants
	{
		public const int SM_CXSIZEFRAME = 32;
		public const int SM_CYSIZEFRAME = 33;
		public const int SM_CXPADDEDBORDER = 92;

		public const int GWL_ID = (-12);
		public const int GWL_STYLE = (-16);
		public const int GWL_EXSTYLE = (-20);

		public const int WM_NCLBUTTONDOWN = 0x00A1;
		public const int WM_NCRBUTTONUP = 0x00A5;

		public const uint TPM_LEFTBUTTON = 0x0000;
		public const uint TPM_RIGHTBUTTON = 0x0002;
		public const uint TPM_RETURNCMD = 0x0100;

		public static readonly IntPtr TRUE = new IntPtr(1);
		public static readonly IntPtr FALSE = new IntPtr(0);

		public const uint ABM_GETSTATE = 0x4;
		public const int ABS_AUTOHIDE = 0x1;
	}
}
