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
using System.Windows.Shapes;

namespace KR_2
{
    /// <summary>
    /// Interaction logic for CreateBook.xaml
    /// </summary>
    public partial class CreateBook : Window
    {
        public string genre;
        public CreateBook()
        {
            InitializeComponent();
        }
        private Book numUpDownVal;
        public Book NumUpDown
        {
            get
            {
                return numUpDownVal;
            }
            set
            {
                numUpDownVal = value;
            }
        }
        void WriteText2(object sender, RoutedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);
            genre = li.Content.ToString();
        }

        private void _create_Click(object sender, RoutedEventArgs e)
        {
            
            int? temp;
            try
            {
                temp = Convert.ToInt32(_year.Text);
            }
            catch
            {
                temp = null;
            }
            NumUpDown = new Book(_name.Text, _author.Text, _publishing.Text, temp, genre);
            this.Close();
        }
    }
}
