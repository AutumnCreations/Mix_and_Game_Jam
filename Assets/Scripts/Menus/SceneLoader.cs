using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Main Menu");

	}

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

	public void LoadNextLevel()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex + 2);
	}


	public void LoadOptions()
    {
        SceneManager.LoadScene("Options");

	}
 
}
