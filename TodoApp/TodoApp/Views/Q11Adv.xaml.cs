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
    public partial class Q11Adv : ContentPage
    {
        public Q11Adv()
        {
            InitializeComponent();
        }

        async private void bttnAceptar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Q12());
        }
    }
}