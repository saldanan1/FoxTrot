using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformMovementX : MonoBehaviour
{
    public float timeElapsed;
    public Vector2 v;
    public float multiplier;
    void Start()
    {
        v = transform.position;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        transform.position = v + new Vector2(Mathf.Sin(timeElapsed) * multiplier, 0);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.collider.transform.SetParent(null);
            }
    }
}