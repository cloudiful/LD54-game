using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Input = UnityEngine.Windows.Input;

public class Story : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public TextAsset storyChinese;
    public TextAsset storyEnglish;
    
    private String _story = "";
    private String[] _storyLines = null;
    private int _lineNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        var preferedLanguage = PlayerPrefs.GetInt("language",0);

        if (preferedLanguage == 0)
        {
            _story = storyEnglish.text;
        }
        else
        {
            _story = storyChinese.text;
        }

        _storyLines = _story.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        textMeshProUGUI.text = _storyLines[_lineNumber];
        

    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
        
    }

    private void ShowNextLine()
    {
        if (_lineNumber >= _storyLines.Length - 1)
        {
            if (SceneManager.GetActiveScene().name == "Story")
            {
                SceneManager.LoadScene("Scenes/Level_1");
            }
            else
            {
                SceneManager.LoadScene("Scenes/Ending");
            }
            return;
        }
        _lineNumber++;
        textMeshProUGUI.text = _storyLines[_lineNumber];
    }
    
}
