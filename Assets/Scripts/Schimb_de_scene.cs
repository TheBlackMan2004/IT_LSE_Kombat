using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Schimb_de_scene : MonoBehaviour
{
  
    public void GoToSceneTwo()
    {
        SceneManager.LoadScene("fightScene");
    }
    public void GoToRaulFight()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
