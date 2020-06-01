using Microsoft.Win32.SafeHandles;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Input;
using System.Windows.Interop;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Point = System.Drawing.Point;

namespace PainingBoard.CommonTools
{

    public class External
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool IsIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr MaskBitmap;
            public IntPtr ColorBitmap;
        };

        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect([In] ref ICONINFO piconinfo);

        [DllImport("user32.dll", EntryPoint = "CreateIconIndirect")]
        public static extern SafeIconHandle CreateIconIndirect1(ref ICONINFO icon);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr hIcon);
    }

    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    public class SafeIconHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public SafeIconHandle()
            : base(true)
        {
        }

        override protected bool ReleaseHandle()
        {
            return External.DestroyIcon(handle);
        }
    }

    public class CursorHelper
    {

        public static Cursor CreateCursorFromBitmap(Bitmap bitmap, byte alphaLevel, Point hotSpot)
        {
            Bitmap cursorBitmap = null;
            External.ICONINFO iconInfo = new External.ICONINFO();
            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            try
            {
                // Here, the premultiplied alpha channel is specified
                cursorBitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppPArgb);

                // I'm assuming the source bitmap can be locked in a 24 bits per pixel format
                BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData cursorBitmapData = cursorBitmap.LockBits(rectangle, ImageLockMode.WriteOnly, cursorBitmap.PixelFormat);

                // Use either SafeCopy() or UnsafeCopy() to set the bitmap contents
                SafeCopy(bitmapData, cursorBitmapData, alphaLevel);
                //UnsafeCopy(bitmapData, cursorBitmapData, alphaLevel);

                cursorBitmap.UnlockBits(cursorBitmapData);
                bitmap.UnlockBits(bitmapData);

                if (!External.GetIconInfo(bitmap.GetHicon(), out iconInfo))
                    throw new Exception("GetIconInfo() failed.");

                iconInfo.xHotspot = hotSpot.X;
                iconInfo.yHotspot = hotSpot.Y;
                iconInfo.IsIcon = false;

                //IntPtr cursorPtr = External.CreateIconIndirect(ref iconInfo);
                SafeIconHandle cursorPtr = External.CreateIconIndirect1(ref iconInfo);
                //if (cursorPtr == IntPtr.Zero)
                //    throw new Exception("CreateIconIndirect() failed.");

                return CursorInteropHelper.Create(cursorPtr);
                //return (new Cursor(cursorPtr));
            }
            finally
            {
                if (cursorBitmap != null)
                    cursorBitmap.Dispose();
                if (iconInfo.ColorBitmap != IntPtr.Zero)
                    External.DeleteObject(iconInfo.ColorBitmap);
                if (iconInfo.MaskBitmap != IntPtr.Zero)
                    External.DeleteObject(iconInfo.MaskBitmap);
            }
        }

        private static void SafeCopy(BitmapData srcData, BitmapData dstData, byte alphaLevel)
        {
            for (int y = 0; y < srcData.Height; y++)
                for (int x = 0; x < srcData.Width; x++)
                {
                    byte b = Marshal.ReadByte(srcData.Scan0, y * srcData.Stride + x * 3);
                    byte g = Marshal.ReadByte(srcData.Scan0, y * srcData.Stride + x * 3 + 1);
                    byte r = Marshal.ReadByte(srcData.Scan0, y * srcData.Stride + x * 3 + 2);

                    Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4, b);
                    Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4 + 1, g);
                    Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4 + 2, r);
                    Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4 + 3, alphaLevel);
                }
        }

    }
}
