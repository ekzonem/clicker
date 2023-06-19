using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : Main
{
    public Dropdown dropdown;
    public Sprite[] arr_option_image;

    public Sprite[] arr_music_sprite;
    public Sprite[] arr_sound_sprite;
    public Button[] arr_button_sound;

    int selected_value;

    
    void Start()
    {
        GetMusic();
        SetOption();
        dropdown.onValueChanged.AddListener(DropdownValueChanged);
        dropdown.value = planet_id;
        dropdown.RefreshShownValue();
    }
    void GetMusic()
    {
        int value = PlayerPrefs.GetInt("music", 1);
        if (value == 1)
        {
            arr_button_sound[0].GetComponent<Image>().sprite = arr_music_sprite[0];
            ControlAudio.audioSource.Play();
        }
        else
        {
            arr_button_sound[0].GetComponent<Image>().sprite = arr_music_sprite[1];
            ControlAudio.audioSource.Stop();
        }
    }
    public void SetMusic()
    {
        bool isOnMusic = !ControlAudio.audioSource.isPlaying;
        ControlAudio.audioSource.enabled = isOnMusic;

        int musicValue = isOnMusic ? 1 : 0;
        PlayerPrefs.SetInt("music", musicValue);
        PlayerPrefs.Save();

        GetMusic();
    }
    private void SetOption()
    {
        dropdown.ClearOptions();
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i = 0; i < planet_level+1; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            switch (i)
            {
                case 0:
                    option.text = "Erde";
                    break;
                case 1:
                    option.text = "Aresis";
                    break;
                case 2:
                    option.text = "Tera";
                    break;
                case 3:
                    option.text = "Libra";
                    break;
                case 4:
                    option.text = "Aurelia";
                    break;

            }
            option.image = arr_option_image[i];
            options.Add(option);
        }

        dropdown.AddOptions(options);
    }
    private void DropdownValueChanged(int value)
    {
        selected_value = value;
        switch (selected_value)
        {
            case 0:
                planet_id = 0;
                break;
            case 1:
                planet_id = 1;
                break;
            case 2:
                planet_id = 2;
                break;
            case 3:
                planet_id = 3;
                break;
            case 4:
                planet_id = 4;
                break;
        }
        PlayerPrefs.SetInt("planet_id", planet_id);

    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ToScene()
    {
        SceneManager.LoadScene(scene_setting);
    }
    void Update()
    {
        
    }
}
