using IFS.Mobile.Controls;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RadialProgressBar
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ProgressBarPage : ContentPage
  {
    SKPaintSurfaceEventArgs args;
    RadialProgressUtils progressUtils = new RadialProgressUtils();

    public ProgressBarPage()
    {
      InitializeComponent();
    }

    public async void OnCanvasViewPaintSurfaceAsync(object sender, SKPaintSurfaceEventArgs args1)
    {
      args = args1;
      await DrawGaugeAsync();

    }

    public async Task DrawGaugeAsync()
    {
      // Radial Gauge Constants
      int uPadding = 150;
      int side = 500;
      int radialGaugeWidth = 15;

      // Line TextSize inside Radial Gauge
      int lineSize1 = 250;
      int lineSize2 = 120;

      // Line Y Coordinate inside Radial Gauge
      int lineHeight1 = 100;
      int lineHeight2 = 200;

      // Start & End Angle for Radial Gauge
      float startAngle = 0;
      float sweepAngle = 360;

      try
      {
        // Getting Canvas Info 
        SKImageInfo info = args.Info;
        SKSurface surface = args.Surface;
        SKCanvas canvas = surface.Canvas;
        progressUtils.setDevice(info.Height, info.Width);
        canvas.Clear();

        // Getting Device Specific Screen Values
        // -------------------------------------------------

        // Top Padding for Radial Gauge
        float upperPading = progressUtils.getFactoredHeight(uPadding);

        /* Coordinate Plotting for Radial Gauge
        *
        *    (X1,Y1) ------------
        *           |   (XC,YC)  |
        *           |      .     |
        *         Y |            |
        *           |            |
        *            ------------ (X2,Y2))
        *                  X
        *   
        *To fit a perfect Circle inside --> X==Y
        *       i.e It should be a Square
        */

        // Xc & Yc are center of the Circle
        int Xc = info.Width / 2;
        float Yc = info.Height / 2; //progressUtils.getFactoredHeight(side);

        // X1 Y1 are lefttop cordiates of rectange
        int X1 = (int)(Xc - Yc);
        int Y1 = (int)(Yc - Yc + upperPading);

        // X2 Y2 are rightbottom cordiates of rectange
        int X2 = (int)(Xc + Yc);
        int Y2 = (int)(Yc + Yc - upperPading);

        //Loggig Screen Specific Calculated Values
        Debug.WriteLine("INFO " + info.Width + " - " + info.Height);
        Debug.WriteLine(" C : " + upperPading + "  " + info.Height);
        Debug.WriteLine(" C : " + Xc + "  " + Yc);
        Debug.WriteLine("XY : " + X1 + "  " + Y1);
        Debug.WriteLine("XY : " + X2 + "  " + Y2);

        //  Empty Gauge Styling
        SKPaint paint1 = new SKPaint
        {
          Style = SKPaintStyle.Stroke,
          Color = Color.FromHex("#17224D").ToSKColor(),                   // Colour of Radial Gauge
          StrokeWidth = progressUtils.getFactoredWidth(radialGaugeWidth) // Width of Radial Gauge
        };

        // Filled Gauge Styling
        SKPaint paint2 = new SKPaint
        {
          Style = SKPaintStyle.Stroke,
          Color = Color.FromHex("#007FFF").ToSKColor(),                   // Overlay Colour of Radial Gauge
          StrokeWidth = progressUtils.getFactoredWidth(radialGaugeWidth) // Overlay Width of Radial Gauge
        };

        // Defining boundaries for Gauge
        SKRect rect = new SKRect(X1, Y1, X2, Y2);

        //canvas.DrawRect(rect, paint1);
        //canvas.DrawOval(rect, paint1);

        // Rendering Empty Gauge
        SKPath path1 = new SKPath();
        path1.AddArc(rect, startAngle, sweepAngle);
        //path1.AddCircle(Xc, Yc, 20, SKPathDirection.Clockwise);
        canvas.DrawPath(path1, paint1);

        // Rendering Filled Gauge
        SKPath path2 = new SKPath();
        path2.AddArc(rect, startAngle, 90);
        canvas.DrawPath(path2, paint2);

        //---------------- Drawing Text Over Gauge ---------------------------

        // Achieved Minutes
        using (SKPaint skPaint = new SKPaint())
        {
          skPaint.Style = SKPaintStyle.Fill;
          skPaint.IsAntialias = true;
          skPaint.Color = SKColor.Parse("#212121");
          skPaint.TextAlign = SKTextAlign.Center;
          skPaint.TextSize = progressUtils.getFactoredHeight(lineSize1);
          skPaint.Typeface = SKTypeface.FromFamilyName(
                              "Arial",
                              SKFontStyleWeight.Normal,
                              SKFontStyleWidth.Normal,
                              SKFontStyleSlant.Upright);

          // Drawing Completeness Over Radial Gauge
          canvas.DrawText("75%", Xc, Yc + progressUtils.getFactoredHeight(lineHeight1), skPaint);
        }

        // Achieved Minutes Text Styling
        using (SKPaint skPaint = new SKPaint())
        {
          skPaint.Style = SKPaintStyle.Fill;
          skPaint.IsAntialias = true;
          skPaint.Color = SKColor.Parse("#212121");
          skPaint.TextAlign = SKTextAlign.Center;
          skPaint.TextSize = progressUtils.getFactoredHeight(lineSize2);

          canvas.DrawText("Complete", Xc, Yc + progressUtils.getFactoredHeight(lineHeight2), skPaint);
        }
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.StackTrace);
      }
    }
  }
}