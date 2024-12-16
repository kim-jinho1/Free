using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public int StartMenuSceneNum;
    public void Go_StartMenu()
    {
        Debug.Log("End");
        SceneManager.LoadScene(StartMenuSceneNum);
    }
}
