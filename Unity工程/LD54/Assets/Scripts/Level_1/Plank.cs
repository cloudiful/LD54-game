using System;
using TMPro;
using UnityEngine;

public class Plank : MonoBehaviour
{
    private GameManager _gameManager;

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.BoardCount += 3;
        _gameManager.UpdateBoardCountDisplay();
        Destroy(gameObject);
    }
}
