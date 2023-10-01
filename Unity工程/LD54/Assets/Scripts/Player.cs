using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
        {
            AttemptMove(new Vector2(Input.GetAxisRaw("Horizontal")*10, Input.GetAxisRaw("Vertical")*10));
        }
    }

    private void AttemptMove(Vector2 moveDir)
    {
        Vector3 dst = transform.position + new Vector3(moveDir.x, moveDir.y, 0);
        RaycastHit2D hit;
        hit=Physics2D.Linecast(transform.position, dst);

        Debug.Log(transform.position+"  "+dst);
        Debug.DrawLine(transform.position, dst,Color.red);

        if (hit.collider.tag=="Floor")
        {
            transform.position = hit.collider.transform.position;
        }
    }
}
