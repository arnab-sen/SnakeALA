using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Libraries;
using ProgrammingParadigms;

namespace DomainAbstractions
{
    class MovingRender : IDataFlow<Canvas>, IDataFlow<Point>, IDataFlow<Vector>
    {
        // Public fields and properties
        public string InstanceName = "Default";
        public UIElement Render { get; set; } = new Rectangle() { Width = 25, Height = 25, Fill = Brushes.Black };

        public Point Position
        {
            get => _position;
            set
            {
                _position = value;

                Canvas.SetLeft(Render, _position.X);
                Canvas.SetTop(Render, _position.Y);
            }
        }

        // Private fields
        private Canvas mainCanvas;
        private Point _position = new Point(0, 0);
        private Vector _relativeMovement;

        // Ports
        private IDataFlow<Point> lastPositionOutput;
        private IDataFlow<MovingRender> selfOutput;

        public MovingRender()
        {

        }

        // IDataFlow<Canvas> implementation
        Canvas IDataFlow<Canvas>.Data
        {
            get => mainCanvas;
            set
            {
                mainCanvas = value;

                if (!mainCanvas.Children.Contains(Render)) mainCanvas.Children.Add(Render);
            }
        }

        // IDataFlow<Point> implementation
        // Move to an absolute position
        Point IDataFlow<Point>.Data
        {
            get => Position;
            set
            {
                if (lastPositionOutput != null)
                {
                    lastPositionOutput.Data = Position;
                }

                Position = value;
            }
        }

        // IDataFlow<Vector> implementation
        // Apply a Vector to the current position
        Vector IDataFlow<Vector>.Data
        {
            get => _relativeMovement;
            set
            {
                _relativeMovement = value;

                if (lastPositionOutput != null) lastPositionOutput.Data = Position;

                Position = Point.Add(Position, _relativeMovement);
            }
        }
        
    }
}
