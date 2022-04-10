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

namespace KT_1.View.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для CreateFabricWindow.xaml
    /// </summary>
    public partial class CreateFabricWindow : Window
    {
        public CreateFabricWindow()
        {
            InitializeComponent();
        }

        private void AddComposition_Click(object sender, RoutedEventArgs e)
        {
            CompositionListBox.Items.Add(CompositionTextBox.Text);
        }

        private void DeleteComposition_Click(object sender, RoutedEventArgs e)
        {
            CompositionListBox.Items.Remove(CompositionListBox.SelectedItem);
        }
    }
}
