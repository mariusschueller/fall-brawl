using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerUI : MonoBehaviour
{
    public static void ToNetworking()
    {
        SceneManager.LoadScene(1);
    }
    
    public static void BackToStart()
    {
    	SceneManager.LoadScene(0);
    }
    
    public static void HowToPlay(){
    	SceneManager.LoadScene("HowToPlay");
    }
    

}
