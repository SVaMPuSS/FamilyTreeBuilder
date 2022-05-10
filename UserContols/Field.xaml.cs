using FamilyTreeBuilder.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FamilyTreeBuilder
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    public partial class Field : UserControl
    {
        private List<Human> humans;
        private Point cameraPosition;//Переделать на "глобальную завязку" 
        private Point oldPosition;

        public Field()
        {
            InitializeComponent();
            humans = new List<Human>();
            var human = new Human();
            Human.Width = 300;
            Human.Height = 150;
            human.Position = new Point(100,100);
            humans.Add(human);
            cameraPosition = new Point( 0, 0);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(43, 43, 43));
            drawingContext.DrawRectangle(brush, null, new Rect() { Location = new Point(0, 0), Height = ActualHeight, Width = ActualWidth }) ;
            var rect = new Rect();
            rect.Size = new Size(Human.Width, Human.Height);
            brush = new SolidColorBrush(Color.FromRgb(43, 43, 43));
            Pen pen = new Pen(new SolidColorBrush(Color.FromRgb(160, 160, 160)), 1);
            foreach (var item in humans)
            {
                rect.Location = new Point(item.Position.X - cameraPosition.X, item.Position.Y - cameraPosition.Y );
                drawingContext.DrawRectangle(brush, pen, rect);
            }
        }

        private Human GetHumanOnLocation(Point location)
        {
            foreach (var item in humans)
            {
                if(item.CheckClick(location))
                    return item;
            }
            return null;
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {

        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            oldPosition = e.GetPosition(this);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                cameraPosition = new Point(e.GetPosition(this).X - oldPosition.X, e.GetPosition(this).Y - oldPosition.Y);//считать от себя?
                InvalidateVisual();
            }
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            var human = new Human();
            var pos = new Point(e.GetPosition(this).X - Human.Width / 2, e.GetPosition(this).Y - Human.Height / 2);
            human.Position = pos;
            humans.Add(human);
            InvalidateVisual();
        }
    }
}
