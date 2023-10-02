using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Empty : MonoBehaviour
{
    public bool isMouseIn;
    
    
    private GameObject _buttonMain;

    // Start is called before the first frame update
    void Start()
    {
        isMouseIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)&&isMouseIn)
        {
            if (transform.Find("Floor") == null && GameManager.instance.selected!=this)
            {
                //Instantiate(GameManager.instance.creations[0], transform);
                GameManager.instance.selected = gameObject;
                GameManager.instance.ShowBorder();
                
            }
            else
            {
                //Destroy(transform.GetChild(0).gameObject);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.Find("Border").gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        isMouseIn = true;
    }

    private void OnMouseExit()
    {
        isMouseIn = false;
    }
}
