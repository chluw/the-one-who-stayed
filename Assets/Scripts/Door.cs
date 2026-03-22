using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKey;        // Must match keyID exactly
    public bool isOpen = false;

    public GameObject gateObject;     // Assign the visible gate (optional but recommended)

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Trying to open gate with key: [" + requiredKey + "]");

            if (InventoryManager.Instance.HasKey(requiredKey))
            {
                Debug.Log("Key FOUND");
                OpenDoor();
            }
            else
            {
                Debug.Log("Key NOT found");
            }
        }
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;

            Debug.Log("Gate opened!");

            // OPTION 1: Disable only the visible gate (recommended)
            if (gateObject != null)
            {
                gateObject.SetActive(false);
            }
            else
            {
                // OPTION 2: Destroy entire object if nothing assigned
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered gate range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left gate range");
        }
    }
}