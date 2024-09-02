using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSearch.Utils
{
    public static class LibImage
    {
        public static Image ResizeImageKeepAspectRatio(this Image img, Size targetSize)
        {
            // Calcular el tamaño de la imagen redimensionada manteniendo la relación de aspecto
            float ratioX = (float)targetSize.Width / img.Width;
            float ratioY = (float)targetSize.Height / img.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio) - 10;
            int newHeight = (int)(img.Height * ratio) - 10;

            // Crear un nuevo bitmap con el tamaño adecuado
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
    }
}
