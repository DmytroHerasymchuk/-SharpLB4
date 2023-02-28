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

namespace СSharpLB4
{
    /// <summary>
    /// Логика взаимодействия для DeleteTeacherWindow.xaml
    /// </summary>
    public partial class DeleteTeacherWindow : Window
    {
        private ViewModel _viewModel { get; set; }
        public DeleteTeacherWindow(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            TeachersCB.ItemsSource = viewModel.Teachers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.IsComboBoxValid(TeachersCB))
            {
                _viewModel.RemoveTeacher((Teacher)TeachersCB.SelectedItem);
            }
        }
    }
}
