using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneBtns : MonoBehaviour
{
    private string start = "StartScene";
    private string main = "MainScene";

    public void OnStartBtn()
    {
        SceneManager.LoadScene(main);
    }

    public void OnReStartBtn()
    {
        SceneManager.LoadScene(start);
    }
}
