using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class NextScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void MoveNextScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}