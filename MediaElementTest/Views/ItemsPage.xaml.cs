using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MediaElementTest.Models;
using MediaElementTest.Views;
using MediaElementTest.ViewModels;

namespace MediaElementTest.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            TheMedia.IsVisible = true;
            TheMedia.HeightRequest = height > width ? this.Height / 3 : this.Height;

            if (Device.RuntimePlatform == Device.iOS)
            {
                if(Device.Idiom == TargetIdiom.Phone)
                {
                    TheMedia.Source = item.MediumQualityURL;
                }
                else
                {
                    TheMedia.Source = item.LowQualityURL;
                }
            }
            else
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    TheMedia.Source = item.LowQualityURL;
                }
                else
                {
                    TheMedia.Source = item.MediumQualityURL;
                }
            }
            TheMedia.Play();


        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                if (TheMedia.Source != null)
                {

                    if (height > width)
                    {
                        TheMedia.HeightRequest = this.Height / 3;
                        TheMedia.VerticalOptions = LayoutOptions.Start;
                        ItemsCollectionView.IsVisible = true;

                    }
                    else
                    {
                        ItemsCollectionView.IsVisible = false;
                        //TheMedia.HeightRequest = TheMedia.VideoHeight;
                        TheMedia.VerticalOptions = LayoutOptions.FillAndExpand;
                        TheMedia.HeightRequest = this.height;
                    }
                }


            }
        }
    }
}