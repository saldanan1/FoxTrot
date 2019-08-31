using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLeavesScreen : MonoBehaviour
{
    public bool death;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.transform.position = GameController.respawnPoint;
        }
    }
}
