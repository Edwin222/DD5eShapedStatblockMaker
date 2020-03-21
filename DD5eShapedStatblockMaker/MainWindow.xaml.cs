using DD5eShapedStatblockMaker.CharacterSheet;
using DD5eShapedStatblockMaker.Data.Definition;
using System;
using System.Windows;
using System.Windows.Controls;

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

        private void PersoanlInfo_TextChanged(object sender, TextChangedEventArgs e)
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

        private void PersonalInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        void RefreshSheet()
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
