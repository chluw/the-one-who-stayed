using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (HidingSpot.isPlayerHiding && Input.GetKeyDown(KeyCode.E))
        {
            HidingSpot.ExitHide(gameObject);
            return;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponentInParent<HidingSpot>()?.Interact();
            }
        }
    }
}