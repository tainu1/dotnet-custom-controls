using System.Windows;
using System.Windows.Controls.Primitives;

namespace WpfCustomControlLibrary1.Controls
{
    public class ToggleControl : ToggleButton
    {
        static ToggleControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleControl), new FrameworkPropertyMetadata(typeof(ToggleControl)));
        }
    }
}
