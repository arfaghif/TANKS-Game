using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCoin : MonoBehaviour
{
    public LayerMask m_CoinMask;
    public int m_StartingCoin = 0;
    private int m_CurrentCoin;

    // Start is called before the first frame update
    void Start()
    {


    }

    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's coin.
        m_CurrentCoin = m_StartingCoin;

        // Update the health slider's value and color.
        //SetHealthUI();
    }

    public void TakeCoin(int amount)
    {
        // Reduce current health by the amount of damage done.
        m_CurrentCoin += amount;

        // Change the UI elements appropriately.
        //SetHealthUI();
    }


    public void BuyItem(int price)
    {
        // Reduce current health by the amount of damage done.
        if (m_CurrentCoin >= price)
        {
            m_CurrentCoin -= price;
        }


        // Change the UI elements appropriately.
        //SetHealthUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
