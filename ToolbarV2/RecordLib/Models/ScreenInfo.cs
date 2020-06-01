using Rect = System.Drawing.Rectangle;

namespace RecordLib.Models
{
    public class ScreenInfo
    {
        public int Index { get; set; }

        public Rect Bounds { get; set; }

        public Rect WorkareaBounds { get; set; }

        public bool IsPrimaryScreen { get; set; }

        public override string ToString()
        {
            return string.Format("#{0},{1}x{2}", Index + 1, Bounds.Width, Bounds.Height);
        }
    }
}
