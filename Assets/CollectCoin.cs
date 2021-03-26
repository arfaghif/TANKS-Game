using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public LayerMask m_TankMask;
    public float m_MaxLifeTime = 15f;
    public int m_CoinValue = 100;
    public float m_CoinRadius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Masuk");
        Destroy(gameObject, m_MaxLifeTime);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        TankCoin targetCoin = other.GetComponent<TankCoin>();
        if (targetCoin)
        {
            targetCoin.TakeCoin(m_CoinValue);
            Destroy(gameObject);
        }

    }
}
