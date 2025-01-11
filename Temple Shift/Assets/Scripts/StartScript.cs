using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject spawnRed;
    public GameObject spawnGreen;

    private GameObject playerRed;
    private GameObject playerGreen;

    private float teleportDelay = 0.2f; // Delay in seconds
    private float timer = 0f;
    private bool hasTeleported = false;

    void Start()
    {
        playerGreen = GameObject.Find("PlayerGreen");
        playerRed = GameObject.Find("PlayerRed");
    }

    void Update()
    {
        if (!hasTeleported)
        {
            timer += Time.deltaTime;

            if (timer >= teleportDelay)
            {
                playerRed.transform.position = spawnRed.transform.position;
                playerGreen.transform.position = spawnGreen.transform.position;
                hasTeleported = true; // Ensure teleport happens only once
            }
        }
    }
}