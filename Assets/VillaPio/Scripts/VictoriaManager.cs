using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaManager : MonoBehaviour
{
    public void VolverAlMenuInicial()
    {
        Player.vida = 2;
        Player.intentos = 5;
        Player.municion = 10;
        
        SceneManager.LoadScene("Menu"); 
    }
}