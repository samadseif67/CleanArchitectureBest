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

namespace WpfOnelineShop
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

        //در رویداد کلیک سمت فرانت این تابع ها صدا زده میشود
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;//نمایش داده شود
            PersonPanel.Visibility = Visibility.Collapsed;//پنهان شود
            ProductPanel.Visibility = Visibility.Collapsed;//پنهان شود
        }

        private void BtnPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonPanel.Visibility = Visibility.Visible;//نمایش داده شود
            HomePanel.Visibility = Visibility.Collapsed;//پنهان شود
            ProductPanel.Visibility = Visibility.Collapsed;//پنهان شود
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductPanel.Visibility = Visibility.Visible;//نمایش داده شود
            HomePanel.Visibility = Visibility.Collapsed;//پنهان شود
            PersonPanel.Visibility = Visibility.Collapsed;//پنهان شود
        }
    }
}
