using DD5eShapedStatblockMaker.CharacterSheet;
using DD5eShapedStatblockMaker.CharacterSheet.Definition;
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
            var result = dialog.ShowDialog();

            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value == true)
            {
                var insertIndex = Sheet_MovementType.Children.Count - 1;
                var leadingText = new TextBlock();
                leadingText.Text = $", {(MovementType)dialog.Sheet_MovementType.SelectedIndex} ";
                var speedInputBox = new TextBox();
                speedInputBox.TextChanged += new TextChangedEventHandler(TextChanged);
                var trailingText = new TextBlock();
                trailingText.Text = "ft";

                leadingText.PreviewMouseDown += new MouseButtonEventHandler((obj, arg) =>
                {
                    Sheet_MovementType.Children.Remove(leadingText);
                    Sheet_MovementType.Children.Remove(speedInputBox);
                    Sheet_MovementType.Children.Remove(trailingText);
                });

                Sheet_MovementType.Children.Insert(insertIndex, trailingText);
                Sheet_MovementType.Children.Insert(insertIndex, speedInputBox);
                Sheet_MovementType.Children.Insert(insertIndex, leadingText);
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
