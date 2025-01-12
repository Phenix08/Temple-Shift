using UnityEngine;

public class HideParentOnClick : MonoBehaviour
{
    // Function to hide the parent GameObject
    public GameObject test;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            show(test);
        }
    }
    public void hide(GameObject obj)
    {
        obj.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void show(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}

