
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyVisibility : MonoBehaviour
{
    [Header("Player Lights")]
    [SerializeField] private Light2D playerGlow;
    [SerializeField] private Light2D flashlight;

    [Header("Fade Settings")]
    [SerializeField] private float fadeTime = 0.2f;
    [SerializeField] private float glowSoftness = 0.8f;
    [SerializeField] private float flashlightSoftness = 1.2f;
    [SerializeField] private float angleSoftness = 12f;

    private SpriteRenderer[] sprites;
    private Color[] originalColors;

    private float visibility = 0f;
    private float visibilityVelocity = 0f;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>(true);
        originalColors = new Color[sprites.Length];

        for (int i = 0; i < sprites.Length; i++)
        {
            originalColors[i] = sprites[i].color;

            Color color = originalColors[i];
            color.a = 0f;
            sprites[i].color = color;
        }
    }

    private void LateUpdate()
    {
        float glow = GetGlowVisibility();
        float beam = GetFlashlightVisibility();

        float targetVisibility = Mathf.Max(glow, beam);

        visibility = Mathf.SmoothDamp(
            visibility,
            targetVisibility,
            ref visibilityVelocity,
            Mathf.Max(0.01f, fadeTime)
        );

        for (int i = 0; i < sprites.Length; i++)
        {
            Color color = originalColors[i];
            color.a *= visibility;
            sprites[i].color = color;
        }
    }

    private float GetGlowVisibility()
    {
        if (playerGlow == null || !playerGlow.isActiveAndEnabled)
            return 0f;

        float distance = Vector2.Distance(
            transform.position,
            playerGlow.transform.position
        );

        float radius = playerGlow.pointLightOuterRadius;

        return SoftEdge(
            (radius - distance) / Mathf.Max(0.01f, glowSoftness)
        );
    }

    private float GetFlashlightVisibility()
    {
        if (flashlight == null || !flashlight.isActiveAndEnabled)
            return 0f;

        Vector2 direction =
            transform.position - flashlight.transform.position;

        float distance = direction.magnitude;
        float radius = flashlight.pointLightOuterRadius;

        if (distance < 0.001f)
            return 1f;

        float angle = Vector2.Angle(
            flashlight.transform.up,
            direction
        );

        float halfAngle = flashlight.pointLightOuterAngle / 2f;

        float distanceFade = SoftEdge(
            (radius - distance) /
            Mathf.Max(0.01f, flashlightSoftness)
        );

        float angleFade = SoftEdge(
            (halfAngle - angle) /
            Mathf.Max(0.01f, angleSoftness)
        );

        return distanceFade * angleFade;
    }

    private float SoftEdge(float value)
    {
        float t = Mathf.Clamp01(value);
        return t * t * (3f - 2f * t);
    }
}
