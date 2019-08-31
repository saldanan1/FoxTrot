using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Animator animator;

    void OnTriggerStay2D(Collider2D itemCollide)
    {
        animator.SetBool("itemPickup", false);
        PlayerController.jumpsLeft = 1;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("itemPickup", true);
    }
}
