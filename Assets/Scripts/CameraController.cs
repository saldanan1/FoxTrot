using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameController.selectedPrefab;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;   
    }
}
