using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            //musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveSettings(float volume)
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneLoader>().LoadFirstScene();
    }

    public void SetDefaultSettings()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
