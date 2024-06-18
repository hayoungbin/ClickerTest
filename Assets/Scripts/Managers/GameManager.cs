using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private TextMeshProUGUI systemMassage;
    [SerializeField] private GameObject systemMassageUI;
    [SerializeField] private GameObject systemUI;

    private void Start()
    {
        if (systemUI == null)
        {
            systemUI = GameObject.Find("SystemUI");
        }

        systemMassage = systemMassageUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    public IEnumerator OnSystemMassage(string massage)
    {
        systemMassage.text = massage;
        GameObject go = Instantiate(systemMassageUI, systemUI.transform);
        yield return new WaitForSeconds(2);
        Destroy(go);
        systemMassage.text = null;
    }
}
