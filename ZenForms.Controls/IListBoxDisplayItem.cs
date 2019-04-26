using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ZenForms.Core;

namespace ZenForms.Controls
{
	#region Items

	public interface IListDisplayItem
	{
		IEnumerable<string> Data { get; }
		IDisplayItemTheme Theme { get; }
	}

	public interface IExecutableDisplayItem
	{
		Action ExecuteAction { get; }
	}

	// Ordinary items
	public class SearchDisplayItem : IListDisplayItem, IExecutableDisplayItem
	{
		// convenience cstr
		public SearchDisplayItem(string data, Action executeAction, IDisplayItemTheme theme = null)
		{
			Data = new List<string> { data };
			ExecuteAction = executeAction;
			Theme = theme ?? Theme;
		}

		// convenience cstr
		public SearchDisplayItem(string data1, string data2, Action executeAction, IDisplayItemTheme theme = null)
		{
			Data = new List<string> { data1, data2 };
			ExecuteAction = executeAction;
			Theme = theme ?? Theme;
		}

		public SearchDisplayItem(IEnumerable<string> data, Action executeAction, IDisplayItemTheme theme = null)
		{
			Data = data;
			ExecuteAction = executeAction;
			Theme = theme ?? Theme;
		}

		// IDisplayItem
		public IEnumerable<string> Data { get; set; } = Enumerable.Empty<string>();
		public IDisplayItemTheme Theme { get; set; } = DisplayItemTheme.DefaultItem;

		// IExecutableDisplayItem
		public Action ExecuteAction { get; set; } = null;
	}

	// Used for headings in organising the search
	public class HeadingDisplayItem : IListDisplayItem
	{
		// convenience cstr
		public HeadingDisplayItem(string data, IDisplayItemTheme theme = null)
		{
			Data = new List<string> { data };
			Theme = theme ?? Theme;
		}

		public HeadingDisplayItem(IEnumerable<string> data, IDisplayItemTheme theme = null)
		{
			Data = data;
			Theme = theme ?? Theme;
		}

		// IDisplayItem
		public IEnumerable<string> Data { get; set; } = Enumerable.Empty<string>();
		public IDisplayItemTheme Theme { get; set; } = DisplayItemTheme.DefaultHeading;
	}

	#endregion

	#region Item Themes

	public interface IDisplayItemTheme
	{
		Color ForeColour { get; }
		Color BackColour { get; }
		Color SelectedForeColour { get; }
		Color SelectedBackColour { get; }
		FontStyle FontStyle { get; }
	}

	public class DisplayItemTheme : IDisplayItemTheme
	{
		public static IDisplayItemTheme DefaultItem { get; } = new DisplayItemTheme(Color.Black, Color.White, Color.Black, Color.SkyBlue, FontStyle.Regular);
		public static IDisplayItemTheme DefaultError { get; } = new DisplayItemTheme(Color.White, Color.Red, Color.Red, Color.White, FontStyle.Bold);
		public static IDisplayItemTheme DefaultHeading { get; } = new DisplayItemTheme(
			DefaultItem.ForeColour, ColourHelper.ShiftBrightness(DefaultItem.BackColour, -0.20f),
			DefaultItem.ForeColour, ColourHelper.ShiftBrightness(DefaultItem.BackColour, -0.20f),
			FontStyle.Bold);

		public DisplayItemTheme(Color foreColour, Color backColour, Color selectedForeColour, Color selectedBackColour, FontStyle fontStyle)
		{
			ForeColour = foreColour;
			BackColour = backColour;
			SelectedForeColour = selectedForeColour;
			SelectedBackColour = selectedBackColour;
			FontStyle = fontStyle;
		}

		public Color ForeColour { get; set; }
		public Color BackColour { get; set; }
		public Color SelectedForeColour { get; set; }
		public Color SelectedBackColour { get; set; }
		public FontStyle FontStyle { get; set; }
	}

	#endregion
}
