using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Action OnInteract;

    public void Interact()
    {
        Debug.Log("Pressed F");
        OnInteract?.Invoke();
    }



}
