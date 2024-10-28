using System;
using System.IO;

namespace EdgeSearch.src.Config
{
    public static class GlobalConfig
    {
        public static string ProfilesRootPath { get; set; }

        static GlobalConfig()
        {
            // Inicializa la ruta por defecto, por ejemplo:
            ProfilesRootPath = Path.Combine(Environment.CurrentDirectory, "Profiles");
        }
    }
}
