using UnityEngine;

public class Coin : MonoBehaviour
{
    private UiManager uiManager;
    public AudioClip coinAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            uiManager = FindAnyObjectByType<UiManager>();
            uiManager.CoinCollected();
            AudioSource.PlayClipAtPoint(coinAudio, transform.position);
            Destroy(gameObject);
        }
    }
}
