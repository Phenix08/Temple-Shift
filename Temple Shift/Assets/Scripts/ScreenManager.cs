using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject welcomeScreen; // Reference to the Welcome Screen UI
    public GameObject controlsScreen; // Reference to the Controls Screen UI

    void Update()
    {
        // On Welcome Screen
        if (welcomeScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // Hide Welcome Screen and start the game
                welcomeScreen.SetActive(false);
                Debug.Log("Game Started!");
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                // Switch to Controls Screen
                welcomeScreen.SetActive(false);
                controlsScreen.SetActive(true);
                Debug.Log("Moved to Controls Screen");
            }
        }
        // On Controls Screen
        else if (controlsScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Go back to Welcome Screen
                controlsScreen.SetActive(false);
                welcomeScreen.SetActive(true);
                Debug.Log("Returned to Welcome Screen");
            }
        }
    }
}
