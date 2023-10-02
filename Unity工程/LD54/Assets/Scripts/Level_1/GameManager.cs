using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<int> stores;
    public static GameManager instance;
    
    public GameObject textBoardCount;

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
        SceneManager.LoadScene("Scenes/Menu");
    }
    
    public void UpdateCount()
    {
        var t = textBoardCount.GetComponent<TextMeshPro>();
        t.text = "Boards remain: 111";
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
