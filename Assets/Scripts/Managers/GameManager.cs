using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region ========== �̱��� ==========
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    #endregion

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
