﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {
        public NotesListPage()
        {
            InitializeComponent();
            this.BindingContext = new NotesListPageViewModel() { Navigation = this.Navigation };
        }
    }
}