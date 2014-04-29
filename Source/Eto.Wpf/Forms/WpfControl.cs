using Eto.Forms;
using Eto.Drawing;
using Eto.Wpf.Drawing;
using swc = System.Windows.Controls;
using sw = System.Windows;

namespace Eto.Wpf.Forms
{
	public class WpfControl<TControl, TWidget> : WpfFrameworkElement<TControl, TWidget>, IControl
		where TControl : swc.Control
		where TWidget: Control
	{
		Font font;

		public override Color BackgroundColor
		{
			get { return (ContainerControl as swc.Control ?? Control).Background.ToEtoColor(); }
			set { (ContainerControl as swc.Control ?? Control).Background = value.ToWpfBrush(Control.Background); }
		}

		protected virtual void SetDecorations(sw.TextDecorationCollection decorations)
		{
		}

		public Font Font
		{
			get
			{
				if (font == null)
					font = new Font(Widget.Platform, new FontHandler(Widget.Platform, Control));
				return font;
			}
			set
			{
				font = value;
				FontHandler.Apply (Control, SetDecorations, font);
			}
		}

	}
}