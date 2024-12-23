using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public int StartMenuSceneNum;
    public void Go_StartMenu()
    {
        SceneManager.LoadScene(StartMenuSceneNum);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Go_StartMenu();
        }
    }
}
