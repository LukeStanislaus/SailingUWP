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
    public class Globals
    {
        public static List<string> namelist = LoadFullSQL.GetNames();
        public static List<string> classlist = LoadFullSQL.GetClasses();
        public static List<Boats> personboat = new List<Boats>();

    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public int g = 0;

        private async void enterButton_Click(object sender, RoutedEventArgs e)
        {
            g = dropdown.SelectedIndex;
            /*
            if (LoadFullSQL.SQLcheckcrew(Globals.personboat[dropdown.SelectedIndex].boatName) == 1)
            crew.Visibility = Visibility.Visible;
            */

            try
            {
                if (dropdown.SelectedValue != null && dropdown.SelectedValue != "")
                {
                    try
                    {
                        /*
                        if (crew.IsChecked.Equals(true))
                        {
                        */
                            LoadFullSQL.SQLaddnewracer(Globals.personboat[dropdown.SelectedIndex], 0);
                        if (LoadFullSQL.SQLcheckcrew(Globals.personboat[dropdown.SelectedIndex].boatName) == 1)
                            crew.Visibility = Visibility.Visible;
                        //}

                        ContentDialog outputDialog = new ContentDialog()
                        {

                            Title = "You have been added to the race!",
                            Content = "You are sailing a(n) " + Globals.personboat[dropdown.SelectedIndex].boatName,
                            CloseButtonText = "Ok"

                        };
                        await outputDialog.ShowAsync();
                        dropdown.Items.Clear();
                    }
                    catch
                    {
                        //string hi =  nameNotFoundDialog.ShowAsync();
                        nameNotFoundDialog nameNotFoundDialog = new nameNotFoundDialog();
                        await nameNotFoundDialog.ShowAsync();
                        //if ( == nameNotFoundDialog.PrimaryButtonClick)
                            //LoadFullSQL.SQLremove(true, personboat[0].name);
                        dropdown.Items.Clear();
                    }
                }
                else
                {
                    ContentDialog nameNotFoundDialog = new ContentDialog()
                    {
                        Title = "You must input somethin",
                        Content = "Write something and try again",
                        CloseButtonText = "Ok"
                    };
                    await nameNotFoundDialog.ShowAsync();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                boatnameauto.Visibility = Visibility.Visible;
                boatnumberbox.Visibility = Visibility.Visible;
                //a = Visibility.Visible;

            }
        }
    
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> namelist1 = Globals.namelist.FindAll(x => x.ToUpper().Contains(autoSuggest.Text.ToUpper()));
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
                Globals.personboat = db1.GetBoat(autoSuggest.Text);
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
                foreach (Boats item in Globals.personboat)
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
        
        private void boatnameauto_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> classlist1 = Globals.classlist.FindAll(x => x.ToUpper().Contains(boatnameauto.Text.ToUpper()));
                boatnameauto.ItemsSource = classlist1;
                
            }
        }
        private void enterbutton1_Click_1(object sender, RoutedEventArgs e)
        {
            LoadFullSQL.SQLAddboat(Globals.personboat[0].name, boatnameauto.Text, int.Parse(boatnumberbox.Text));
            boatnameauto.Visibility = Visibility.Collapsed;
            boatnumberbox.Visibility = Visibility.Collapsed;
            enterbutton1.Visibility = Visibility.Collapsed;
            autoSuggest.Focus(FocusState.Keyboard);
            autoSuggest.Text = "";
            dropdown.Items.Clear();
        }

        public int i = 0;
        private void boatnumberbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                enterbutton1.Visibility = Visibility.Visible;
            }
        }

        private void boatnameauto_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void autoSuggestCrew_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> namelist1 = Globals.namelist.FindAll(x => x.ToUpper().Contains(autoSuggestCrew.Text.ToUpper()));
                autoSuggestCrew.ItemsSource = namelist1;
            }
        }


        private void autoSuggestCrew_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
            sender.Text = args.SelectedItem.ToString();
        }


        private async void autoSuggestCrew_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {

                //NoBoats.Visibility = Visibility.Collapsed;

                //Program1.hello(NameBox.Text);
                LoadFullSQL db1 = new LoadFullSQL();
                //Boats personboat = db1.GetBoat(person);
                // Globals.personboat = db1.GetBoat(autoSuggestCrew.Text);
                //Radio1.Visibility = Visibility.Collapsed;
                var i = 0;

                //cboxitem.Content = "Created with C#";
                //dropdown.Items.Add(cboxitem);
                //dropdown.ItemsSource = "hi";
                Boats boat1 = new Boats(args.ChosenSuggestion.ToString(), Globals.personboat[g].boatName,
                    Globals.personboat[g].boatNumber);
                try
                {
                    LoadFullSQL.SQLaddnewracer(boat1, 1);
                    ContentDialog outputDialog = new ContentDialog()
                    {

                        Title = "You have been added to the race!",
                        Content = "You are sailing a(n) " + Globals.personboat[g].boatName,
                        CloseButtonText = "Ok"
                };
                    await outputDialog.ShowAsync();
                    autoSuggestCrew.Visibility = Visibility.Collapsed;
                    crew.Visibility = Visibility.Collapsed;
                    crew.IsChecked = false;
                    autoSuggest.Text = "";
                }

                
                catch
                { 
                    ContentDialog nameNotFoundDialog = new ContentDialog()
                    {
                        Title = "Your crew name is not contained in my records",
                        Content = "Add yourself and try again, could already be added?",
                        CloseButtonText = "Ok"
                    };
                    await nameNotFoundDialog.ShowAsync();
                }
                
            }
            else
            {

            }
        }
        private void crew_Checked(object sender, RoutedEventArgs e)
        {
            autoSuggestCrew.Visibility = Visibility.Visible;
        }
        public void clearname()
        {
            autoSuggest.Text = "";
        }

    }
    
}
