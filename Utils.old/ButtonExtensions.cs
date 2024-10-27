using System.Drawing;
using System.Windows.Forms;

namespace EdgeSearch.Utils
{
    public static class ButtonExtensions
    {
        // Método de extensión para Button que ajusta la imagen al tamaño del botón manteniendo la relación de aspecto
        public static void FitImage(this Button button)
        {
            if (button.Image == null) return;

            // Redimensionar la imagen manteniendo la relación de aspecto
            Image resizedImage = button.Image.ResizeImageKeepAspectRatio(button.ClientSize);

            // Asignar la imagen redimensionada al botón
            button.Image = resizedImage;
        }
    }
}