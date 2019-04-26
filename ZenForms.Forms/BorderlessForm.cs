using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZenForms.Core;

namespace ZenForms.Forms
{
	// Implements a borderless window (ie no system-drawn borders, we draw our own with panels)
	public partial class BorderlessForm : Form
	{
		public BorderlessForm()
		{
			InitializeComponent();

			TopLeftCornerPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTTOPLEFT);
			TopRightCornerPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTTOPRIGHT);
			BottomLeftCornerPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTBOTTOMLEFT);
			BottomRightCornerPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTBOTTOMRIGHT);

			TopBorderPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTTOP);
			LeftBorderPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTLEFT);
			RightBorderPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTRIGHT);
			BottomBorderPanel.MouseDown += (s, e) => FormBorderMouseDown(e, HitTestValues.HTBOTTOM);

			ResizeBorders();
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);

			if (!DesignMode)
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
				SetWindowRegion(Handle, 0, 0, Width, Height);
			}
		}

		[Browsable(true)]
		[Description("Occurs after the icon is changed")]
		[SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Justification = "CA rule is incorrect")]
		public event EventHandler<IconType> IconChanged;

		[Description("Sets the thickness of the borders for this form")]
		//[DpiState(DpiState.ScaleX)]
		public int BorderSize { get; set; } = 4;

		protected internal virtual void SetBorderColour(Color color)
		{
			TopLeftCornerPanel.BackColor = color;
			TopBorderPanel.BackColor = color;
			TopRightCornerPanel.BackColor = color;
			LeftBorderPanel.BackColor = color;
			RightBorderPanel.BackColor = color;
			BottomLeftCornerPanel.BackColor = color;
			BottomBorderPanel.BackColor = color;
			BottomRightCornerPanel.BackColor = color;
		}

		[SuppressMessage("CargoWiseOne", "CW1017", Justification = "All values already scaled")]
		internal void ResizeBorders()
		{
			SuspendLayout();

			TopLeftCornerPanel.Size = new Size(BorderSize, BorderSize);
			TopRightCornerPanel.Size = new Size(BorderSize, BorderSize);
			BottomLeftCornerPanel.Size = new Size(BorderSize, BorderSize);
			BottomRightCornerPanel.Size = new Size(BorderSize, BorderSize);
			TopBorderPanel.Size = new Size(Width - BorderSize * 2, BorderSize);
			LeftBorderPanel.Size = new Size(BorderSize, Height - BorderSize * 2);
			RightBorderPanel.Size = new Size(BorderSize, Height - BorderSize * 2);
			BottomBorderPanel.Size = new Size(Width - BorderSize * 2, BorderSize);

			TopLeftCornerPanel.Location = new Point(0, 0);
			TopRightCornerPanel.Location = new Point(Width - BorderSize, 0);
			BottomLeftCornerPanel.Location = new Point(0, Height - BorderSize);
			BottomRightCornerPanel.Location = new Point(Width - BorderSize, Height - BorderSize);
			TopBorderPanel.Location = new Point(BorderSize, 0);
			LeftBorderPanel.Location = new Point(0, BorderSize);
			RightBorderPanel.Location = new Point(Width - BorderSize, BorderSize);
			BottomBorderPanel.Location = new Point(BorderSize, Height - BorderSize);

			ResumeLayout();
		}

		protected internal void ShowSystemMenu()
		{
			ShowSystemMenu(MousePosition);
		}

		protected internal void ShowSystemMenu(Point pos)
		{
			SafeNativeMethods.SendMessage(Handle, (int)WindowMessages.WM_SYSMENU, 0, MakeLong((short)pos.X, (short)pos.Y));
		}

		protected static int MakeLong(short lowPart, short highPart)
		{
			return (int)(((ushort)lowPart) | (uint)(highPart << 16));
		}

		#region Form Border Events

		void ZBorderlessForm_SizeChanged(object sender, EventArgs e)
		{
			ResizeBorders();
		}

		protected void FormTitleMouseDown(MouseEventArgs e)
		{
			FormBorderMouseDown(e, HitTestValues.HTCAPTION);
		}

		void FormBorderMouseDown(MouseEventArgs e, HitTestValues h)
		{
			if (e.Button == MouseButtons.Left)
			{
				FormBorderMouseDown(h);
			}
		}

		void FormBorderMouseDown(HitTestValues hit, Point p)
		{
			UnsafeNativeMethods.ReleaseCapture();
			var pt = new POINTS { X = (short)p.X, Y = (short)p.Y };
			SafeNativeMethods.SendMessage(Handle, (int)WindowMessages.WM_NCLBUTTONDOWN, (int)hit, pt);
		}

		void FormBorderMouseDown(HitTestValues hit)
		{
			FormBorderMouseDown(hit, MousePosition);
		}

		void FormBorderMouseUp(HitTestValues hit, Point p)
		{
			UnsafeNativeMethods.ReleaseCapture();
			var pt = new POINTS { X = (short)p.X, Y = (short)p.Y };
			SafeNativeMethods.SendMessage(Handle, (int)WindowMessages.WM_NCLBUTTONUP, (int)hit, pt);
		}

		void FormBorderMouseUp(HitTestValues hit)
		{
			FormBorderMouseUp(hit, MousePosition);
		}

		#endregion

		#region Windows Message Handling

		protected override void WndProc(ref Message m)
		{
			if (DesignMode)
			{
				base.WndProc(ref m);
				return;
			}

			switch (m.Msg)
			{
				case (int)WindowMessages.WM_NCCALCSIZE:
				{
					WmNCCalcSize(ref m);
					break;
				}
				case (int)WindowMessages.WM_WINDOWPOSCHANGED:
				{
					WmWindowPosChanged(ref m);
					break;
				}
				case (int)WindowMessages.WM_SETICON:
				{
					base.WndProc(ref m);
					WmSetIcon(ref m);
					break;
				}
				default:
				{
					base.WndProc(ref m);
					break;
				}
			}
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "m")]
		void WmSetIcon(ref Message m)
		{
			IconChanged.Invoke(m, (IconType)m.WParam);
		}

		[SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
		void SetWindowRegion(IntPtr hwnd, int left, int top, int right, int bottom)
		{
			var rgn = UnsafeNativeMethods.CreateRectRgn(0, 0, 0, 0);
			var hrg = new HandleRef(this, rgn);
			UnsafeNativeMethods.GetWindowRgn(hwnd, hrg.Handle);
			UnsafeNativeMethods.GetRgnBox(hrg.Handle, out RECT box);
			if (box.left != left || box.top != top || box.right != right || box.bottom != bottom)
			{
				var hr = new HandleRef(this, UnsafeNativeMethods.CreateRectRgn(left, top, right, bottom));
				UnsafeNativeMethods.SetWindowRgn(hwnd, hr.Handle, UnsafeNativeMethods.IsWindowVisible(hwnd));
			}
			UnsafeNativeMethods.DeleteObject(rgn);
		}


		// based on https://referencesource.microsoft.com/#system.windows.forms/winforms/Managed/System/WinForms/Form.cs,3f7781372ea29f83
		void WmWindowPosChanged(ref Message m)
		{
			this.UpdateWindowState();
			DefWndProc(ref m);

			var pos = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
			SetWindowRegion(m.HWnd, 0, 0, pos.cx, pos.cy);

			UpdateBounds();
		}

		// only necessary to handle when going maximised
		void WmNCCalcSize(ref Message m)
		{
			// https://docs.microsoft.com/en-us/windows/desktop/winmsg/wm-nccalcsize

			var r = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
			var max = WindowState == FormWindowState.Maximized;

			if (max)
			{
				var x = UnsafeNativeMethods.GetSystemMetrics(NativeConstants.SM_CXSIZEFRAME);
				var y = UnsafeNativeMethods.GetSystemMetrics(NativeConstants.SM_CYSIZEFRAME);
				var p = UnsafeNativeMethods.GetSystemMetrics(NativeConstants.SM_CXPADDEDBORDER);
				var w = x + p;
				var h = y + p;

				r.left += w;
				r.top += h;
				r.right -= w;
				r.bottom -= h;

				var appBarData = new APPBARDATA();
				appBarData.cbSize = Marshal.SizeOf(typeof(APPBARDATA));
				var autohide = (UnsafeNativeMethods.SHAppBarMessage(NativeConstants.ABM_GETSTATE, ref appBarData) & NativeConstants.ABS_AUTOHIDE) != 0;
				if (autohide)
				{
					r.bottom -= 1;
				}

				Marshal.StructureToPtr(r, m.LParam, true);
			}

			m.Result = IntPtr.Zero;
		}

		#endregion
	}

	// these are necessary because in winforms, Form.cs has a lot of private methods that subclasses need to call
	// but obviously cannot access. this gets around that.
	public static class ZBorderlessFormExtensions
	{
		public static void UpdateWindowState(this BorderlessForm form)
		{
			DynamicMethod(form, "UpdateWindowState", new object[] { });
		}

		static readonly Type formType = new Form().GetType();
		static void DynamicMethod(BorderlessForm form, string methodName, object[] @params)
		{
			formType
				.GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
				.Invoke(form, @params);
		}
	}
}