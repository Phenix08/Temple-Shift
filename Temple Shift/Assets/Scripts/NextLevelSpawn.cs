using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NextLevelSpawn : MonoBehaviour
{
    public GameObject endRed;
    public GameObject endGreen;

    public GameObject nextLevel;

    private RedOnEnd endRedScript;
    private GreenOnEnd endGreenScript;
    // Start is called before the first frame update
    void Start()
    {
        endRedScript = FindObjectOfType<RedOnEnd>();
        endGreenScript = FindObjectOfType<GreenOnEnd>();

    }

    // Update is called once per frame
    void Update()
    {
        if(endRedScript != null && endGreenScript != null)
        {
            bool redInZone = endRedScript.isRedOnEnd;
            bool greenInZone = endGreenScript.isGreenOnEnd;

            if(redInZone && greenInZone)
            {
                Destroy(gameObject);
                Instantiate(nextLevel, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
