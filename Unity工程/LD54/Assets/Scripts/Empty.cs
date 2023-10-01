using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{
    public bool isMouseIn;

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
            if (transform.childCount == 0 && GameManager.instance.selected!=this)
            {
                //Instantiate(GameManager.instance.creations[0], transform);
                GameManager.instance.selected = gameObject;
            }
            else
            {
                //Destroy(transform.GetChild(0).gameObject);
            }
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
