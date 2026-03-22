using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID; // unique key name (ex: "BasementKey")

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddKey(keyID);
            Debug.Log("Picked up key: " + keyID);
            Destroy(gameObject);
        }
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed near key");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}