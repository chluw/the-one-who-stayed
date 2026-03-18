using UnityEngine;
using System.Collections;

public class HidingSpot : MonoBehaviour
{
    public Transform hidePosition;

    public static bool isPlayerHiding = false;

    private GameObject player;
    private CharacterController controller;
    private PlayerMovement movement;

    private float originalHeight;
    private Vector3 originalCenter;

    public void Interact()
    {
        if (!isPlayerHiding)
        {
            EnterHide();
        }
    }

    void EnterHide()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        movement = player.GetComponent<PlayerMovement>();

        originalHeight = controller.height;
        originalCenter = controller.center;

        movement.canMove = false;

        controller.height = 0.5f;
        controller.center = new Vector3(0, 0.25f, 0);

        controller.enabled = false;

        player.transform.SetPositionAndRotation(
            hidePosition.position,
            hidePosition.rotation
        );

        StartCoroutine(ReenableController());

        isPlayerHiding = true;

        Debug.Log("Hiding...");
    }

    public static void ExitHide(GameObject player)
    {
        CharacterController controller = player.GetComponent<CharacterController>();
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        controller.height = 1f;
        controller.center = new Vector3(0, 0.5f, 0);

        movement.canMove = true;

        isPlayerHiding = false;

        Debug.Log("Exited hiding");
    }

    IEnumerator ReenableController()
    {
        yield return null;
        controller.enabled = true;
    }
}