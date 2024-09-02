using System.Drawing;
using System.Windows.Forms;

namespace EdgeSearch.Utils
{
    public static class CheckBoxExtensions
    {
        // Método de extensión para Button que ajusta la imagen al tamaño del botón manteniendo la relación de aspecto
        public static void FitImage(this CheckBox checkBox)
        {
            if (checkBox.Image == null) return;

            // Redimensionar la imagen manteniendo la relación de aspecto
            Image resizedImage = checkBox.Image.ResizeImageKeepAspectRatio(checkBox.ClientSize);

            // Asignar la imagen redimensionada al botón
            checkBox.Image = resizedImage;
        }
    }
}