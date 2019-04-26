using System;
using System.Windows.Forms;
using ZenForms.Core;

namespace ZenForms.Controls
{
	public partial class TransparentLabel : Label
	{
		public TransparentLabel()
		{
			InitializeComponent();
		}

		// visually transparent
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
				return cp;
			}
		}

		// designer transparent
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//base.OnPaintBackground(e);
		}

		// functionally transparent
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)WindowMessages.WM_NCHITTEST)
			{
				m.Result = (IntPtr)HitTestValues.HTTRANSPARENT;
			}
			else
			{
				base.WndProc(ref m);
			}
		}
	}
}
