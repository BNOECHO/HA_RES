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
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow
        (
            string ClassName,
            string WindowName
        );
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText
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
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint
            (
                Point p
            );
        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr EPA_PMF = IntPtr.Zero;
            EPA_PMF = FindWindow(null,"EPA PMF");
            if (EPA_PMF != IntPtr.Zero)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                label1.Text = "FOUNDED";
                var allchild = new WindowHandleInfo(EPA_PMF).GetAllChildHandles();
                foreach (var child in allchild)
                {
                    
                    StringBuilder Title = new StringBuilder(256);
                    GetWindowText(child, Title, Title.Capacity);
                    StringBuilder classname = new StringBuilder(256);
                    GetClassName(child, classname, classname.Capacity);
                    listBox1.Items.Add(child.ToString());
                    listBox2.Items.Add(Title.ToString());
                    listBox3.Items.Add(classname.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
            IntPtr Handle = WindowFromPoint(p);
            StringBuilder Title = new StringBuilder(256);
            GetWindowText(Handle, Title, Title.Capacity);
            StringBuilder classname = new StringBuilder(256);
            GetClassName(Handle, classname, classname.Capacity);
            label2.Text = Title.ToString();
            label3.Text = Handle.ToString();
            label4.Text = classname.ToString();
        }
    }
    public class WindowHandleInfo
    {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        private IntPtr _MainHandle;

        public WindowHandleInfo(IntPtr handle)
        {
            this._MainHandle = handle;
        }

        public List<IntPtr> GetAllChildHandles()
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }
    }
   
}
