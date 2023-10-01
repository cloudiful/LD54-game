using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public List<GameObject> Icons;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        var t = Icons[0].GetComponentInChildren<Text>();
        t.text = "ʣ�ࣺ" + GameManager.instance.stores[0];
    }
}
