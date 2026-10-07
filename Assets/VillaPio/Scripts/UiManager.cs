using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TMP_Text coinText;
    public int totalCoins = 0;
    public int collectedCoins = 0;

    public GameObject botonReiniciar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botonReiniciar = GameObject.FindGameObjectWithTag("BotonReiniciar");
        botonReiniciar.SetActive(false);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        totalCoins = coins.Length;
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void showMenu()
    {
        botonReiniciar.SetActive(true);
    }
}
