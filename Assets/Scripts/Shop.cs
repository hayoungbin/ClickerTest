using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int Upgrade1;
    private int Upgrade2;
    private int Upgrade3;
    private int Upgrade4;

    private int Upgrade1Value;
    private int Upgrade2Value;
    private int Upgrade3Value;
    private int Upgrade4Value;

    [SerializeField] private GameObject AutoCliker1;
    [SerializeField] private GameObject AutoCliker2;

    [SerializeField] private TextMeshProUGUI UpgradeText1;
    [SerializeField] private TextMeshProUGUI UpgradeText2;
    [SerializeField] private TextMeshProUGUI UpgradeText3;
    [SerializeField] private TextMeshProUGUI UpgradeText4;

    private void Start()
    {
        if(Upgrade1 == 0)
        {
            Upgrade1 = 0;
        }
        if(Upgrade2 == 0)
        {
            Upgrade2 = 0;
        }
        if(Upgrade3 == 0)
        {
            Upgrade3 = 0;
        }
        if(Upgrade4 == 0)
        {
            Upgrade4 = 0;
        }
    }
    public void OnUpgradeIncom()
    {
        if (Upgrade1 < 60)
        {

        }
    }
    public void OnUpgradeAIncom()
    {
        if (Upgrade2 < 60)
        {

        }
    }
    public void OnUpgradeAddAuto()
    {
        if (Upgrade3 < 30)
        {
            Instantiate(AutoCliker1);
            Upgrade3 += 1;
            UpgradeText3.text = $"�ڵ� ���� 1\n�߰�\n({Upgrade3} / 30)";
        }
    }
    public void OnUpgradeAddAuto2()
    {
        if (Upgrade4 < 30)
        {
            Instantiate(AutoCliker2);
            Upgrade4 += 1;
            UpgradeText4.text = $"�ڵ� ���� 2\n�߰�\n({Upgrade4} / 30)";
        }
    }
}
