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

namespace СSharpLB4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            Table.ItemsSource = _viewModel.Teachers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Window window = new AddTeacherWindow(_viewModel);
           window.ShowDialog();
        }        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new AddSubjectWindow(_viewModel);
            window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window window = new RelationSetterWindow(_viewModel);
            window.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window = new SubjectsWindow(_viewModel);
            window.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window window = new DeleteTeacherWindow(_viewModel);
            window.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window window = new DeleteSubjectWindow(_viewModel);
            window.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            _viewModel.Serialize();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _viewModel.Deserialize();
            Table.ItemsSource = _viewModel.Teachers;
        }
    }
}
