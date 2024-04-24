using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using Newtonsoft.Json; // Asegúrate de tener la librería Newtonsoft.Json instalada

public class Preferences
{
    public enum Mode
    {
        Desktop = 0,
        Mobile = 1,
    }

    public int LowerLimit { get; set; }
    public int UpperLimit { get; set; }
    public Mode LastMode { get; set; }

    private readonly string _configFilePath;

    public Preferences()
    {
        LowerLimit = 15;
        UpperLimit = 90;
        LastMode = Mode.Desktop;
    }

    public Preferences(string configFilePath)
    {
        _configFilePath = configFilePath;

        string solutionDir = AppDomain.CurrentDomain.BaseDirectory;
        string finalPath = configFilePath;
        if (!File.Exists(configFilePath))
            finalPath = Path.Combine(solutionDir, configFilePath);

        if (!File.Exists(finalPath))
        {
            solutionDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../..");
            finalPath = Path.Combine(solutionDir, configFilePath);
        }

        Preferences preferences = null;
        if (!File.Exists(finalPath))
        {
            // El archivo de configuración no existe
            _configFilePath = configFilePath;

            preferences = new Preferences();
            Map(preferences);
            this.Save();
        }
        else
        {
            _configFilePath = finalPath;

            var jsonContent = File.ReadAllText(_configFilePath);
            preferences = JsonConvert.DeserializeObject<Preferences>(jsonContent);

            Map(preferences);
        }
    }

    private void Map(Preferences preferences)
    {
        LowerLimit = preferences.LowerLimit;
        UpperLimit = preferences.UpperLimit;
        LastMode = preferences.LastMode;
    }

    public void Save()
    {
        var jsonContent = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(_configFilePath, jsonContent);
    }

    public override string ToString()
    {
        return $"Preferences(LowerLimit={LowerLimit}, UpperLimit={UpperLimit}, LastMode={LastMode})";
    }
}