using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SailingUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// list<
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public List<string> namelist = LoadFullSQL.GetNames();
        public List<Boats> personboat = new List<Boats>();

        private async void enterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dropdown.SelectedValue != null && dropdown.SelectedValue != "")
                {
                    LoadFullSQL.SQLaddnewracer(personboat[dropdown.SelectedIndex]);
                    ContentDialog outputDialog = new ContentDialog()
                    {

                        Title = "You have been added to the race!",
                        Content = "You are sailing a(n) " + personboat[dropdown.SelectedIndex].boatName,
                        CloseButtonText = "Ok"
                    };
                    await outputDialog.ShowAsync();
                    dropdown.Items.Clear();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                boatnamebox.Visibility = Visibility.Visible;
                boatnumberbox.Visibility = Visibility.Visible;
                //enterButton.Visibility = Visibility.Visible;
                    
                    }
        }
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> namelist1 = namelist.FindAll(x => x.ToUpper().Contains(autoSuggest.Text.ToUpper()));
                autoSuggest.ItemsSource = namelist1;
            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
            sender.Text = args.SelectedItem.ToString();
        }


        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                dropdown.Items.Clear();
                //NoBoats.Visibility = Visibility.Collapsed;

                //Program1.hello(NameBox.Text);
                LoadFullSQL db1 = new LoadFullSQL();
                //Boats personboat = db1.GetBoat(person);
                personboat = db1.GetBoat(autoSuggest.Text);
                //Radio1.Visibility = Visibility.Collapsed;
                var i = 0;
                Thickness myThickness = new Thickness();
                myThickness.Bottom = 474;
                myThickness.Left = 171;
                myThickness.Right = 0;
                myThickness.Top = 00;
                //cboxitem.Content = "Created with C#";
                //dropdown.Items.Add(cboxitem);
                //dropdown.ItemsSource = "hi";
                foreach (Boats item in personboat)
                {
                    ComboBoxItem cboxitem = new ComboBoxItem();
                    cboxitem.Content = item.boatName + " " + item.boatNumber;
                    dropdown.Items.Add(cboxitem);


                    i++;
                }
                ComboBoxItem cboxitem1 = new ComboBoxItem();
                cboxitem1.Content = "new boat";
                dropdown.Items.Add(cboxitem1);

                if (i == 0)
                {
                    ContentDialog nameNotFoundDialog = new ContentDialog()
                    {
                        Title = "Your name is not contained in my records",
                        Content = "Add yourself and try again",
                        CloseButtonText = "Ok"
                    };
                    await nameNotFoundDialog.ShowAsync();
                }
            }
            else
            {
               
            }
        }

        private void enterbutton1_Click_1(object sender, RoutedEventArgs e)
        {
            LoadFullSQL.SQLAddboat(personboat[0].name, boatnamebox.Text, int.Parse(boatnumberbox.Text));
            boatnamebox.Visibility = Visibility.Collapsed;
            boatnumberbox.Visibility = Visibility.Collapsed;
            enterbutton1.Visibility = Visibility.Collapsed;
        }

        private void boatnamebox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public int i = 0;
        private void boatnumberbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                enterbutton1.Visibility = Visibility.Visible;
            }
        }
    }
    
}
