using UnityEngine;

public class Gate : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && inventory.hasKey == true)
        {
            Destroy(gameObject);
        }
    }
}