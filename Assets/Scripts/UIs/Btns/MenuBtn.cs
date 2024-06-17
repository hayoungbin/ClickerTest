using UnityEngine;

public class MenuBtn : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject menuUI;

    private GameObject menu = null;

    public void OnMenuBtn()
    {
        if (menu == null)
        {
            menu = Instantiate(menuUI, canvas.transform);
        }
        else if (menu != null)
        {
            Destroy(menu);
        }
    }
}
