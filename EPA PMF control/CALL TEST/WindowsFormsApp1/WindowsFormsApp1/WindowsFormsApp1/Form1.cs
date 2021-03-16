using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows;

namespace WindowsFormsApp1
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow
            (
                string ClassName,
                string WindowName
            );
        [DllImport("user32.dll",SetLastError =true)] private static extern int GetWindowText
            (
                IntPtr ccode,
                StringBuilder T,
                int nMAX
            );
        [DllImport("user32.dll")]
        private static extern int GetClassName
            (
                IntPtr ccode,
                StringBuilder ClassString,
                int nMax
            );
        [DllImport("user32.dll")] private static extern IntPtr WindowFromPoint
            (
                Point p
            );
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx
            (
                IntPtr FatherWDHandle,
                uint HandleChildAfter,
                string TatgetClass,
                string Targetname
            );
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern void SetForegroundWindow
            (
                IntPtr Handle        
            );
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
         private static extern int SendMessage
            (
            IntPtr THandle,
            uint SMsg,
            int wParam,
            int IParam
            );
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage
       (
       IntPtr THandle,
       uint SMsg,
       IntPtr wParam,
       string IParam
       );
        [DllImport("user32.dll")] [return: MarshalAs(UnmanagedType.Bool)] static extern bool GetWindowRect
        (
         IntPtr Handle,
         ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        bool _1T = true;
        IntPtr EPA_PMF=new IntPtr(0);
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EPA_PMF = new IntPtr(0);
            EPA_PMF = FindWindow(null, "EPA PMF");
            if (EPA_PMF != IntPtr.Zero)
            {
                label1.Text = "視窗已取得";
                IntPtr TABHandle = new IntPtr(0);
                TABHandle = FindWindowEx(EPA_PMF, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                if (TABHandle != IntPtr.Zero)
                {
                    label2.Text = "TAB1已取得" + TABHandle.ToString();
                    IntPtr TABHandleL2 = new IntPtr(0);
                    TABHandleL2 = FindWindowEx(TABHandle, 0, "WindowsForms10.Window.8.app.0.378734a", "Model Data");
                    if (TABHandleL2 != IntPtr.Zero)
                    {
                        label2.Text += "TAB1Layer2已取得";
                        IntPtr _2TABHandle = new IntPtr(0);
                        _2TABHandle = FindWindowEx(TABHandleL2, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                        if (_2TABHandle != IntPtr.Zero)
                        {
                            label3.Text = "TAB2已取得";
                            IntPtr _2TABHandleL2 = new IntPtr(0);
                            _2TABHandleL2 = FindWindowEx(_2TABHandle, 0, "WindowsForms10.Window.8.app.0.378734a", "Data Files");
                            if (_2TABHandleL2 != IntPtr.Zero)
                            {
                                label3.Text += "TAB2Layer2已取得";
                                IntPtr Panel_SaveFile = new IntPtr(0);
                                Panel_SaveFile = FindWindowEx(_2TABHandleL2, 0, "WindowsForms10.Window.8.app.0.378734a", "Save File Locations and Settings in a Configuration File or Load a Previous Configuration File");
                                if (Panel_SaveFile != IntPtr.Zero)
                                {
                                    label4.Text = "PANEL 已取得";
                                    IntPtr TBHandle = new IntPtr(0);
                                    TBHandle = FindWindowEx(Panel_SaveFile, 0, "WindowsForms10.EDIT.app.0.378734a", "");
                                    if (TBHandle != IntPtr.Zero)
                                    {
                                        SetForegroundWindow(TBHandle);
                                        SendMessage(TBHandle, 0x000C, IntPtr.Zero, @"C:\Users\XxBNOxX\Documents\EPA PMF\Data\B1.cfg");
                                    }
                                    IntPtr BTLoadHandle = new IntPtr(0);
                                    BTLoadHandle = FindWindowEx(Panel_SaveFile, 0, "WindowsForms10.BUTTON.app.0.378734a", "Load");
                                    if (BTLoadHandle != IntPtr.Zero)
                                    {
                                        SendMessage(BTLoadHandle, 0xF5, 0, 0);
                                    }

                                }
                            }


                        }
                    }
                }
            }
            else label1.Text = "未取得視窗";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EPA_PMF != IntPtr.Zero)
            {
                IntPtr TABHandle = new IntPtr(0);
                TABHandle = FindWindowEx(EPA_PMF, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                if (TABHandle != IntPtr.Zero)
                {
                    SendMessage(TABHandle, 0x1300 + 12, 1, 0);//成功切換，但系統未繪製PANEL
                    IntPtr TABHandleL2 = new IntPtr(0);
                    TABHandleL2 = FindWindowEx(TABHandle, 0, "WindowsForms10.Window.8.app.0.378734a", "Base Model");
                    if (TABHandleL2 != IntPtr.Zero)
                    {
                        IntPtr _2TABHandle = new IntPtr(0);
                        _2TABHandle = FindWindowEx(TABHandleL2, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                        if (_2TABHandle != IntPtr.Zero)
                        {
                            IntPtr _2TABHandleL2 = new IntPtr(0);
                            _2TABHandleL2 = FindWindowEx(_2TABHandle, 0, "WindowsForms10.Window.8.app.0.378734a", "Base Model Runs");
                            if (_2TABHandleL2 != IntPtr.Zero)
                            {
                                IntPtr BMR = new IntPtr(0);
                                BMR = FindWindowEx(_2TABHandleL2, 0, "WindowsForms10.Window.8.app.0.378734a", "Base Model Runs");
                                if (BMR != IntPtr.Zero)
                                {
                                    IntPtr TBHandle = new IntPtr(0);
                                    TBHandle = FindWindowEx(BMR, 0, "WindowsForms10.EDIT.app.0.378734a", "20");
                                    if (TBHandle != IntPtr.Zero)
                                    {
                                        SetForegroundWindow(TBHandle);
                                        SendMessage(TBHandle, 0x000C, IntPtr.Zero, "20");
                                    }
                                }
                            }
                        }
                    }

                }
            }

        }
    
    
    }
}
