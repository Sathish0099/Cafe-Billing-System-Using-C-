using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private MJPEGStream _stream;

    public Form1()
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
