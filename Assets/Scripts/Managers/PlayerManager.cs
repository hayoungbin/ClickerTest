using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region ========== ΩÃ±€≈Ê ==========
    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI incomText;
    [SerializeField] private TextMeshProUGUI autoIncomText;

    public float gold { get; private set; }
    private float incom;
    private float autoIncom;

    public event Action OnAutoIncom;

    private void Start()
    {
        if (gold == 0f)
        {
            gold = 0f;
        }
        else
        {
            gold = 0f;
        }

        if (incom == 0f)
        {
            incom = 1f;
        }
        else
        {
            incom = 1f;
        }

        if(autoIncom == 0f)
        {
            autoIncom = 0f;
        }
        else
        {
            autoIncom = 0f;
        }
        StartCoroutine(AutoIncom());
        UpdateIncom();
        UpdateAutoIncom();
    }

    public void UpdateGold()
    {
        goldText.text = gold.ToString();
    }
    public void UpdateIncom()
    {
        incomText.text = incom.ToString();
    }
    public void UpdateAutoIncom()
    {
        autoIncomText.text = autoIncom.ToString();
    }

    public void ClickToIncom()
    {
        gold += incom;
        UpdateGold();
    }


    public void AddIncom(float value)
    {
        incom += value;
        UpdateIncom();
    }
    public void AddAutoIncom(float value)
    {
        autoIncom += value;
        UpdateAutoIncom();
    }

    public void UesGold(float value)
    {
        gold -= value;
        UpdateGold();
    }

    public IEnumerator AutoIncom()
    {
        while (true)
        {            
            if (autoIncom >= 1f)
            {
                gold += autoIncom;
                UpdateGold();
            }
            yield return new WaitForSeconds(3);
        }
    }
    public IEnumerator AutoIncom2()
    {
        while (true)
        {
            if (autoIncom >= 1f)
            {
                gold += autoIncom * 2f;
                UpdateGold();
            }
            yield return new WaitForSeconds(3);
        }
    }
}
