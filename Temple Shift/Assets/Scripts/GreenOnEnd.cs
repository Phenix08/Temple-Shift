using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GreenOnEnd : MonoBehaviour
{

    private GameObject playerGreen;

    public bool isGreenOnEnd;
    // Start is called before the first frame update
    void Start()
    {
        isGreenOnEnd = false;
        playerGreen = GameObject.Find("PlayerGreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGreen)
        {
            isGreenOnEnd = true;
            Debug.Log("Green is on end");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerGreen)
        {
            isGreenOnEnd = false;
        }
    }
}
