using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject optionsPanel;
    

	void Start ()
    {
        optionsPanel.SetActive(false);
	}
	
	void Update ()
    {

	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void CloseOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }


}
