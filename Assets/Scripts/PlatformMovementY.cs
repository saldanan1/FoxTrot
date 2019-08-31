using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformMovementY : MonoBehaviour
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
        transform.position = v + new Vector2(0,Mathf.Sin(timeElapsed) * multiplier);

        //transform.position = new Vector2(0, Mathf.Sin(timeElapsed) * 4f);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}