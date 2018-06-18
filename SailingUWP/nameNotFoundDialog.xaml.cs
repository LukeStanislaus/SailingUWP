using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SailingUWP
{
    public sealed partial class nameNotFoundDialog : ContentDialog
    {
        
        public nameNotFoundDialog()
        {
            this.InitializeComponent();
        }
        
        
        public void nameNotFoundDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            LoadFullSQL.SQLremove(true, Globals.personboat[0].name);
            MainPage a = new MainPage();
            a.clearname();
        }
        

    }
}
