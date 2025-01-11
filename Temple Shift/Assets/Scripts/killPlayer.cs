using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
            playerRed.transform.position = spawnRed.transform.position;
            playerGreen.transform.position = spawnGreen.transform.position;
        }
    }
}
