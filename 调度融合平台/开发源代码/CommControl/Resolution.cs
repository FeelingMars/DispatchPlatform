using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CommControl
{
    public class Resolution
    {
        //保存当前屏幕分辨率
      static  int i = Screen.PrimaryScreen.Bounds.Width;
       static  int j = Screen.PrimaryScreen.Bounds.Height;


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool EnumDisplaySettings(string lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);
        public static void ChangeRes()
        {

            DEVMODE DevM = new DEVMODE();
            DevM.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            bool mybool;
            mybool = EnumDisplaySettings(null, 0, ref DevM);
            //DevM.dmPelsWidth = 1024;//宽
          //  DevM.dmPelsHeight = 768;//高

            DevM.dmPelsWidth = 1280;//宽
            DevM.dmPelsHeight = 1024;//高

            DevM.dmPelsWidth = 1440;//宽
            DevM.dmPelsHeight = 900;//高


            DevM.dmDisplayFrequency = 60;//刷新频率
            DevM.dmBitsPerPel = 32;//颜色象素
            long result = ChangeDisplaySettings(ref DevM, 0);
        }
        public static void FuYuan()
        {
            DEVMODE DevM = new DEVMODE();
            DevM.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            bool mybool;
            mybool = EnumDisplaySettings(null, 0, ref DevM);
            DevM.dmPelsWidth = i;//恢复宽
            DevM.dmPelsHeight = j;//恢复高
            DevM.dmDisplayFrequency = 60;//刷新频率
            DevM.dmBitsPerPel = 32;//颜色象素
            long result = ChangeDisplaySettings(ref DevM, 0);
        }
    }
}
