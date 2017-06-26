using System;
using Xamarin.Forms;

namespace DragandDropDemo
{
    public partial class MainPage : ContentPage
	{
        double XCoordinate, YCoordinate;      
        double ReferenceX;
        double ReferenceY;
        public MainPage()
		{
			InitializeComponent();
            //ReferenceX = layout1.X;
            //ReferenceY = layout1.Y;

		}

       
        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if(ReferenceX == 0 && ReferenceY == 0)
            {
                ReferenceX = layout1.X;
                ReferenceY = layout1.Y;
            }

            double Proximity = 60;
            
            await image1.TranslateTo(e.TotalX, e.TotalY);
            if (e.StatusType == GestureStatus.Running)
            {
                XCoordinate = e.TotalX;
                YCoordinate = e.TotalY;
            }
            //if ((DifX1 < Proximity) && (DifY1 < Proximity))
            //    layout2.Children.Add(image1);
            //var DifX1 = Math.Abs(layout1.X - XCoordinate + ReferenceX);
            //var DifY1 = Math.Abs(layout1.Y - YCoordinate + ReferenceY);
            //if ((DifX1 < Proximity) && (DifY1 < Proximity))
            //{
            //    layout1.Children.Add(image1);
            //}

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

                //if ((layout1.Children.Count != 0))
                //{                    
                //    DifX2 = Math.Abs(layout2.X - XCoordinate - ReferenceX);
                //    DifY2 = Math.Abs(YCoordinate);
                //    DifX3 = Math.Abs(XCoordinate);
                //    DifY3 = Math.Abs(layout3.Y - YCoordinate - ReferenceY);
                //    DifX4 = Math.Abs(layout4.X - XCoordinate - ReferenceX);
                //    DifY4 = Math.Abs(layout4.Y - YCoordinate - ReferenceY);
                //}
                //else if ((layout2.Children.Count != 0))
                //{
                //   DifX1 = Math.Abs(layout1.X - XCoordinate - ReferenceX);
                //   DifY1 = Math.Abs(YCoordinate);
                //   DifX3 = Math.Abs(layout3.X - XCoordinate - ReferenceX);
                //   DifY3 = Math.Abs(layout3.Y - YCoordinate - ReferenceY);
                //   DifX4 = Math.Abs(XCoordinate);
                //   DifY4 = Math.Abs(layout4.Y - YCoordinate - ReferenceY);
                //}
                //else if ((layout3.Children.Count != 0))
                //{
                //    DifX1 = Math.Abs(XCoordinate);
                //    DifY1 = Math.Abs(layout1.Y - YCoordinate - ReferenceY);
                //    DifX2 = Math.Abs(layout2.X - XCoordinate - ReferenceX);
                //    DifY2 = Math.Abs(layout2.Y - YCoordinate - ReferenceY);
                //    DifX4 = Math.Abs(layout4.X - XCoordinate + ReferenceX);
                //    DifY4 = Math.Abs(YCoordinate);
                //}
                //else if((layout4.Children.Count != 0))
                //{
                //    DifX1 = Math.Abs(layout1.X - XCoordinate - ReferenceX);
                //    DifY1 = Math.Abs(layout1.Y - YCoordinate - ReferenceY);
                //    DifX2 = Math.Abs(XCoordinate);
                //    DifY2 = Math.Abs(layout2.Y - YCoordinate - ReferenceY);
                //    DifX3 = Math.Abs(layout3.X - XCoordinate - ReferenceX);
                //    DifY3 = Math.Abs(YCoordinate);
                //}
                if ((layout1.Children.Count == 0) & (DifX1 < Proximity) && (DifY1 < Proximity))
                {
                    layout1.Children.Add(image1);
                    ReferenceX = layout1.X;
                    ReferenceY = layout1.Y;
                }
                else if ((layout2.Children.Count == 0) & (DifX2 < Proximity) && (DifY2 < Proximity))
                {
                    layout2.Children.Add(image1);
                    ReferenceX = layout2.X;
                    ReferenceY = layout2.Y;
                }
                else if ((layout3.Children.Count == 0) & (DifX3 < Proximity) && (DifY3 < Proximity))
                {
                    layout3.Children.Add(image1);
                    ReferenceX = layout3.X;
                    ReferenceY = layout3.Y;
                }

                else if ((layout4.Children.Count == 0) & (DifX4 < Proximity) && (DifY4 < Proximity))
                {
                    layout4.Children.Add(image1);
                    ReferenceX = layout4.X;
                    ReferenceY = layout4.Y;
                }
            }


        }

        //private void PanGestureRecognizerImage(object sender, PanUpdatedEventArgs e)
        //{
        //    if (e.StatusType == GestureStatus.Started)
        //        IsImage = true;
        //    if (e.StatusType == GestureStatus.Completed)
        //        IsImage = false;
        //}

        //private async void PanGestureRecognizerImage1(object sender, PanUpdatedEventArgs e)
        //{

        //    ////var c = X;
        //    //double Proximity = 40;
        //    //XCoordinate += e.TotalX;
        //    //YCoordinate += e.TotalY;
        //    //var image = (sender as Image);
        //    //await image.TranslateTo(XCoordinate, YCoordinate, 80);
        //    //var DifX1 = Math.Abs(image1.X - (XCoordinate + image.X));
        //    //var DifY1 = Math.Abs(image1.Y - (YCoordinate + image.Y));
        //    //var DifX2 = Math.Abs(image2.X - (XCoordinate + image.X));
        //    //var DifY2 = Math.Abs(image2.Y - (YCoordinate + image.Y));
        //    //var DifX3 = Math.Abs(image3.X - (XCoordinate + image.X));
        //    //var DifY3 = Math.Abs(image3.Y - (YCoordinate + image.Y));
        //    //var DifX4 = Math.Abs(image4.X - (XCoordinate + image.X));
        //    //var DifY4 = Math.Abs(image4.Y - (YCoordinate + image.Y));

        //    //if (e.StatusType == GestureStatus.Completed)
        //    //{
        //    //    await image.TranslateTo(e.TotalX, e.TotalY, 1);

        //    //    if ((image.Id != image1.Id) & (DifX1 < Proximity) && (DifY1 < Proximity))
        //    //    {
        //    //        image.Opacity = 0.2;
        //    //        image.IsEnabled = false;
        //    //        image1.Opacity = 1;
        //    //    }
        //    //    if ((image.Id != image2.Id) & (DifX2 < Proximity) && (DifY2 < Proximity))
        //    //    {
        //    //        image.Opacity = 0.2;

        //    //        image.IsEnabled = false;
        //    //        image2.Opacity = 1;
        //    //    }
        //    //    if ((image.Id != image3.Id) & (DifX3 < Proximity) && (DifY3 < Proximity))
        //    //    {
        //    //        image.Opacity = 0.2;

        //    //        image3.Opacity = 1;
        //    //        image.IsEnabled = false;
        //    //    }
        //    //    if ((image.Id != image4.Id) & (DifX4 < Proximity) && (DifY4 < Proximity))
        //    //    {
        //    //        image.Opacity = 0.2;

        //    //        image4.Opacity = 1;
        //    //        image.IsEnabled = false;
        //    //    }                
        //    //}
        //}

        //void ResetPosition()
        //{

        //}
    }


}
