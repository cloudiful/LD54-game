using System;
using TMPro;
using UnityEngine;

public class Plank : MonoBehaviour
{
    private GameManager _gameManager;
    public TextMeshProUGUI textMeshProUGUI;

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.boardCount += 3;
        GameManager.UpdateBoardCountDisplay(textMeshProUGUI);
        Destroy(gameObject);
    }
}
