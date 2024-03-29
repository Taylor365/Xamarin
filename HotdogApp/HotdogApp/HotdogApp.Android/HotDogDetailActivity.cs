﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HotdogApp.Droid.Utility;
using HotDogs.Model;
using HotDogs.Service;
using RaysHotDogs.Core;

namespace HotdogApp.Droid
{
    [Activity(Label = "Hot Dog Detail")]
    public class HotDogDetailActivity : Activity
    {
        private ImageView hotDogImageView;
        private TextView hotDogNameTextView;
        private TextView shortDescTextView;
        private TextView descTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;

        private HotDog selectedHotDog;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogDetailView);

            dataService = new HotDogDataService();

            var selectedHotDogId = Intent.Extras.GetInt("selectedHotDogId");
            selectedHotDog = dataService.GetHotDogById(selectedHotDogId);
            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            shortDescTextView = FindViewById<TextView>(Resource.Id.shortDesctextView);
            descTextView = FindViewById<TextView>(Resource.Id.desctextView);
            priceTextView = FindViewById<TextView>(Resource.Id.pricetextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            hotDogNameTextView.Text = selectedHotDog.Name;
            shortDescTextView.Text = selectedHotDog.ShortDescription;
            descTextView.Text = selectedHotDog.Description;
            priceTextView.Text = "Price: " + selectedHotDog.Price;


            var imageBitmap = ImgHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.ImagePath + ".jpg");

            hotDogImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SetResult(Result.Canceled);

            this.Finish();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(amountEditText.Text);
            AddToCart(selectedHotDog, amount);
            var intent = new Intent();
            intent.PutExtra("selectedHotDogId", selectedHotDog.HotDogId);
            intent.PutExtra("amount", amount);

            SetResult(Result.Ok, intent);

            this.Finish();
        }
        public void AddToCart(HotDog hotDog, int amount)
        {
            CartDataService cartDataService = new CartDataService();
            cartDataService.AddCartItem(hotDog, amount);
        }
    }
}