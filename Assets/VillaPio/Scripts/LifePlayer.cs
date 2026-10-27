using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    private UiManager uiManager;
    public AudioClip healthAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (Player.vida < 2)
            {
                Player.vida += 1;
                uiManager = FindAnyObjectByType<UiManager>();
                uiManager.updateVidaText(Player.vida);
                AudioSource.PlayClipAtPoint(healthAudio, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
