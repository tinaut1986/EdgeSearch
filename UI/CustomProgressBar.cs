using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public class CustomProgressBar : ProgressBar
    {
        private Color paintedColor = Color.Green;
        private Color paintedForeColor = Color.White;
        private int marqueeOffset = 0;  // Offset for the Marquee effect
        private Timer marqueeTimer;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance"), Description("Text displayed in the center of the ProgressBar.")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    Invalidate();  // Redraw only when text changes
                }
            }
        }

        [Category("Appearance"), Description("Color of the painted portion of the ProgressBar.")]
        public Color PaintedColor
        {
            get { return paintedColor; }
            set
            {
                if (paintedColor != value)
                {
                    paintedColor = value;
                    Invalidate();  // Redraw only when the color changes
                }
            }
        }

        [Category("Appearance"), Description("Color of the text in the unpainted portion of the ProgressBar.")]
        public Color PaintedForeColor
        {
            get { return paintedForeColor; }
            set
            {
                if (paintedForeColor != value)
                {
                    paintedForeColor = value;
                    Invalidate();  // Redraw only when the color changes
                }
            }
        }

        public CustomProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            PaintedColor = Color.Green;
            ForeColor = Color.Black;
            PaintedForeColor = Color.White;
            DoubleBuffered = true;  // Enable double buffering to prevent flickering

            // Create and configure the timer for the Marquee mode
            marqueeTimer = new Timer();
            marqueeTimer.Interval = 30; // Update interval (adjust based on desired effect)
            marqueeTimer.Tick += MarqueeTimer_Tick;

            // Check if the timer is enabled when switching to Marquee style
            if (Style == ProgressBarStyle.Marquee)
            {
                marqueeTimer.Start();  // Start the timer for Marquee mode
            }
        }

        private void MarqueeTimer_Tick(object sender, EventArgs e)
        {
            // Adjust the offset for the Marquee
            marqueeOffset += 5;  // Adjust this value to control the speed
            if (marqueeOffset > Width)
            {
                marqueeOffset = 0;  // Reset the offset when it goes out of bounds
            }
            Invalidate();  // Force a repaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Use the graphics object from PaintEventArgs
            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;
            rect.Inflate(-1, -1);  // Shrink the rect slightly to avoid clipping issues

            switch (Style)
            {
                case ProgressBarStyle.Blocks:
                case ProgressBarStyle.Continuous:
                    {
                        // Standard drawing for Blocks/Continuous styles
                        DrawStandardProgressBar(g, rect);
                        break;
                    }
                case ProgressBarStyle.Marquee:
                    {
                        // Drawing logic for Marquee style
                        DrawMarqueeProgressBar(g, rect);
                        break;
                    }
            }
        }

        private void DrawStandardProgressBar(Graphics g, Rectangle rect)
        {
            // Draw the unpainted portion
            using (Brush unpaintedBrush = new SolidBrush(BackColor))
            {
                g.FillRectangle(unpaintedBrush, rect);
            }

            // Draw the painted portion
            Rectangle paintedRect = new Rectangle(rect.X, rect.Y, (int)(rect.Width * ((double)Value / Maximum)), rect.Height);
            using (Brush paintedBrush = new SolidBrush(paintedColor))
            {
                g.FillRectangle(paintedBrush, paintedRect);
            }

            // Draw the border of the ProgressBar
            using (Pen borderPen = new Pen(Color.Gray))
            {
                g.DrawRectangle(borderPen, rect);
            }

            // Draw the text in the center
            DrawCenteredText(g, rect, paintedRect);
        }

        private void DrawMarqueeProgressBar(Graphics g, Rectangle rect)
        {
            // Draw the unpainted portion
            using (Brush unpaintedBrush = new SolidBrush(BackColor))
            {
                g.FillRectangle(unpaintedBrush, rect);
            }

            // Draw the moving portion of the Marquee
            int marqueeWidth = rect.Width / 4; // Width of the moving block (adjustable)
            Rectangle marqueeRect = new Rectangle(marqueeOffset, rect.Y, marqueeWidth, rect.Height);
            using (Brush marqueeBrush = new SolidBrush(paintedColor))
            {
                g.FillRectangle(marqueeBrush, marqueeRect);
            }

            // Move the Marquee block
            marqueeOffset += 5; // Marquee speed
            if (marqueeOffset > rect.Width)
            {
                marqueeOffset = -marqueeWidth; // Reset the cycle when the block goes out of view
            }

            // Draw the border of the ProgressBar
            using (Pen borderPen = new Pen(Color.Gray))
            {
                g.DrawRectangle(borderPen, rect);
            }

            // Draw the text in the center
            DrawCenteredText(g, rect, marqueeRect);
        }

        private void DrawCenteredText(Graphics g, Rectangle rect, Rectangle paintedRect)
        {
            SizeF textSize = g.MeasureString(Text, Font);
            PointF location = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);

            // Draw the part of the text covered by the painted area
            g.SetClip(paintedRect);
            using (Brush paintedTextBrush = new SolidBrush(PaintedForeColor))
            {
                g.DrawString(Text, Font, paintedTextBrush, location);
            }

            // Draw the part of the text outside the painted area
            g.SetClip(rect);
            g.SetClip(paintedRect, System.Drawing.Drawing2D.CombineMode.Exclude);
            using (Brush unpaintedTextBrush = new SolidBrush(ForeColor))
            {
                g.DrawString(Text, Font, unpaintedTextBrush, location);
            }

            // Restore the original clip region
            g.ResetClip();
        }

        // Override to handle the switch to Marquee style
        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);

            // Start or stop the timer based on the style
            if (Style == ProgressBarStyle.Marquee)
            {
                marqueeOffset = 0;  // Reset the Marquee position
                marqueeTimer.Start();  // Start the moving effect
            }
            else
            {
                marqueeTimer.Stop();  // Stop the timer when not in Marquee style
                Invalidate();  // Redraw in the new style
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Check the style when the control is created
            if (Style == ProgressBarStyle.Marquee)
            {
                marqueeOffset = 0;  // Reset the Marquee position
                marqueeTimer.Start();  // Start the timer if in Marquee style
            }
        }
    }
}
