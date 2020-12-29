using System;
using System.Windows.Forms;

namespace Pre2Core
{
    public class Pre2Form: Form
    {
        private Timer _Timer { get; set; }
        private DateTime _PreTime { get; set; }
        private Pre2Frame _Main;
        private bool _Run { get; set; }
        private int _Delay { get; set; } = (int)(1e3 / 60);

        public Pre2Form(Pre2Frame main)
        {
            _Main = main;

            Load += _Load;
            Paint += _Paint;

            _Timer = new Timer();
            _Timer.Interval = _Delay;
            _Timer.Tick += _Tick;
        }

        private void _Load(object sender, EventArgs e)
        {
            Pre2Variables.Init(this);

            _Timer.Start();
        }

        private void _Paint(object sender, PaintEventArgs e)
        {
            Pre2Variables.DeltaTime = DateTime.Now - _PreTime;
            _PreTime += Pre2Variables.DeltaTime;

            Pre2Variables.Graphics = e.Graphics;

            if (Pre2Variables.FrameCount != 0) _Main.Draw();
            else _Main.Setup();

            Pre2Variables.FrameCount++;
        }

        private void _Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}