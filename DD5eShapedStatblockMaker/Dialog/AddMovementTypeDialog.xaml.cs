using DD5eShapedStatblockMaker.CharacterSheet.Definition;
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

namespace DD5eShapedStatblockMaker
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddMovementTypeDialog : Window
    {
        public AddMovementTypeDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sheet_MovementType.ItemsSource = Enum.GetValues(typeof(MovementType));
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
