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
using Microsoft.Win32;
using System.IO;

namespace Notepad_menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string firstdoc = "";
        public void saveFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Document";
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Text documents (.txt)|*.txt";
            saveFile.ShowDialog();
            string dir = saveFile.FileName;
            string txt = mainText.Text;
            File.WriteAllText(dir, txt);
            MessageBox.Show("File Saved.");

        }
        public void openFile()
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = ".txt";
            openFile.Filter = "Text documents (.txt)|*.txt";
            openFile.ShowDialog();
            string dir = openFile.FileName;
            string file = File.ReadAllText(dir);
            mainText.Text = file;
            firstdoc = file;
        }
        private void openClick(object sender, RoutedEventArgs e)
        {
            if (mainText.Text == "")
            {
                openFile();
            }
            else
            {
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show("Do you want to save your file?", "", buttons, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    saveFile();
                    openFile();
                }
                else
                {
                    openFile();
                }
            }
        }

        private void saveClick(object sender, RoutedEventArgs e)
        {
            saveFile();

        }

        private void newClick(object sender, RoutedEventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var result = MessageBox.Show("Are you sure?", "", buttons, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                mainText.Clear();
            }
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            if (mainText.Text != firstdoc)
            {
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show("Do you want to save your file?", "", buttons, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    saveFile();

                }
            }
            MessageBox.Show("Goodbye.");
            Application.Current.Shutdown();
        

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
        }
    }
}
