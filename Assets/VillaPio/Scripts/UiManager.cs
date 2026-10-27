using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TMP_Text coinText;
    public int totalCoins = 0;
    public int collectedCoins = 0;
    
    public TMP_Text lifeText;
    public TMP_Text municionText;
    public TMP_Text saludText;
    public TMP_Text tiempoJuego;
    public float segundos = 0f;

    public GameObject botonReiniciar;
    public GameObject botonMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botonReiniciar = GameObject.FindGameObjectWithTag("BotonReiniciar");
        botonReiniciar.SetActive(false);
        botonMenu = GameObject.FindGameObjectWithTag("BotonMenu");
        botonMenu.SetActive(false);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        totalCoins = coins.Length;
        UpdateCoinText();
        updateVidaText(Player.vida);
        updateProyectileText(Player.municion);
        updateTentativaText(Player.intentos);
    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime;
        updateTimeText();
    }

    public void CoinCollected()
    {
        collectedCoins++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = $"{collectedCoins.ToString()} / {totalCoins.ToString()}";
    }

    public void showMenu(int vidas)
    {
        botonMenu.SetActive(true);
        if (vidas > 0)
        {
            botonReiniciar.SetActive(true);
        }
        else
        {
            botonReiniciar.SetActive(false);
        }
    }

    public void updateVidaText(int vida)
    {
        lifeText.text = $"Vidas: {vida}";
    }
    
    public void updateTentativaText(int intento)
    {
        saludText.text = $"Salud: {intento}";
    }
    
    public void updateProyectileText(int municion)
    {
        municionText.text = $"{municion}";
    }

    public void updateTimeText()
    {
        int segs = Mathf.FloorToInt(segundos % 60f);
        tiempoJuego.text = $"Tiempo de Juego: {segs}";
    }
    
    public void ReiniciarNivel()
    {
        Player.intentos = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void VolverAlMenu()
    {
        Player.vida = 2; 
        Player.intentos = 5;
        Player.municion = 10;
        
        SceneManager.LoadScene("Menu");
    }
}
