using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class NextScene : MonoBehaviour
{
    

    [SerializeField] private SceneAsset scene; 
    [SerializeField] private string sceneName;

    void Start()
    {

        if (scene != null)
        {
            sceneName = scene.name;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MoveNextScene(); // 씬 이름으로 전환
        }
    }

    public void MoveNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}


