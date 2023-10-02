using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<int> stores;
    public static GameManager instance;
    
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

        stores[0] = 3;
        
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
    
}
