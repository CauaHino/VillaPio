using UnityEngine;

public class BombPickup : MonoBehaviour
{
    public int municionARecuperar = 2;
    private UiManager uiManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Player.municion += municionARecuperar;
            uiManager = FindAnyObjectByType<UiManager>();
            if (uiManager != null)
            {
                uiManager.updateProyectileText(Player.municion);
            }
            Destroy(gameObject);
        }
    }
}
