using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public class CustomProgressBar : ProgressBar
    {
        private Color paintedColor = Color.Green;
        private Color paintedForeColor = Color.Black;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance"), Description("Text displayed in the center of the ProgressBar.")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Color of the painted portion of the ProgressBar.")]
        public Color PaintedColor
        {
            get { return paintedColor; }
            set
            {
                paintedColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Color of the text in the unpainted portion of the ProgressBar.")]
        public Color PaintedForeColor
        {
            get { return paintedForeColor; }
            set
            {
                paintedForeColor = value;
                Invalidate();
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
