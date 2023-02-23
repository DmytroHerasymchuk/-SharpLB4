﻿using System;
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
    /// Логика взаимодействия для RelationSetterWindow.xaml
    /// </summary>
    public partial class RelationSetterWindow : Window
    {
        private ViewModel _viewModel { get; set; }
        public RelationSetterWindow(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            TeachersCB.ItemsSource = _viewModel.Teachers;
            SubjectsCB.ItemsSource = _viewModel.Subjects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SetRelation((Teacher)TeachersCB.SelectedItem, (Subject)SubjectsCB.SelectedItem);
        }
    }
}
