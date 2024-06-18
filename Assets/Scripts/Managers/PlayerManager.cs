using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI incomText;
    [SerializeField] private TextMeshProUGUI autoIncomText;

    public float gold { get; private set; }
    private float incom = 1;
    private float autoIncom;

    private void Start()
    {
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
