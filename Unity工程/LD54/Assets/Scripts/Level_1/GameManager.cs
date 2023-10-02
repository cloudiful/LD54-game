using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    public int BoardCount = 3;
    
    public TextMeshProUGUI textBoardCount;
    
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

    private void Start()
    {
        Debug.Log(textBoardCount);
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

    public void UpdateBoardCountDisplay()
    {
        Debug.Log(textBoardCount);
        // update board count display
        textBoardCount.text = String.Concat("Board remains: ", GameManager.instance.BoardCount.ToString());
    }
    
    
}
