using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCoin : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public int m_StartingCoin = 0;
    private int m_CurrentCoin;
    public Text totalCoinText;
    public AudioSource m_CollectCoinAudio;
    private string m_BuyItemButton;

    // Start is called before the first frame update
    void Start()
    {
        m_BuyItemButton = "BuyPlayer" + m_PlayerNumber;
    }

    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's coin.
        m_CurrentCoin = m_StartingCoin;

        // Update the health slider's value and color.
        SetCoinUI();
    }

    public void TakeCoin(int amount)
    {
        // Reduce current health by the amount of damage done.
        m_CurrentCoin += amount;
        m_CollectCoinAudio.Play();

        // Change the UI elements appropriately.
        //SetHealthUI();
        SetCoinUI();
    }


    public void BuyItem(int price)
    {
        // Reduce current health by the amount of damage done.
        if (m_CurrentCoin >= price)
        {
            m_CurrentCoin -= price;
            SetCoinUI();
        }


        // Change the UI elements appropriately.
        //SetHealthUI();
    }
    private void SetCoinUI()
    {
        // Set the slider's value appropriately.
        totalCoinText.text = "Coin: " + m_CurrentCoin;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        //m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(m_BuyItemButton))
        {
            BuyItem(70);
        }
    }

}
