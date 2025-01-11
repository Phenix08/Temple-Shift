using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RedOnEnd : MonoBehaviour
{

    private GameObject playerRed;

    public bool isRedOnEnd;
    // Start is called before the first frame update
    void Start()
    {
        isRedOnEnd = false;
        playerRed = GameObject.Find("PlayerRed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerRed)
        {
            isRedOnEnd = true;
            Debug.Log("Red is on end");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerRed)
        {
            isRedOnEnd = false;
        }
    }
}
