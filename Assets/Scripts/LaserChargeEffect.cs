using UnityEngine;

public class LaserChargeEffect : MonoBehaviour
{
    public float fadeSpeed = 8f;
    public float pulseSpeed = 12f;
    public float pulseAmount = 0.15f;

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;
    private float chargeTime = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        Color color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
    }

    void Update()
    {
        bool shooting = Input.GetMouseButton(0);

        Color color = spriteRenderer.color;
        float targetAlpha = shooting ? 1f : 0f;

        color.a = Mathf.MoveTowards(
            color.a,
            targetAlpha,
            fadeSpeed * Time.deltaTime
        );

        spriteRenderer.color = color;

        if (shooting)
        {
            chargeTime += Time.deltaTime;

            float pulse = 1f + Mathf.Sin(chargeTime * pulseSpeed) * pulseAmount;
            transform.localScale = originalScale * pulse;
        }
        else
        {
            chargeTime = 0f;

            transform.localScale = Vector3.Lerp(
                transform.localScale,
                originalScale,
                fadeSpeed * Time.deltaTime
            );
        }
    }
}