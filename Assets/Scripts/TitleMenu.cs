using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;





    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Credits()
    {

    }


    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }






}
