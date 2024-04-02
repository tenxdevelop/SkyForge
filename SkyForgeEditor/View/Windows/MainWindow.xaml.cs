﻿using SkyForgeEditor.View.Windows;
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

namespace SkyForgeEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoadedEvent;

        }


        private void OnLoadedEvent(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoadedEvent;
            LoadProjectWindow();
        }

        private void LoadProjectWindow()
        {
            var projectBrowserWindow = new ProjectBrowserWindow();

            if (projectBrowserWindow.ShowDialog() == false)
            {
                Application.Current.Shutdown();
            }
            else
            {

            }
        }

    }
}