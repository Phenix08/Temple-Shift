using System.Collections;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    public GameObject gate;
    public AudioClip moveSound; 
    public float distance;
    public float speed;

    private GameObject playerGreen;
    private GameObject playerRed;
    private Vector3 open;
    private Vector3 closed;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private AudioSource audioSource;

    void Start()
    {
        playerRed = GameObject.Find("PlayerRed");
        playerGreen = GameObject.Find("PlayerGreen");
        closed = gate.transform.position;
        open = closed - new Vector3(0, distance, 0);
        targetPosition = closed;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = moveSound; 
        audioSource.loop = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
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

        if (moveSound != null && audioSource != null)
        {
            audioSource.Play();
        }

        while (Vector3.Distance(gate.transform.position, targetPosition) > 0.01f)
        {
            gate.transform.position = Vector3.Lerp(gate.transform.position, targetPosition, Time.deltaTime * (1 / speed));
            yield return null;
        }

        gate.transform.position = targetPosition;
        isMoving = false;
    }
}
