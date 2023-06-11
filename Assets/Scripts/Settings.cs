using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Settings
{
    static float soundVolume = 100;
    static public float SoundVolume { get { return soundVolume; } set {
            soundVolume = value;
            PlayerPrefs.SetFloat(nameof(SoundVolume), soundVolume);
        } }
    static float musicVolume = 100;
    static public float MusicVolume { get { return musicVolume; } set
        {
            musicVolume = value;
            PlayerPrefs.SetFloat(nameof(MusicVolume), musicVolume);
        } }

    static string graphicQuality = "High";
    static public string GraphicQuality { get { return graphicQuality; } set
        {
            graphicQuality = value;
            PlayerPrefs.SetString(nameof(GraphicQuality), graphicQuality);
        } }

    static public void SaveSettings()
    {
        PlayerPrefs.SetFloat(nameof(MusicVolume), MusicVolume);
        PlayerPrefs.SetFloat(nameof(SoundVolume), SoundVolume);
        PlayerPrefs.SetString(nameof(GraphicQuality), GraphicQuality);

        PlayerPrefs.Save();
    }

    static public void LoadSettings()
    {
        musicVolume = PlayerPrefs.GetFloat(nameof(MusicVolume), 100);
        soundVolume = PlayerPrefs.GetFloat(nameof(SoundVolume), 100);
        graphicQuality = PlayerPrefs.GetString(nameof(GraphicQuality), "High");
    }

    static public void DeleteAllSettings()
    {
        PlayerPrefs.DeleteAll();
    }
}
