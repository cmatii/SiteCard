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
    public partial class Q5 : ContentPage
    {
        public Q5()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Q6());
        }
    }
}