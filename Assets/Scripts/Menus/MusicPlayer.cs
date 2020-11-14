using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

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
        
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
