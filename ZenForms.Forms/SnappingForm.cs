using System;
using System.Windows.Forms;

namespace ZenForms.Forms
{
	public class SnappingForm : Form
	{
		public SnappingForm()
		{
			TopLevel = false;
			Visible = true;
		}

		public int SnapDist { get; set; } = 32;

		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);

			foreach (Control control in Parent.Controls)
			{
				// don't check this control against itself
				if (control == this)
					continue;

				var intersectRect = control.Bounds;
				intersectRect.Inflate(SnapDist, SnapDist);

				if (Bounds.IntersectsWith(intersectRect))
				{
					// coming from the left
					if (Right < control.Left && Right > control.Left - SnapDist && Left < control.Left)
					{
						Left = control.Left - Width;
						return;
					}

					// coming from the right
					if (Left > control.Right && Left < control.Right + SnapDist && Right > control.Right)
					{
						Left = control.Right;
						return;
					}

					// coming from the top
					if (Bottom < control.Top && Bottom > control.Top - SnapDist && Top < control.Top)
					{
						Top = control.Top - Height;
						return;
					}

					// coming from the bottom
					if (Top > control.Bottom && Top < control.Bottom + SnapDist && Bottom > control.Bottom)
					{
						Top = control.Bottom;
						return;
					}
				}
			}
		}
	}
}
