using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> creations;
    public List<int> stores;
    public static GameManager instance;
    public GameObject selected;

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

    public void AddFloor()
    {
        if (stores[0]>0 && selected!=null && selected.transform.Find("Floor")==null)
        {
            Instantiate(creations[0], selected.transform);
            stores[0]--;
            UIManager.instance.Refresh();
        }
    }

    public void ShowBorder()
    {
        if (selected!=null)
        {
            selected.transform.Find("Border").gameObject.SetActive(true);
        }
    }
}
