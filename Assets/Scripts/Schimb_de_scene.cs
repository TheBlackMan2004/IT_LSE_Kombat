using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Schimb_de_scene : MonoBehaviour
{
    public void InapoiMeniu()
    {
        SceneManager.LoadScene("Meniu_Start");
    }

    public void RESET1()
    {
        SceneManager.LoadScene("fightScene");
    }

    public void RESET2()
    {
        SceneManager.LoadScene("fightScene 1");
    }
    public void GoToScene()
    {
        SceneManager.LoadScene("MeniuIntrareLupta");
    }
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
