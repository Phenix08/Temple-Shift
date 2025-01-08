using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject spawnRed;
    public GameObject spawnGreen;

    private GameObject playerRed;
    private GameObject playerGreen;
    // Start is called before the first frame update
    void Start()
    {
        playerGreen = GameObject.Find("PlayerGreen");
        playerRed = GameObject.Find("PlayerRed");
        playerRed.transform.position = spawnRed.transform.position;
        playerGreen.transform.position = spawnGreen.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
