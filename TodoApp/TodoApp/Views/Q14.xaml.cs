﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Q14 : ContentPage
    {
        public Q14()
        {
            InitializeComponent();
        }

        async private void bttnAceptar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Q15());
        }

    }
}