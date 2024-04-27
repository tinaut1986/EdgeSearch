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
    public int MobileTotalPoints { get; set; }
    public int DesktopTotalPoints { get; set; }
    public string MobileUserAgent { get; set; }
    public string DesktopUserAgent { get; set; }
    public Mode LastMode { get; set; }

    private readonly string _configFilePath;

    public Preferences()
    {
        LowerLimit = 15;
        UpperLimit = 90;
        LastMode = Mode.Desktop;
        MobileTotalPoints = 60;
        DesktopTotalPoints = 90;
        MobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36"; ;
        DesktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36";
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
        MobileTotalPoints = preferences.MobileTotalPoints;
        DesktopTotalPoints = preferences.DesktopTotalPoints;
        DesktopUserAgent = preferences.DesktopUserAgent;
        MobileUserAgent = preferences.MobileUserAgent;
    }

    public void Save()
    {
        var jsonContent = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(_configFilePath, jsonContent);
    }
}