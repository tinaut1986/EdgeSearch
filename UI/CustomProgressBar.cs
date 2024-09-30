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
                    Invalidate();
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
                    Invalidate();
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
                    Invalidate();
                }
            }
        }

        public CustomProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            PaintedColor = Color.Green;
            ForeColor = Color.Black;
            PaintedForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Rectangle rect = ClientRectangle;

                // Ajustar el rectángulo para que el borde quede dentro del área visible
                rect.Inflate(-1, -1);

                switch (Style)
                {
                    case ProgressBarStyle.Blocks:
                    case ProgressBarStyle.Continuous:
                        {
                            // Dibujar la parte no pintada
                            using (Brush unpaintedBrush = new SolidBrush(BackColor))
                            {
                                g.FillRectangle(unpaintedBrush, rect);
                            }

                            // Dibujar la parte pintada
                            Rectangle paintedRect = new Rectangle(rect.X, rect.Y, (int)(rect.Width * ((double)Value / Maximum)), rect.Height);
                            using (Brush paintedBrush = new SolidBrush(paintedColor))
                            {
                                g.FillRectangle(paintedBrush, paintedRect);
                            }

                            // Dibujar el borde del ProgressBar
                            using (Pen borderPen = new Pen(Color.Gray)) // Puedes cambiar el color del borde si es necesario
                            {
                                g.DrawRectangle(borderPen, rect);
                            }

                            // Dibujar el texto en dos colores
                            SizeF textSize = g.MeasureString(Text, Font);
                            PointF location = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);

                            // Dibujar la parte del texto en la parte pintada
                            g.SetClip(paintedRect);
                            using (Brush paintedTextBrush = new SolidBrush(PaintedForeColor))
                            {
                                g.DrawString(Text, Font, paintedTextBrush, location);
                            }

                            // Dibujar la parte del texto en la parte no pintada
                            g.SetClip(rect);
                            g.SetClip(paintedRect, System.Drawing.Drawing2D.CombineMode.Exclude);
                            using (Brush unpaintedTextBrush = new SolidBrush(ForeColor))
                            {
                                g.DrawString(Text, Font, unpaintedTextBrush, location);
                            }

                            break;
                        }
                    case ProgressBarStyle.Marquee:
                        {
                            break;
                        }
                }
            }
        }
    }
}
