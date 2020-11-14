using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField] Sprite[] musicIcons;
    Image button;

    bool hasBeenClicked = true;

    //private void Awake()
    //{
    //    if (FindObjectOfType<SceneLoader>().index == 1 || FindObjectOfType<SceneLoader>().index == 0)
    //    {

    //    SetUpSingleton();
    //    }
    //}

  //  private void SetUpSingleton()
  //  {
  //      if(FindObjectsOfType(GetType()).Length > 1 && (FindObjectOfType<SceneLoader>().index == 1 || FindObjectOfType<SceneLoader>().index == 0))
  //      {
		//	Destroy(gameObject);
		//} else
  //      {
		//	DontDestroyOnLoad(gameObject);
		//}
  //  }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        button = GetComponent<Image>();


        //audioSource = GetComponent<AudioSource>();
        //audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void MuteAudio()
    {
        if(hasBeenClicked)
        {
            audioSource.volume = 0;
            hasBeenClicked = !hasBeenClicked;
            //button.sprite = musicIcons[1];
        }
        else if (!hasBeenClicked)
        {
            audioSource.volume = 1;
            hasBeenClicked = !hasBeenClicked;
            //button.sprite = musicIcons[0];
        }
    }


    //public void SetVolume(float volume)
    //{
    //    audioSource.volume = volume;
    //}
}
