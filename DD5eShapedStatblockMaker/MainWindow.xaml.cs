using DD5eShapedStatblockMaker.CharacterSheet;
using DD5eShapedStatblockMaker.CharacterSheet.Definition;
using DD5eShapedStatblockMaker.Control;
using DD5eShapedStatblockMaker.Data.Definition;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DD5eShapedStatblockMaker
{
    public partial class MainWindow : Window
    {
        readonly Character sheet;

        bool isLoaded;
        MovementTypeControl movementTypeControl;

        public MainWindow()
        {
            isLoaded = false;
            sheet = new Character();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sheet_Size.ItemsSource = Enum.GetValues(typeof(CreatureSize));
            Sheet_Type.ItemsSource = Enum.GetValues(typeof(RacialType));
            movementTypeControl = new MovementTypeControl(Sheet_MovementType, TextChanged);
            isLoaded = true;
            RefreshSheet();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            sheet.WriteData();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshSheet();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshSheet();
        }

        private void AddMovementType_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddMovementTypeDialog();
            dialog.ShowDialog();

            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value == true)
            {
                var type = (MovementType) dialog.Sheet_MovementType.SelectedIndex;
                movementTypeControl.SetSpeed(type, 0);
            }
        }

        void RefreshSheet()
        {
            if (isLoaded)
            {
                sheet.PersonalInfo = new PersonalInfo(
                    Sheet_Name.Text,
                    (CreatureSize)Sheet_Size.SelectedIndex,
                    (RacialType)Sheet_Type.SelectedIndex,
                    Sheet_Tag.Text,
                    Sheet_Alignment.Text);
            }
        }
    }
}
