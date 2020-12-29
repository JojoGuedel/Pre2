using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pre2Core
{
    public static class Pre2Variables
    {
        public static void Init(Pre2Form form)
        {
            Form = form;
            FrameCount = 0;
        }

        private static Pre2Form Form { get; set; }

        public static string Title => Form.Text;

        public static Size Size { get; set; } = Form.Size;

        public static int Width => Form.Width;
        public static int Height => Form.Height;

        public static int FrameCount { get; set; }
        public static TimeSpan DeltaTime { get; set; }
        public static Graphics Graphics { get; set; }

        public static bool DoubleBuffering 
        { set {
            typeof(Panel).InvokeMember(
                "DoubleBuffered", 
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                Form,
                new object[] { value });
        }}
    }
}
