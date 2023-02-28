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
using СSharpLB4.Core;
using СSharpLB4.Models;

namespace СSharpLB4.Views
{
    /// <summary>
    /// Логика взаимодействия для AddSubjectWindow.xaml
    /// </summary>
    public partial class AddSubjectWindow : Window
    {
        private ViewModel _viewModel { get; set; }
        public AddSubjectWindow(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.IsTextBoxValid(NameTB))
            {
                _viewModel.AddSubject(new Subject(NameTB.Text));
            }
        }
    }
}
