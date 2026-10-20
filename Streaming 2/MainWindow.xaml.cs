using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Streaming_2
{
    public partial class MainWindow : Window
    {
        private StreamingPlatform platform = new StreamingPlatform();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            RefreshList();
        }

        private void LoadData()
        {
            platform.LoadFromFile("data.txt");
        }

        private void RefreshList(string filter = "")
        {
            var query = platform.Contents.AsEnumerable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(c => c.GetTitle().ToLower().Contains(filter.ToLower()));
            }

            LstCatalog.ItemsSource = query.Select(c => $"{c.GetTitle()} - {c.GetLength()} perc").ToList();
        }

        private void BtnLongest_Click(object sender, RoutedEventArgs e)
        {
            var longest = platform.GetLongestContent();
            if (longest != null)
            {
                MessageBox.Show($"A leghosszabb: {longest.GetTitle()} ({longest.GetLength()} perc)");
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshList(TxtSearch.Text);
        }
    }
}