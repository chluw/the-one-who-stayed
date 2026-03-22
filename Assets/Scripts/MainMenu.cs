using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject player;   // ✅ lowercase

    private PlayerMovement playerController;

    void Start()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (player != null)
        {
            playerController = player.GetComponent<PlayerMovement>();

            if (playerController != null)
                playerController.enabled = false;
        }
    }

    public void StartGame()
    {
        menuUI.SetActive(false);

        Time.timeScale = 1f;

        if (playerController != null)
            playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}