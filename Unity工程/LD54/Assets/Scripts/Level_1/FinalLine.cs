using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Scenes/Story_End");
    }
}
