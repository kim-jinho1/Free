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
            MoveNextScene(); // �� �̸����� ��ȯ
        }
    }

    public void MoveNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}


