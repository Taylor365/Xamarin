using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCalculator
{
	public partial class MainPage : ContentPage
	{
        Button Plus, Minus, Divide, Multiply, Enter;
        Button[] Keypad;

        Label ResultLabel = new Label();
        Label BufferLabel = new Label();

        private double buffer = 0;
        public double Buffer
        {
            get
            {
                return buffer;
            }
            set { buffer = value; BufferLabel.Text = buffer.ToString(); }
        }

        private double result;
        public double Result
        {
            get
            {
                return result;
            }
            set { result = value; ResultLabel.Text = result.ToString(); }
        }

		public MainPage()
		{
            try
            {
                InitializeComponent();

                Plus = new Button() { Text = "+" };
                Minus = new Button() { Text = "-" };
                Divide = new Button() { Text = "/" };
                Multiply = new Button() { Text = "*" };
                Enter = new Button() { Text = "Enter" };

                Plus.Pressed += Plus_Pressed;
                Minus.Pressed += Minus_Pressed;
                Divide.Pressed += Divide_Pressed;
                Multiply.Pressed += Multiply_Pressed;
                Enter.Pressed += Enter_Pressed;

                Keypad = new Button[10];
                for (var i = 0; i < Keypad.Count(); i++)
                {
                    ref var button = ref Keypad[i];
                    button = new Button() { Text = i.ToString() };
                    int j = i;
                    button.Pressed += (o, e) => { KeypadButton_Pressed(j); };
                }

                var grid = new AutoGrid();
                grid.DefineGrid(3, 6);

                grid.AutoAdd(BufferLabel);
                grid.AutoAdd(ResultLabel, 2);

                for (var i = Keypad.Count() - 1; i >= 0; i--)
                {
                    ref var button = ref Keypad[i];

                    if (i != 0)
                    {
                        grid.AutoAdd(button);
                    }
                    else
                        grid.AutoAdd(button, 2);
                }

                grid.AutoAdd(Plus);
                grid.AutoAdd(Minus);
                grid.AutoAdd(Divide);
                grid.AutoAdd(Multiply);
                //grid.AutoAdd(Enter);

                Content = grid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "     " + e.Source);
            }
			
        }



        #region Operation_Buttons
        private void KeypadButton_Pressed(int i)
        {
            Buffer *= 10.0;
            Buffer += i;

        }

        private void Enter_Pressed(object sender, EventArgs e)
        {
            Result = Buffer;
        }

        private void Multiply_Pressed(object sender, EventArgs e)
        {
            Result *= Buffer;
            Buffer = 0.0;
        }

        private void Divide_Pressed(object sender, EventArgs e)
        {
            Result /= Buffer;
            Buffer = 0.0;
        }

        private void Minus_Pressed(object sender, EventArgs e)
        {
            Result -= Buffer;
            Buffer = 0.0;
        }

        private void Plus_Pressed(object sender, EventArgs e)
        {
            Result += Buffer;
            Buffer = 0.0;
        }
        #endregion
    }
}
