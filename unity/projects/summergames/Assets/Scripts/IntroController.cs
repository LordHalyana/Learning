using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    public Image fade;
    public float fadeSpeed = 2.0f;

    private bool isFading;


    private void Start()
    {
        isFading = false;

        fade.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isFading)
        {
            fade.gameObject.SetActive(true);

            fade.color = Color.Lerp(fade.color, Color.black, fadeSpeed * Time.deltaTime);
        }
    }

    public void StartGamePrep()
    {        
        isFading = true;

        Invoke("StartGame", fadeSpeed);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }


}
