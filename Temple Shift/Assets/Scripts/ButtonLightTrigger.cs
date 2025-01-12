using UnityEngine;

public class ButtonLightController : MonoBehaviour
{
    public Light targetLight; // Reference to the light (can be any type of light)
    public bool toggleLightOnExit = false; // Toggle to allow light to remain on/off when the player exits

    private GameObject playerRed; // Reference to the Red Player
    private GameObject playerGreen; // Reference to the Green Player

    void Start()
    {
        // Find the Red and Green player GameObjects
        playerRed = GameObject.Find("PlayerRed");
        playerGreen = GameObject.Find("PlayerGreen");

        // Ensure the light is off at the start
        if (targetLight != null)
        {
            targetLight.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is either PlayerRed or PlayerGreen
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
            // Enable the light
            if (targetLight != null)
            {
                targetLight.enabled = true;
                Debug.Log("Button triggered by " + other.gameObject.name + ". Light enabled!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is either PlayerRed or PlayerGreen
        if (other.gameObject == playerRed || other.gameObject == playerGreen)
        {
            // Toggle the light off only if toggleLightOnExit is true
            if (targetLight != null && toggleLightOnExit)
            {
                targetLight.enabled = false;
                Debug.Log("Player stepped off. Light disabled!");
            }
        }
    }
}
