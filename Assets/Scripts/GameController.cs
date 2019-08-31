using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public static int CharacterSelection;

    public GameObject squirrelPrefab;
    public GameObject foxPrefab;

    public static GameObject selectedPrefab;
    public static Transform parent;

    public float gmX;
    public float gmY;
    public float gmZ;

    public static Vector3 respawnPoint = new Vector3(0f, 0f, 0f);

    void Awake()
    {
        instance = this;
        parent = GameObject.FindGameObjectWithTag("Basics").transform;
        gmX = GameObject.FindGameObjectWithTag("GM").transform.position.x;
        gmY = GameObject.FindGameObjectWithTag("GM").transform.position.y;
        gmZ = GameObject.FindGameObjectWithTag("GM").transform.position.z;
        respawnPoint = new Vector3(gmX, gmY, gmZ);
        if (CharacterSelection == 0)
        {
            SpawnPlayer(foxPrefab);
        }
        else if (CharacterSelection == 1)
        {
            SpawnPlayer(squirrelPrefab);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPlayer(GameObject selection)
    {
        selectedPrefab = Instantiate(selection, respawnPoint, Quaternion.identity);
        selectedPrefab.transform.SetParent(parent);
    }
}
