using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.transform.CompareTag("Player"))
      {
         Player player = collision.GetComponent<Player>();
         player.Die();
      }
   }
}
