using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public class CustomProgressBar : ProgressBar
    {
        private Color paintedColor = Color.Green;
        private Color paintedForeColor = Color.White;

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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Use the graphics object from PaintEventArgs
            Graphics g = e.Graphics;

            Rectangle rect = ClientRectangle;
            rect.Inflate(-1, -1);  // Shrink the rect slightly to avoid clipping issues

            // Fill the unpainted portion
            using (Brush unpaintedBrush = new SolidBrush(BackColor))
            {
                g.FillRectangle(unpaintedBrush, rect);
            }

            // Calculate the painted area based on the current value
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

            // Draw the text in the middle
            SizeF textSize = g.MeasureString(Text, Font);
            PointF textLocation = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);

            // Text in the painted portion
            if (paintedRect.Width > 0)
            {
                Rectangle clipRect = new Rectangle(rect.X, rect.Y, paintedRect.Width, rect.Height);
                g.SetClip(clipRect);  // Clip the drawing region to the painted area
                using (Brush paintedTextBrush = new SolidBrush(PaintedForeColor))
                {
                    g.DrawString(Text, Font, paintedTextBrush, textLocation);
                }
            }

            // Text in the unpainted portion
            if (paintedRect.Width < rect.Width)
            {
                Rectangle clipRect = new Rectangle(paintedRect.Right, rect.Y, rect.Width - paintedRect.Width, rect.Height);
                g.SetClip(clipRect);  // Clip the drawing region to the unpainted area
                using (Brush unpaintedTextBrush = new SolidBrush(ForeColor))
                {
                    g.DrawString(Text, Font, unpaintedTextBrush, textLocation);
                }
            }

            // Reset clipping
            g.ResetClip();
        }
    }
}
