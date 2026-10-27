using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public AudioClip completeLevelAudio;
    public string level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            AudioSource.PlayClipAtPoint(completeLevelAudio, transform.position);
            SceneManager.LoadScene(level);
        }
    }
}
