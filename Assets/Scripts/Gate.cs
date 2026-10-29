using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player") && inventory.hasKey == true)
        {
            Destroy(gameObject);
        }
    }
}