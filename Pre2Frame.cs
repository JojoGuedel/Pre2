using System;
using System.Drawing;

namespace Pre2Core
{
    public abstract class Pre2Frame
    {
        public int Width { get => Pre2Variables.Width; }
        public int Height { get => Pre2Variables.Height; }

        public Graphics Graphics { get => Pre2Variables.Graphics; }
        public TimeSpan DeltaTime { get => Pre2Variables.DeltaTime; }
        public int FrameCount { get => Pre2Variables.FrameCount; }

        public virtual void Setup() {}
        public virtual void Draw() {}

        private Color _FillColor { get; set; } = Color.FromArgb(255, 255, 255);
        private Color _StrokeColor { get; set; } = Color.FromArgb(0, 0, 0);
        private bool _NoFill { get; set; }
        private bool _NoStroke { get; set; }
        public int StrokeWeight { get; private set; }

        public void NoFill() => _NoFill = true;
        public void NoStroke() => _NoStroke = true;
        public void Fill(int r, int g, int b)
        {
            _NoFill = false;
            _FillColor = Color.FromArgb(r, g, b);
        }
        public void Stroke(int r, int g, int b) 
        {
            _NoStroke = false;
            _StrokeColor = Color.FromArgb(r, g, b);
        }

        public void Line(int x1, int y1, int x2, int y2)
        {
            if (!_NoStroke) Graphics.DrawLine(new Pen(_StrokeColor, StrokeWeight), new Point(x1, y1), new Point(x2, x2));
        }
        public void Rect(int x, int y, int width, int height) 
        {
            if (!_NoFill) Graphics.FillRectangle(new SolidBrush(_FillColor), new Rectangle(x, y, width, height));
            if (!_NoStroke) Graphics.DrawRectangle(new Pen(_StrokeColor, StrokeWeight), new Rectangle(x, y, width, height));
        }
        public void Background(int r, int g, int b)
        {
            Graphics.FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), new Rectangle(0, 0, Pre2Variables.Width, Pre2Variables.Height));
        }
        public void Circle(int x, int y, int r)
        {
            if (!_NoFill) Graphics.FillEllipse(new SolidBrush(_FillColor), new Rectangle(x, y, r, r));
            if (!_NoStroke) Graphics.DrawEllipse(new Pen(_StrokeColor, StrokeWeight), new Rectangle(x, y, r, r));
        }
        public void Ellipse(int x, int y, int width, int height)
        {
            if (!_NoFill) Graphics.FillEllipse(new SolidBrush(_FillColor), new Rectangle(x, y, width, height));
            if (!_NoStroke) Graphics.DrawEllipse(new Pen(_StrokeColor, StrokeWeight), new Rectangle(x, y, width, height));
        }

        public void DoubleBuffering(bool b) => Pre2Variables.DoubleBuffering = b;
    }
}
