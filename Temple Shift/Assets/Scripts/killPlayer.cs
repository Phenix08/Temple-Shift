using System.Collections;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject spawnRed;
    public GameObject spawnGreen;
    public AudioClip killSound; 

    private GameObject playerRed;
    private GameObject playerGreen;

    void Start()
    {
        playerGreen = GameObject.Find("PlayerGreen");
        playerRed = GameObject.Find("PlayerRed");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
            if (killSound != null)
            {
                AudioSource.PlayClipAtPoint(killSound, transform.position, 10f);
            }

            playerRed.transform.position = spawnRed.transform.position;
            playerGreen.transform.position = spawnGreen.transform.position;
        }
    }
}
