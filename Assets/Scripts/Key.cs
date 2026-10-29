using System.Security.Cryptography;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Inventory _inventory;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            // _playerController = collision.GetComponentInParent<PlayerController>();
            Debug.Log("Interacting");

            _playerController.OnInteract += PickUp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerController.OnInteract -= PickUp;
    }

    public void PickUp()
    {
        _inventory.AddKey();
        _playerController.OnInteract -= PickUp;
        Destroy(gameObject);
    }




}
