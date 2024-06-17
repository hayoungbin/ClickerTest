using UnityEngine;
using UnityEngine.SceneManagement;

public class Btns : MonoBehaviour
{
    private string start = "StartScene";
    private string main = "MainScene";
    public void StartBtn()
    {
        SceneManager.LoadScene(main);
    }
}
