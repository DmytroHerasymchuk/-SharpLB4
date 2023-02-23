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
    /// Логика взаимодействия для AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        private ViewModel _viewModel { get; set; }
        public AddTeacherWindow(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddTeacher(new Teacher(NameTB.Text, SurnameTB.Text));
        }
    }
}
