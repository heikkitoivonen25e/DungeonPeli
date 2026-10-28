using System.Security.Cryptography;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerController _playerController;
    private Inventory _inventory;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            _playerController = collision.GetComponentInParent<PlayerController>();
            _inventory = collision.GetComponentInParent<Inventory>();
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
