using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TipCalculator
{
  [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
  public class MainActivity : AppCompatActivity
  {
    EditText inputBill;
    Button calculateButton;
    TextView outputTip;
    TextView outputTotal;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      SetContentView(Resource.Layout.activity_main);

      inputBill = FindViewById<EditText>(Resource.Id.inputBill);
      outputTip = FindViewById<TextView>(Resource.Id.outputTip);
      outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
      calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

      calculateButton.Click += CalculateButton_Click;
      
    }

    private void CalculateButton_Click(object sender, EventArgs e)
    {
      string text = inputBill.Text;
      double bill = 0;
      if (double.TryParse(text, out bill))
      {
        var tip = bill * 0.15;
        var total = bill + tip;

        outputTip.Text = tip.ToString();
        outputTotal.Text = total.ToString();
      }
    }
  }
}