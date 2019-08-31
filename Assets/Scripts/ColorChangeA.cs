using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeA : MonoBehaviour
{
    SpriteRenderer groundColorA;
    BoxCollider2D objectCollider;
    Rigidbody2D _rb;

    int checker = 0;

    // Start is called before the first frame update
    void Start()
    {
        groundColorA = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<BoxCollider2D>();
        objectCollider.enabled = false;
        groundColorA.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (checker == 0))
        {
            if (PlayerController.jumpsLeft > 0)
            {
                groundColorA.enabled = true;
                objectCollider.enabled = true;
                checker++;
            }
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (checker == 1 ))
        {
            if (PlayerController.jumpsLeft > 0)
            {
                groundColorA.enabled = false;
                objectCollider.enabled = false;
                checker--;
            }
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -transform.up, 0.7f);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.tag == "Player")
                {
                    jumpsLeft = 1;
                    print("hereA");
                }
            }
        }
    }*/
}
