using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragandDropDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DragandDropPage : ContentPage
	{
		public DragandDropPage ()
		{
			InitializeComponent ();
		}

        public bool NewPosition { get; private set; }
        public double ReferenceX { get; private set; }
        public double ReferenceY { get; private set; }
        public double XCoordinate { get; private set; }
        public double YCoordinate { get; private set; }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (ReferenceX == 0 && ReferenceY == 0)
            {
                ReferenceX = layout1.X;
                ReferenceY = layout1.Y;
            }

            double Proximity = 60;
            //if(e.TotalX==0 && e.TotalY == 0)
            //    image2.IsVisible = false;
            
            if (e.StatusType == GestureStatus.Running)
            {
                XCoordinate = e.TotalX;
                YCoordinate = e.TotalY;
            }
            if (e.StatusType == GestureStatus.Completed)
            {
                image2.IsVisible = false;
            }
            await image2.TranslateTo(e.TotalX, e.TotalY);

            if (e.StatusType == GestureStatus.Completed)
            {
                var DifX1 = Math.Abs(layout1.X - XCoordinate - ReferenceX);
                var DifY1 = Math.Abs(layout1.Y - YCoordinate - ReferenceY);
                var DifX2 = Math.Abs(layout2.X - XCoordinate - ReferenceX);
                var DifY2 = Math.Abs(layout2.Y - YCoordinate - ReferenceY);
                var DifX3 = Math.Abs(layout3.X - XCoordinate - ReferenceX);
                var DifY3 = Math.Abs(layout3.Y - YCoordinate - ReferenceY);
                var DifX4 = Math.Abs(layout4.X - XCoordinate - ReferenceX);
                var DifY4 = Math.Abs(layout4.Y - YCoordinate - ReferenceY);

                if ((layout1.Children.Count == 0) & (DifX1 < Proximity) && (DifY1 < Proximity))
                {
                    AbsoluteLayout.SetLayoutFlags(image2, AbsoluteLayoutFlags.None);
                    AbsoluteLayout.SetLayoutBounds(image2,layout1.Bounds);
                    ReferenceX = layout1.X;
                    ReferenceY = layout1.Y;
                    NewPosition = true;

                }
                else if ((layout2.Children.Count == 0) & (DifX2 < Proximity) && (DifY2 < Proximity))
                {
                    AbsoluteLayout.SetLayoutFlags(image2, AbsoluteLayoutFlags.None);
                    AbsoluteLayout.SetLayoutBounds(image2, layout2.Bounds);
                    ReferenceX = layout2.X;
                    ReferenceY = layout2.Y;
                    NewPosition = true;

                }
                else if ((layout3.Children.Count == 0) & (DifX3 < Proximity) && (DifY3 < Proximity))
                {
                    AbsoluteLayout.SetLayoutFlags(image2, AbsoluteLayoutFlags.None);
                    AbsoluteLayout.SetLayoutBounds(image2, layout3.Bounds);
                    ReferenceX = layout3.X;
                    ReferenceY = layout3.Y;
                    NewPosition = true;

                }

                else if ((layout4.Children.Count == 0) & (DifX4 < Proximity) && (DifY4 < Proximity))
                {
                    
                    AbsoluteLayout.SetLayoutFlags(image2, AbsoluteLayoutFlags.None);
                    AbsoluteLayout.SetLayoutBounds(image2, layout4.Bounds);
                    ReferenceX = layout4.X;
                    ReferenceY = layout4.Y;
                    NewPosition = true;              
                    
                }
                               
            }
            image2.IsVisible = true;
        }
    }
}
