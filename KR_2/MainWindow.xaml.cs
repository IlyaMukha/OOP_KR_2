using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace KR_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> books = new List<Book>();
        public MainWindow()
        {
            InitializeComponent();
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you have save?", "Books", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        try
                        {
                            books = JsonConvert.DeserializeObject<List<Book>>(sr.ReadToEnd());
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void _create_Click(object sender, RoutedEventArgs e)
        {
            CreateBook createBook = new CreateBook();
            createBook.ShowDialog();
            books.Add(createBook.NumUpDown);
            
        }

        private void _show_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in books)
            {
                item.GetInfo();
            }
        }

        private void _save_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(openFileDialog.FileName, false, System.Text.Encoding.UTF8))
                {
                    sw.Write("[");
                    foreach (var item in books)
                    {
                        sw.Write(JsonConvert.SerializeObject(item)+",");
                    }
                    sw.Write("]");
                }
            }
        }
    }
}
