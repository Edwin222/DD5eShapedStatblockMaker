using DD5eShapedStatblockMaker.Data;
using System.Windows;
using System.Windows.Controls;

namespace DD5eShapedStatblockMaker
{
    public partial class MainWindow : Window
    {
        readonly CharacterSheet sheet;
        public MainWindow()
        {
            sheet = new CharacterSheet();
            InitializeComponent();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            sheet.Name = (sender as TextBox).Text;
        }

        private void Alignment_TextChanged(object sender, TextChangedEventArgs e)
        {
            sheet.Alignment = (sender as TextBox).Text;
        }

        private void Tag_TextChanged(object sender, TextChangedEventArgs e)
        {
            sheet.TypeTag = (sender as TextBox).Text;
        }
    }
}
