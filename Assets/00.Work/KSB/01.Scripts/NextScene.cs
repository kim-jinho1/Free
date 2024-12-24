using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

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


