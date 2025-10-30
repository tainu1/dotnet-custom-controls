using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfCustomControlLibrary1.Controls
{
    public class DigitalClock : Control
    {
        private TextBlock? date;
        private TextBlock? time;
        static DigitalClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalClock), new FrameworkPropertyMetadata(typeof(DigitalClock)));
        }

        public override void OnApplyTemplate()
        {
            date = Template.FindName("Date", this) as TextBlock;
            time = Template.FindName("Time", this) as TextBlock;

            UpdateClockTime();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (e, s) => { UpdateClockTime(); };
            timer.Start();

            base.OnApplyTemplate();
        }

        private void UpdateClockTime()
        {
            date.Text = DateTime.Now.ToString("yyyy/MM/dd(ddd)");
            time.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
