using System.Collections;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    public GameObject gate;
    private GameObject playerGreen;
    private GameObject playerRed;
    public float distance;
    public float speed;

    private Vector3 open;
    private Vector3 closed;
    private Vector3 targetPosition;  // The current target position for the gate
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRed = GameObject.Find("PlayerRed");
        playerGreen = GameObject.Find("PlayerGreen");
        closed = gate.transform.position;
        open = closed - new Vector3(0, distance, 0);
        targetPosition = closed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
            // Set the target position to open
            targetPosition = open;
            if (!isMoving)
            {
                StartCoroutine(MoveGate());
            }
        }
        this.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
            // Set the target position to closed
            targetPosition = closed;
            if (!isMoving)
            {
                StartCoroutine(MoveGate());
            }
        }
        this.GetComponent<Renderer>().enabled = true;
    }

    private IEnumerator MoveGate()
    {
        isMoving = true;

        while (Vector3.Distance(gate.transform.position, targetPosition) > 0.01f)
        {
            gate.transform.position = Vector3.Lerp(gate.transform.position, targetPosition, Time.deltaTime * (1 / speed));
            yield return null;
        }

        gate.transform.position = targetPosition;  // Ensure it reaches the exact position
        isMoving = false;
    }
}

