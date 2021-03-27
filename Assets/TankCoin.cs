using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCoin : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public int m_StartingCoin = 0;
    public int m_priceWeap1 = 150;
    public int m_priceWeap2 = 200;
    public int m_priceChar = 300;
    private int m_CurrentCoin;
    public Text totalCoinText;
    public AudioSource m_CollectCoinAudio;
    private string m_BuyItemButton;
    private string m_BuyChikenButton;

    // Start is called before the first frame update
    void Start()
    {
        m_BuyItemButton = "BuyPlayer" + m_PlayerNumber;
        m_BuyChikenButton = "Chiken" + m_PlayerNumber;
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


    public void BuyWeap()
    {
        // Reduce current health by the amount of damage done.
        if (m_CurrentCoin >= m_priceWeap1)
        {
            TankShooting shootTank = gameObject.GetComponent<TankShooting>();
            if (shootTank.ShellNumber >= 2 || (shootTank.ShellNumber == 1 && m_CurrentCoin < m_priceWeap2))
            {
                return;
            }
            shootTank.upgradeShell();

            m_CurrentCoin -= shootTank.ShellNumber == 1 ? m_priceWeap1 : m_priceWeap2;
            SetCoinUI();
        }


        // Change the UI elements appropriately.
        //SetHealthUI();
    }

    public void BuyChiken()
    {
        // Reduce current health by the amount of damage done.
        if (m_CurrentCoin >= m_priceChar)
        {
            TankHealth healthTank = gameObject.GetComponent<TankHealth>();
            if (!healthTank.invisible && !healthTank.haveHealer)
            {
                healthTank.CreateAggroHolder();
                m_CurrentCoin -= m_priceChar;
                SetCoinUI();
            }
        }


        // Change the UI elements appropriately.
        //SetHealthUI();
    }

    public void BuyPenguin()
    {
        // Reduce current health by the amount of damage done.
        if (m_CurrentCoin >= m_priceChar)
        {
            TankHealth healthTank = gameObject.GetComponent<TankHealth>();
            if (!healthTank.invisible && !healthTank.haveHealer)
            {
                healthTank.CreateHealer();
                m_CurrentCoin -= m_priceChar;
                SetCoinUI();
            }
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
            BuyWeap();
        }
        if (Input.GetButtonDown(m_BuyChikenButton))
        {
            int gatcha = Random.Range(0, 3);
            Debug.Log(gatcha);
            if (gatcha == 0) {
                BuyChiken();
            } else {
                BuyPenguin();
            }

        }
    }

}
