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
        Debug.Log("SCENE RACE");
        SceneManager.LoadScene("main2");
    }
    
    public void ChangeSceneWinter()
    {
        SceneManager.LoadScene("main1");
    }
}
