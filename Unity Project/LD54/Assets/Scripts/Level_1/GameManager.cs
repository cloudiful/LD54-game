using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    public int language = 0;
    public int boardCount = 3;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this);
        }

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Main_Menu");
    }
    
    
    /// <summary>
    /// This function returns mouse hovering object name
    /// </summary>
    /// <returns></returns>
    public static string MouseOn()
    {
        var mouseHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return !ReferenceEquals(mouseHit.collider, null) ? mouseHit.collider.name : null;
    }

    public static void UpdateBoardCountDisplay(TextMeshProUGUI t)
    {
        // update board count display
        t.text = String.Concat("Board remains: ", GameManager.instance.boardCount.ToString());
    }
    
    
}
