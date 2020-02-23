using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace AAB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines(@"C:\Windows\System32\drivers\etc\hosts");
            int K = lines.Length;
            if (K > 150)
            {
                moded.Content = "Moded";
                moded.Foreground = new SolidColorBrush(Colors.Red);
            } else
            {
                moded.Content = "Not Moded";
                moded.Foreground = new SolidColorBrush(Colors.Green);
            }


            var assembly = Assembly.GetExecutingAssembly();
            string hostfile = assembly.GetManifestResourceNames().Single(str => str.EndsWith("HOSTS"));

            using (Stream stream = assembly.GetManifestResourceStream(hostfile))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                var linesS = result.Split(new char[] { '\n' });
                long count = linesS.Length;
                hostlines.Content = count;

                string lsUpdated = linesS[9];
                lsUpdated = lsUpdated.Trim(new Char[] { ' ', '#', '-' });
                string[] upd = lsUpdated.Split(' ');
                lstupdt.Content = upd[1];
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string hostfile = assembly.GetManifestResourceNames().Single(str => str.EndsWith("HOSTS"));

            using (Stream stream = assembly.GetManifestResourceStream(hostfile))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                File.WriteAllText(@"C:\Windows\System32\drivers\etc\hosts", result);
                MessageBox.Show("Host File Updated!","Host File Updated!");
            }

            string[] lines = File.ReadAllLines(@"C:\Windows\System32\drivers\etc\hosts");
            int K = lines.Length;
            if (K > 150)
            {
                moded.Content = "Moded";
                moded.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                moded.Content = "Not Moded";
                moded.Foreground = new SolidColorBrush(Colors.Green);
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"C:\Windows\System32\drivers\etc\hosts", "");
            MessageBox.Show("Host File Cleared", "Host File Cleared");
            string[] lines = File.ReadAllLines(@"C:\Windows\System32\drivers\etc\hosts");
            int K = lines.Length;
            if (K > 150)
            {
                moded.Content = "Moded";
                moded.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                moded.Content = "Not Moded";
                moded.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        private void openhostfile_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"C:\Windows\System32\drivers\etc\hosts");
        }

        private void cdev_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:srilalsachintha@gmail.com");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
