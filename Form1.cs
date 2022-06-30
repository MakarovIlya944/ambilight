using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing.Imaging;

namespace ambilightsharp
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        static bool _continue;
        static int LedNumber = 92;
        static int LedHeight = 100;
        // 2     60      2
        //3               2
        //26             31
        //2               2
        //2  28   4   30  2
        // sm
        //-------------------
        static double[] metrics = new double[] { 2, 30, 4, 28, 2, 
            2, 28, 2, 
            3, 59, 3,
            2, 31, 2 };
        static double[] leds = new double[] { 16, 16, 14, 32, 14 };

        Thread updateLed;

        static int BaudRate = 38400;

        static bool drawNumber = true;
        static bool drawColour = true;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _serialPort = new SerialPort(comlist.Text);
                _serialPort.BaudRate = BaudRate;
                _serialPort.Open();
                _continue = true;
                updateLed = new Thread(UpdateLed);
                updateLed.Start();
            }
            else
            {
                _continue = false;
                updateLed.Abort();
                _serialPort.Close();
            }
        }

        private void ProcessOnOff()
        {
            if (checkBox1.Checked)
            {
                _serialPort = new SerialPort(comlist.Text);
                _serialPort.BaudRate = BaudRate;
                _serialPort.Open();
                _continue = true;
                updateLed = new Thread(UpdateLed);
                updateLed.Start();
            }
            else
            {
                _continue = false;
                updateLed.Abort();
                _serialPort.Close();
            }
        }

        static private void UpdateLed()
        {
            char[] buff = new char[1];
            while (_continue)
            {
                try
                {
                    _serialPort.Write("B");
                    _serialPort.Write(GetBorder(), 0, 92 * 3);
                    _serialPort.Read(buff, 0, 1);
                    while (buff[0] != 'E')
                        _serialPort.Read(buff, 0, 1);
                }
                catch (ThreadAbortException ex)
                {
                    return;
                }
                
            }
        }


        //       32      
        //14             14
        //   16       16
        // diods
        //------------------
        //         3   
        //2                4
        //1                0
        static private byte[] GetBorder()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            int j = 0;
            byte[] result = new byte[LedNumber*3+j];
            double wid = bounds.Width / 64.0, hei = bounds.Height / 33.0;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                
                int ledWidth = (int)(wid * metrics[1] / leds[0]);
                int ledHeight = (int)(hei * metrics[6] / leds[0]);
                int offset = (int)(metrics[0] * wid);
                for (int i = 0; i < leds[0]; i++)
                {
                    var res = AvgRect(bitmap, bounds.Width - offset - i * ledWidth, bounds.Height - LedHeight - 1, ledWidth, LedHeight - 1);
                    result[j++] = (byte)(int)res[0];
                    result[j++] = (byte)(int)res[1];
                    result[j++] = (byte)(int)res[2];
                }

                ledWidth = (int)(wid * metrics[3] / leds[1]);
                offset = (int)((metrics[0] + metrics[1] + metrics[2])*wid);
                for (int i = 0; i < leds[1]; i++)
                {
                    var res = AvgRect(bitmap, bounds.Width - offset - i * ledWidth, bounds.Height - LedHeight - 1, ledWidth, LedHeight - 1);
                    result[j++] = (byte)(int)res[0];
                    result[j++] = (byte)(int)res[1];
                    result[j++] = (byte)(int)res[2];
                }

                ledHeight = (int)(hei * metrics[6] / leds[2]);
                offset = (int)(metrics[5] * hei);
                for (int i = 0; i < leds[2]; i++)
                {
                    var res = AvgRect(bitmap, 0, bounds.Height - offset - (i+1) * ledHeight, LedHeight - 1, ledHeight - 1);
                    result[j++] = (byte)(int)res[0];
                    result[j++] = (byte)(int)res[1];
                    result[j++] = (byte)(int)res[2];
                }

                ledWidth = (int)(wid * metrics[9] / leds[1]);
                offset = (int)(metrics[8] * wid);
                for (int i = 0; i < leds[3]; i++)
                {
                    var res = AvgRect(bitmap, offset + i * ledWidth, 0, ledWidth, LedHeight);
                    result[j++] = (byte)(int)res[0];
                    result[j++] = (byte)(int)res[1];
                    result[j++] = (byte)(int)res[2];
                }


                ledHeight = (int)(hei * metrics[12] / leds[2]);
                offset = (int)(metrics[11] * hei);
                for (int i = 0; i < leds[4]; i++)
                {
                    var res = AvgRect(bitmap, bounds.Width - LedHeight, offset + i * ledHeight, LedHeight - 1, ledHeight - 1);
                    result[j++] = (byte)(int)res[0];
                    result[j++] = (byte)(int)res[1];
                    result[j++] = (byte)(int)res[2];
                }
            }
            return result;
        }

        static private int[] AvgRect(Bitmap bm, int _x, int _y, int width, int height)
        {
            BitmapData srcData = bm.LockBits(
            new Rectangle(0, 0, bm.Width, bm.Height),
            ImageLockMode.ReadOnly,
            bm.PixelFormat);

            int stride =  srcData.Stride;
            IntPtr Scan0 = srcData.Scan0;

            long[] totals = new long[] { 0, 0, 0 };
            int _height = _y + height;
            int _width = _x + width;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                for (int y = _y; y < _height; y++)
                {
                    for (int x = _x; x < _width; x++)
                    {
                        for (int color = 0; color < 3; color++)
                        {
                            int idx = (y * stride) + x * 4 + color;
                            totals[2-color] += p[idx];
                        }
                    }
                }
            }
            bm.UnlockBits(srcData);
            float pixelcount = width * height;
            var tmp = new int[3] { (int)(totals[0] / pixelcount), (int)(totals[1] / pixelcount), (int)(totals[2] / pixelcount) };
            return tmp;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LedNumber = Int32.Parse(textBox1.Text);
        }

        private void testbutton_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var bytes = GetBorder();
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);


                    List<Rectangle> rectangles = new List<Rectangle>();

                    double wid = bounds.Width / 64.0, hei = bounds.Height / 33.0;

                    int j = 0;
                    int ledWidth = (int)(wid * metrics[1] / leds[0]);
                    int ledHeight = (int)(hei * metrics[6] / leds[0]);
                    int offset = (int)(metrics[0] * wid);
                    for (int i = 0; i < leds[0]; i++)
                        rectangles.Add(new Rectangle(bounds.Width - offset - i * ledWidth, bounds.Height - LedHeight - 1, ledWidth, LedHeight - 1));

                    ledWidth = (int)(wid * metrics[3] / leds[1]);
                    offset = (int)((metrics[0] + metrics[1] + metrics[2] + 1) * wid);
                    for (int i = 0; i < leds[1]; i++)
                        rectangles.Add(new Rectangle( bounds.Width - offset - i * ledWidth, bounds.Height - LedHeight - 1, ledWidth, LedHeight - 1));

                    ledHeight = (int)(hei * metrics[6] / leds[2]);
                    offset = (int)(metrics[5] * hei);
                    for (int i = 0; i < leds[2]; i++)
                        rectangles.Add(new Rectangle( 0, bounds.Height - offset - (i + 1) * ledHeight, LedHeight - 1, ledHeight - 1));

                    ledWidth = (int)(wid * metrics[9] / leds[1]);
                    offset = (int)(metrics[8] * wid);
                    for (int i = 0; i < leds[1]; i++)
                        rectangles.Add(new Rectangle( offset + i * ledWidth, 0, ledWidth, LedHeight));

                    ledHeight = (int)(hei * metrics[12] / leds[2]);
                    offset = (int)(metrics[11] * hei);
                    for (int i = 0; i < leds[2]; i++)
                        rectangles.Add(new Rectangle( bounds.Width - LedHeight, offset + i * ledHeight, LedHeight - 1, ledHeight - 1));

                    Pen pen = new Pen(Color.FromArgb(255,0,0,255),1);
                    g.DrawRectangles(pen,rectangles.ToArray());

                    
                    if (drawColour)
                    {
                        Color customColor;
                        SolidBrush shadowBrush;
                        for (int i = 0; i < rectangles.Count; i++)
                        {
                            customColor = Color.FromArgb(bytes[i*3], bytes[i * 3+1], bytes[i * 3+2]);
                            shadowBrush = new SolidBrush(customColor);
                            g.FillRectangle(shadowBrush, rectangles[i]);
                        }
                    }

                    if (drawNumber)
                    {
                        j = 0;
                        foreach (var r in rectangles)
                        {
                            Font font = new Font(DefaultFont.FontFamily, LedHeight/2);
                            g.DrawString($"{j++}", font, Brushes.Black, new Point(r.X + r.Width / 2 - LedHeight / 2, r.Y + r.Height / 2 - LedHeight / 2));
                        }
                    }
                }

                float scale = Math.Min(panel1.Width / (float)bitmap.Width, panel1.Height / (float)bitmap.Height);
                var scaleWidth = (int)(bitmap.Width * scale);
                var scaleHeight = (int)(bitmap.Height * scale);
                e.Graphics.DrawImage(bitmap, ((int)panel1.Width - scaleWidth) / 2, ((int)panel1.Height - scaleHeight) / 2, scaleWidth, scaleHeight);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void color_CheckedChanged(object sender, EventArgs e)
        {
            drawNumber = !drawNumber;
        }

        private void heightled_ValueChanged(object sender, EventArgs e)
        {
            LedHeight = (int)heightled.Value;
            panel1.Invalidate();
        }

        private void refresh_CheckedChanged(object sender, EventArgs e)
        {
            if (refresh.Checked)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void colour_CheckedChanged(object sender, EventArgs e)
        {
            drawColour = !drawColour;
        }

        private void onOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
