using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace nsNetPeak
{
    /// <summary>
    /// Text box with background as horizontal progress bar.
    /// 
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    public partial class TextBar : System.Windows.Forms.Label
    {
        public TextBar()
        {
            InitializeComponent();
            bgBrush = new SolidBrush(this.BackColor);
            progressBrush = new SolidBrush(Color.Red);
            progress = 0;
            barSize = 2;
        }

        SolidBrush bgBrush;
        Brush progressBrush;
        double progress;
        int barSize;

        public double Progress
        {
            set { progress = value; this.Refresh(); }
            get { return progress; }
        }

        public Brush ProgressBrush
        {
            set { progressBrush = value; }
            get { return progressBrush; }
        }

        public int BarSize
        {
            set { barSize = value; }
            get { return barSize; }
        }

        private void DrawProgress(Graphics g)
        {
            Rectangle rect = this.DisplayRectangle;
            rect.Width = (int)(rect.Width * progress);
            if (barSize > 0)
                rect.Inflate(0, barSize-rect.Height/2);
            g.FillRectangle(progressBrush, rect);       
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            Graphics g = pevent.Graphics;
            DrawProgress(g);
        }
    }
}
