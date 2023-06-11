using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsUIController : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;

    // Start is called before the first frame update
    void Start()
    {
        var root = uiDocument.rootVisualElement;
        
        var deleteSaveButton = root.Q<Button>("SaveDeleteButton");
        var MusicVolume = root.Q<Slider>("Music");
        var SoundVolume = root.Q<Slider>("Sound");
        var Graphic = root.Q<DropdownField>("Graphic-Settings");

        #region Handle Changing Events
        deleteSaveButton.clicked += () =>
        {
            Settings.DeleteAllSettings();
        };

        MusicVolume.RegisterValueChangedCallback(value =>
        {
            Settings.MusicVolume = value.newValue;
        });

        SoundVolume.RegisterValueChangedCallback(value =>
        {
            Settings.SoundVolume = value.newValue;
        });

        Graphic.RegisterValueChangedCallback(value =>
        {
            Settings.GraphicQuality = value.newValue;
        });
        #endregion

        MusicVolume.value = Settings.MusicVolume;
        SoundVolume.value = Settings.SoundVolume;
        Graphic.value = Settings.GraphicQuality;

    }
}
