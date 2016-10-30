using SuperSocket.ClientEngine;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using WebSocket4Net;

namespace Pixel_Weather_ScreenSaver
{
    public partial class Form1 : Form
    {
        #region Preview API's

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion
        public bool IsPreviewMode;
        WebSocket websocket = new WebSocket("ws://128.199.142.235:2016/");
        string data = "???|???|???";
        string location = "";
        string unit = "";
        public Form1(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Cursor.Hide();
            Icon.SetBounds(Bounds.Width / 3, 0, Bounds.Width / 3, Bounds.Height / 2);
            temp.SetBounds(0, Bounds.Height / 2, Bounds.Width, temp.Height);
            desc.SetBounds(0, Convert.ToInt32(Convert.ToDouble(Bounds.Height / 3) * 1.8), Bounds.Width, temp.Height);
            LOC.SetBounds(0, Bounds.Height - LOC.Height * 2, Bounds.Width, temp.Height);
            websocket.Opened += new EventHandler(websocket_Opened);
            websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
            websocket.MessageReceived += websocket_MessageReceived;
            websocket.Open();
            XDocument xml = XDocument.Load("config.xml");
            location = xml.Descendants("location").ToArray()[0].Value;
            unit = xml.Descendants("unit").ToArray()[0].Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            websocket.Send(location);
        }

        private void websocket_Error(object sender, EventArgs e)
        {

        }

        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (e.Message.StartsWith("Error:"))
            {
                data = "Error|" + e.Message.Split(':')[1] + "|null";
                return;
            }
            data = e.Message;
            websocket.Close();
        }

        private void TIMER_TOCK(object sender, EventArgs e)
        {
            Console.WriteLine(data.Split('|')[0]);
            if (data.StartsWith("Error"))
            {
                temp.Text = "Error";
                desc.Text = data.Split('|')[1];
                return;
            }
            if (data != "???|???|???")
            {
                if (unit == "C") temp.Text = (Convert.ToDouble(data.Split('|')[0]) - 273.15).ToString().Split('.')[0] + "° C";
                if (unit == "K") temp.Text = (Convert.ToDouble(data.Split('|')[0]) - 273.15).ToString().Split('.')[0] + "° K";
                if (unit == "F") temp.Text = (Convert.ToDouble(data.Split('|')[0]) - 459.67).ToString().Split('.')[0] + "° F";
                desc.Text = data.Split('|')[1].First().ToString().ToUpper() + string.Join("", data.Split('|')[1].Skip(1));
                if (data.Split('|')[2].StartsWith("2")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_lightning.png"; }
                if (data.Split('|')[2].StartsWith("3")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_rain.png"; }
                if (data.Split('|')[2].StartsWith("5")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_rain.png"; }
                if (data.Split('|')[2].StartsWith("6")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_snow.png"; }
                if (data.Split('|')[2].StartsWith("7")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_wind.png"; }
                if (data.Split('|')[2].StartsWith("8")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_clouds.png"; }
                if (data.Split('|')[2] == "800") { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_sun.png"; }
                if (data.Split('|')[2] == "801") { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_cloudy.png"; }
                if (data.Split('|')[2].StartsWith("9")) { Icon.ImageLocation = @"https://github.com/PikaDude/Pixel-Weather-ScreenSaver/Assets/weather_wind.png"; }
                LOC.Text = location;
            }
        }

        public Form1(IntPtr PreviewHandle)
        {
            InitializeComponent();
            SetParent(Handle, PreviewHandle);
            SetWindowLong(Handle, -16,
                  new IntPtr(GetWindowLong(Handle, -16) | 0x40000000));
            Rectangle ParentRect;
            GetClientRect(PreviewHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);
            IsPreviewMode = true;
        }

        #region User Input

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPreviewMode)
            {
                Application.Exit();
            }
        }

        private void Form1_Click(object sender, MouseEventArgs e)
        {
            if (!IsPreviewMode)
            {
                Application.Exit();
            }
        }
        Point OriginalLocation = new Point(int.MaxValue, int.MaxValue);

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsPreviewMode)
            {
                if (OriginalLocation.X == int.MaxValue &
                    OriginalLocation.Y == int.MaxValue)
                {
                    OriginalLocation = e.Location;
                }
                if (Math.Abs(e.X - OriginalLocation.X) > 20 |
                    Math.Abs(e.Y - OriginalLocation.Y) > 20)
                {
                    Application.Exit();
                }
            }
        }
        #endregion
    }
}
