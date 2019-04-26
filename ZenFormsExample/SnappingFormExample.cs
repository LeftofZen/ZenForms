using System.Windows.Forms;
using ZenForms.Forms;

namespace ZenForms.Examples
{
	public partial class SnappingFormExample : Form
	{
		public SnappingFormExample()
		{
			InitializeComponent();
			Text = "Form Snapping Demo";

			var btn = new Button();
			btn.Click += (e, a) => AddForm();
			btn.Text = "Add a form";
			Controls.Add(btn);
		}

		void AddForm()
		{
			var sf = new SnappingForm();
			Controls.Add(sf);
		}
	}

}
