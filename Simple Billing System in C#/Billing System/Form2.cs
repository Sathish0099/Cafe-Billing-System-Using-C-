using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace BillingSystem
{
    public partial class Form2 : Form
    {
        private MJPEGStream _stream;

        public Form2()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Enter camera stream URL.", "Info");
                return;
            }

            _stream?.SignalToStop();

            _stream = new MJPEGStream(url);
            _stream.NewFrame += Stream_NewFrame;
            _stream.Start();
        }

        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox.Invoke(new Action(() => pictureBox.Image = frame));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _stream?.SignalToStop();
            base.OnFormClosing(e);
        }
    }
}

