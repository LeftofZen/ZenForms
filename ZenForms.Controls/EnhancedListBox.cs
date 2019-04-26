using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZenForms.Core;

namespace ZenForms.Controls
{
	public partial class EnhancedListBox : ListBox
	{
		public EnhancedListBox()
		{
			InitializeComponent();
		}

		#region Fields

		public bool DrawItemBorder { get; set; } = false;

		// this is locked in for this control and changing it will break the control
		[Browsable(false)]
		public override DrawMode DrawMode => DrawMode.OwnerDrawVariable;

		#endregion

		#region Events

		// triggered when this control needs to close itself
		public delegate void CloseHandler();
		public event CloseHandler OnClose;

		#endregion

		#region Event Overrides

		protected override void OnMeasureItem(MeasureItemEventArgs e)
		{
			if (DesignMode)
			{
				base.OnMeasureItem(e);
				return;
			}

			e.ItemHeight = ItemHeight * ((IListDisplayItem)Items[e.Index]).Data.Count();
		}

		// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.drawitemeventargs.drawbackground?view=netframework-4.7.2
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}

			// item draw

			var itemDrawRect = new Rectangle(
				e.Bounds.X,
				e.Bounds.Y,
				e.Bounds.Width - 1, // need a -1 here otherwise the border is cut off by winforms...go figure
				e.Bounds.Height);

			var item = DesignMode ? new SearchDisplayItem("design mode", null, null) : (Items[e.Index] as IListDisplayItem);
			var selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

			var foreColour = selected ? item.Theme.SelectedForeColour : item.Theme.ForeColour;
			var backColour = selected ? item.Theme.SelectedBackColour : item.Theme.BackColour;

			// alternating colours
			if (e.Index % 2 == 0)
			{
				backColour = ColourHelper.ShiftBrightness(backColour, -0.05f);
			}

			// background
			e.Graphics.FillRectangle(new SolidBrush(backColour), itemDrawRect);

			// draw item details, in this case 2 lines of text
			RenderItemForeground(e, itemDrawRect, item, foreColour);

			// item border
			if (DrawItemBorder)
			{
				e.Graphics.DrawRectangle(new Pen(BackColor), itemDrawRect);
			}
		}

		protected void RenderItemForeground(DrawItemEventArgs e, Rectangle itemDrawRect, IListDisplayItem item, Color foreColour)
		{
			var font = new Font(e.Font, item.Theme.FontStyle);
			const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

			int i = 0;
			var textRect = itemDrawRect;
			textRect.Height /= item.Data.Count();
			foreach (var data in item.Data)
			{
				textRect.Y = itemDrawRect.Y + i * textRect.Height;
				TextRenderer.DrawText(e.Graphics, data, font, textRect, foreColour, flags);
				i++;
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			int index = IndexFromPoint(PointToClient(Cursor.Position));
			if (index < 0 || index > Items.Count || Items[index] is HeadingDisplayItem)
			{
				return;
			}

			SelectedIndex = index;
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			ExecuteSelectedItem();
		}

		public void SendKeyDown(KeyEventArgs e)
		{
			OnKeyDown(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);

			if (e.KeyChar == (char)Keys.Enter)
			{
				ExecuteSelectedItem();
			}

			if (e.KeyChar == (char)Keys.Escape)
			{
				// if this is null, something in gui setup is screwed so we want it to throw
				OnClose.Invoke();
			}
		}

		// adds up/down arrow movement to the list, skipping headings
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.KeyCode == Keys.Down && SelectedIndex < Items.Count - 1)
			{
				SelectedIndex = NextSelectableItemIndex();
				e.Handled = true; // stops up/down arrows moving caret in text box
			}

			if (e.KeyCode == Keys.Up && SelectedIndex > 0)
			{
				SelectedIndex = PreviousSelectableItemIndex();
				e.Handled = true; // stops up/down arrows moving caret in text box
			}
		}

		#endregion

		#region Functionality

		// Gets the first item in the list that isn't a heading and returns it's index
		protected internal int FirstSelectableItemIndex()
		{
			for (int i = 0; i < Items.Count; ++i)
			{
				if (!(Items[i] is HeadingDisplayItem))
				{
					return i;
				}
			}
			return -1;
		}

		protected internal int NextSelectableItemIndex()
		{
			// find next index not heading
			var currentIndex = SelectedIndex + 1;
			while (currentIndex < Items.Count)
			{
				if (Items[currentIndex] is SearchDisplayItem)
				{
					return currentIndex;
				}
				currentIndex++;
			}

			// couldn't find anything valid so keep the same index
			return SelectedIndex;
		}

		protected internal int PreviousSelectableItemIndex()
		{
			var currentIndex = SelectedIndex - 1;
			while (currentIndex > 0)
			{
				if (Items[currentIndex] is SearchDisplayItem)
				{
					return currentIndex;
				}
				currentIndex--;
			}

			// couldn't find anything valid so keep the same index
			return SelectedIndex;
		}

		public void ExecuteSelectedItem()
		{
			if (SelectedIndex == -1 || SelectedIndex > Items.Count)
			{
				return;
			}

			if (Items[SelectedIndex] is IExecutableDisplayItem itemClicked)
			{
				// only invoke ItemExecuted event when it has an execute action
				if (itemClicked?.ExecuteAction != null)
				{
					itemClicked.ExecuteAction.Invoke();
				}
			}
			else
			{
				throw new InvalidOperationException("this should never happen");
			}

			OnClose.Invoke();
		}

		#endregion
	}
}
