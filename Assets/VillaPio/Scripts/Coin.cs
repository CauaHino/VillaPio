using UnityEngine;

public class Coin : MonoBehaviour
{
    private UiManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            uiManager = FindAnyObjectByType<UiManager>();
            uiManager.CoinCollected();
            Destroy(gameObject);
        }
    }
}
