using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_let_user_draw_polyline
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // The Polyline we are currently drawing.
        // This is null when we are not drawing.
        private Polyline NewPolyline = null;

        // The user clicked. Add a point,
        // stop drawing, or start a new curve.
        private void CanDrawing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // See if we are currently drawing.
            if (NewPolyline != null)
            {
                // See if this is the left or right mouse button.
                if (e.ChangedButton == MouseButton.Left)
                {
                    // Left button. Add a new point.
                    NewPolyline.Points.Add(e.GetPosition(canDrawing));
                }
                else 
                {
                    // Right button. Stop drawing.  
                    // MDQ: Right or Middle button response
                    NewPolyline = null;
                }
            }
            else
            {
                // We are not drawing. Start a new Polyline.
                NewPolyline = new Polyline
                {
                    Stroke = Brushes.LightGreen,
                    StrokeThickness = 5
                };
                NewPolyline.Points.Add(e.GetPosition(canDrawing));
                NewPolyline.Points.Add(e.GetPosition(canDrawing));
                canDrawing.Children.Add(NewPolyline);
            }
        }

        // Update the new Polyline's most recent point.
        private void CanDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewPolyline == null) return;

            NewPolyline.Points[NewPolyline.Points.Count - 1] =
                e.GetPosition(canDrawing);
        }
    }
}