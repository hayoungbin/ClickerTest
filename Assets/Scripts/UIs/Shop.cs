using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int upgrade1;
    private int upgrade2;
    private int upgrade3;
    private int upgrade4;

    private int upgrade1Value;
    private int upgrade2Value;
    private int upgrade3Value;
    private int upgrade4Value;

    [SerializeField] private GameObject AutoCliker1;
    [SerializeField] private GameObject AutoCliker2;

    [SerializeField] private TextMeshProUGUI UpgradeText1;
    [SerializeField] private TextMeshProUGUI UpgradeText2;
    [SerializeField] private TextMeshProUGUI UpgradeText3;
    [SerializeField] private TextMeshProUGUI UpgradeText4;

    private void Start()
    {
        UpdateIncomText1();
        UpdateIncomText2();
        UpdateIncomText3();
        UpdateIncomText4();
    }
    private void UpdateIncomText1()
    {
        if (upgrade1 < 60)
        {
            upgrade1Value = (upgrade1 + 1) * (upgrade1 + 1) * 10;
            UpgradeText1.text = $"수입 강화\n({upgrade1} / 60)\n{upgrade1Value} G";
        }
        else if (upgrade1 == 60)
        {
            UpgradeText1.text = $"수입 강화\n({upgrade1} / 60)\nMax!!!";
        }
    }
    private void UpdateIncomText2()
    {
        if (upgrade2 < 60)
        {
            upgrade2Value = (upgrade2 + 1) * (upgrade2 + 3) * 55;
            UpgradeText2.text = $"자동 수입 강화\n({upgrade2} / 60)\n{upgrade2Value} G";
        }
        else if(upgrade2 == 60)
        {
            UpgradeText2.text = $"자동 수입 강화\n({upgrade2} / 60)\nMax!!!";
        }
    }
    private void UpdateIncomText3()
    {
        if (upgrade3 < 20)
        {
            upgrade3Value = (upgrade3 + 1) * (upgrade3 + 2) * 25;
            UpgradeText3.text = $"자동 수입 1\n추가\n({upgrade3} / 20)\n{upgrade3Value} G";
        }
        else if (upgrade3 == 20)
        {
            UpgradeText3.text = $"자동 수입 1\n추가\n({upgrade3} / 20)\nMax!!!";
        }
    }
    private void UpdateIncomText4()
    {
        if (upgrade4 < 20)
        {
            upgrade4Value = (upgrade4 + 1) * (upgrade4 + 3) * 25;
            UpgradeText4.text = $"자동 수입 2\n추가\n({upgrade4} / 20)\n{upgrade4Value} G";
        }
        else if (upgrade4 == 20)
        {
            UpgradeText4.text = $"자동 수입 2\n추가\n({upgrade4} / 20)\nMax!!!";
        }
    }
    public void OnUpgradeIncom()
    {
        if (upgrade1 < 60)
        {
            if (PlayerManager.Instance.gold >= upgrade1Value)
            {
                PlayerManager.Instance.UesGold(upgrade1Value);
                upgrade1 += 1;
                PlayerManager.Instance.AddIncom(upgrade1 * 2);
                UpdateIncomText1();
            }
            else
            {
                StartCoroutine(GameManager.Instance.OnSystemMassage("자금이 부족합니다!!!"));
            }
        }
        else
        {
            StartCoroutine(GameManager.Instance.OnSystemMassage("이미 업그레이드가 완료되었습니다!"));
        }
    }
    public void OnUpgradeAIncom()
    {
        if (upgrade2 < 60)
        {
            if (PlayerManager.Instance.gold >= upgrade2Value)
            {
                PlayerManager.Instance.UesGold(upgrade2Value);
                upgrade2 += 1;
                PlayerManager.Instance.AddAutoIncom(upgrade2 * 3);
                UpdateIncomText2();
            }
            else
            {
                StartCoroutine(GameManager.Instance.OnSystemMassage("자금이 부족합니다!!!"));
            }
        }
        else
        {
            StartCoroutine(GameManager.Instance.OnSystemMassage("이미 업그레이드가 완료되었습니다!"));
        }
    }
    public void OnUpgradeAddAuto()
    {
        if (upgrade3 < 20)
        {
            if (PlayerManager.Instance.gold >= upgrade3Value)
            {
                PlayerManager.Instance.UesGold(upgrade3Value);
                upgrade3 += 1;
                Instantiate(AutoCliker1);
                UpdateIncomText3();
            }
            else
            {
                StartCoroutine(GameManager.Instance.OnSystemMassage("자금이 부족합니다!!!"));
            }
        }
        else
        {
            StartCoroutine(GameManager.Instance.OnSystemMassage("이미 업그레이드가 완료되었습니다!"));
        }
    }
    public void OnUpgradeAddAuto2()
    {
        if (upgrade4 < 20)
        {
            if (PlayerManager.Instance.gold >= upgrade4Value)
            {
                PlayerManager.Instance.UesGold(upgrade4Value);
                upgrade4 += 1;
                Instantiate(AutoCliker2);
                UpdateIncomText4();
            }
            else
            {
                StartCoroutine(GameManager.Instance.OnSystemMassage("자금이 부족합니다!!!"));
            }
        }
        else
        {
            StartCoroutine(GameManager.Instance.OnSystemMassage("이미 업그레이드가 완료되었습니다!"));
        }
    }
}
