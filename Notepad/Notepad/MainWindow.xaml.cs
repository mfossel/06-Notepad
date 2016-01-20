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

namespace Notepad
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

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string dir = openFile.FileName;
            string file = File.ReadAllText(dir);
            mainText.Text = file;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "txt";
            saveFile.ShowDialog();
            string dir = saveFile.FileName;
            string txt = mainText.Text;
            File.WriteAllText(dir, txt);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainText.Clear();
        }

       

       

    }
}
