using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneRace()
    {
        SceneManager.LoadScene("main2");
    }
    
    public void ChangeSceneWinter()
    {
        SceneManager.LoadScene("main1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("main1");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void CoinCollections()
    {
        SceneManager.LoadScene("main3");
    }
}
