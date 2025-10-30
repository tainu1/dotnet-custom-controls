using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfCustomControlLibrary1.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary1"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary1;assembly=WpfCustomControlLibrary1"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:AnalogClock/>
    ///
    /// </summary>
    public class AnalogClock : Control
    {
        private Line? hourHand;
        private Line? minuteHand;
        private Line? secondHand;
        static AnalogClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }
        public override void OnApplyTemplate()
        {
            hourHand = Template.FindName("HourHand", this) as Line;
            minuteHand = Template.FindName("MinuteHand", this) as Line;
            secondHand = Template.FindName("SecondHand", this) as Line;

            UpdateHandAngles();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (e, s) => { UpdateHandAngles(); };
            timer.Start();

            base.OnApplyTemplate();
        }

        private void UpdateHandAngles()
        {
            hourHand.RenderTransform = new RotateTransform(DateTime.Now.Hour / 12.0 * 360, 0.5, 0.5);
            minuteHand.RenderTransform = new RotateTransform(DateTime.Now.Minute / 60.0 * 360, 0.5, 0.5);
            secondHand.RenderTransform = new RotateTransform(DateTime.Now.Second / 60.0 * 360, 0.5, 0.5);
        }
    }
}