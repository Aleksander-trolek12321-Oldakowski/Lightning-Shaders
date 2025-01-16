using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float detectionRadius = 1.5f;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float targetAlpha = 0.3f;

    public SpriteRenderer spriteRenderer;
    private bool isPlayerNearby = false;

    private void Update()
    {
        HandlePlayerDetection();
    }

    private void HandlePlayerDetection()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (player && !isPlayerNearby)
        {
            isPlayerNearby = true;
            FadeTo(targetAlpha);
        }
        else if (!player && isPlayerNearby)
        {
            isPlayerNearby = false;
            FadeTo(1f);
        }
    }

    private async void FadeTo(float targetAlpha)
    {
        if (spriteRenderer == null) return;

        Color color = spriteRenderer.color;
        float startAlpha = color.a;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            await System.Threading.Tasks.Task.Yield();
        }

        color.a = targetAlpha;
        spriteRenderer.color = color;
    }

    private void OnDrawGizmosSelected()
    {
        // Rysuj promień wykrywania w edytorze
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
