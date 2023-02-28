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
using СSharpLB4.ViewModels;

namespace СSharpLB4.Views
{
    /// <summary>
    /// Логика взаимодействия для SubjectsWindow.xaml
    /// </summary>
    public partial class SubjectsWindow : Window
    {
        private ViewModel _viewModel { get; set; }
        public SubjectsWindow(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            Subjects.ItemsSource = _viewModel.Subjects;
        }
    }
}
