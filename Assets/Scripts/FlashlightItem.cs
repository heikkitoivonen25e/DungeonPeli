using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class FlashlightItem : MonoBehaviour
{
    [SerializeField] private float rotationOffset = -90f;

    private Light2D flashlightLight;
    private bool isEquipped = true;

    public bool IsEquipped => isEquipped;
    public bool CanDrop => false;

    private void Awake()
    {
        flashlightLight = GetComponent<Light2D>();

        if (flashlightLight == null)
        {
            Debug.LogError("Flashlight needs a Light2D!");
            enabled = false;
            return;
        }

        SetEquipped(true);
    }

    private void Update()
    {
        // Temporary equip button: Q
        if (Keyboard.current != null &&
            Keyboard.current.qKey.wasPressedThisFrame)
        {
            SetEquipped(!isEquipped);
        }

        // Player's last movement direction
        Vector2 direction = InputManager.Movement;

        if (direction.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(
                direction.y,
                direction.x
            ) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(
                0f, 0f, angle + rotationOffset
            );
        }
    }

    public void SetEquipped(bool equipped)
    {
        isEquipped = equipped;
        flashlightLight.enabled = equipped;
    }
}