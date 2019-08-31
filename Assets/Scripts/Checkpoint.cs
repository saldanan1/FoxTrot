using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Color green = new Color(0f, 255f, 0f, 255f);
    public SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sprite.color != green)
            {
                GameController.respawnPoint = collision.transform.position;
                sprite.color = green;
            }
        }
    }
}
