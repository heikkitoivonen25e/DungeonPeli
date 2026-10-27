using System.Security.Cryptography;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerController _player;
    private Inventory _inventory;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            _player = collision.GetComponentInParent<PlayerController>();
            _inventory = collision.GetComponentInParent<Inventory>();
            Debug.Log("Interacting");

            _player.OnInteract += PickUp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _player.OnInteract -= PickUp;
    }

    private void PickUp()
    {
        _inventory.AddKey();
        _player.OnInteract -= PickUp;
        Destroy(gameObject);
    }




}
