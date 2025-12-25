using System;
using System.Windows;
// This line allows C# to communicate with external DLLs
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace VitalsUI
{
    public partial class MainWindow : Window
    {
        // This links the C# function to the actual C++ function in the DLL
        [DllImport("VitalsEngine.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetCpuTemp();

        //  this is our timer object
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
        }

        private void SetupTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                float currentTemp = GetCpuTemp();

                TempDisplay.Text = currentTemp.ToString("0.0") + "°C";
            }
            catch (Exception)
            {
                TempDisplay.Text = "ERR";
                TempDisplay.Foreground = System.Windows.Media.Brushes.Red;
            }
        }


        // This runs when you click the button we added to the XAML
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Call the C++ engine!
                float currentTemp = GetCpuTemp();

                // Update the text on your screen
                TempDisplay.Text = "CPU Temp: " + currentTemp.ToString() + "°C";
            }
            catch (Exception ex)
            {
                // This will pop up if the DLL is missing or in the wrong folder
                MessageBox.Show("Error connecting to Engine: " + ex.Message);
            }
        }
    }
}