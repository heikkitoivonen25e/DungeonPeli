using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public Action OnInteract;

    private void Awake()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Pressed F");
        OnInteract?.Invoke();
    }



}
