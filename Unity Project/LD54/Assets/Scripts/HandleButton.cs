using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Main_Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Story");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
