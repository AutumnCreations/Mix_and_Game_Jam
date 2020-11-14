using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Sprite defaultIcon;
    [SerializeField] Sprite mutedIcon;

    AudioSource audioSource;
    Image buttonImage;

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

        //audioSource = GetComponent<AudioSource>();
        //audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void MuteAudio()
    {
        buttonImage = GetComponent<Image>();

        if(hasBeenClicked)
        {
            audioSource.volume = 0;
            hasBeenClicked = !hasBeenClicked;
            buttonImage.sprite = mutedIcon;
        }
        else if (!hasBeenClicked)
        {
            audioSource.volume = 1;
            hasBeenClicked = !hasBeenClicked;
            buttonImage.sprite = defaultIcon;
        }
    }


    //public void SetVolume(float volume)
    //{
    //    audioSource.volume = volume;
    //}
}
