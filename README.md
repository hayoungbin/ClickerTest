# 게임개발 심화 개인과제 2D클리커 게임
---

저는 이번 최종 프로젝트 팀에서 2D게임을 만들기로 했기에

개인과제에서도 2D게임인 클리커 게임을 만들어 보기로 했습니다.

아래는 제가 구현한 구현사항들입니다.

---

## 필수 구현사항 1.클릭 이벤트 처리

---

클릭에 대한 처리는 간단하게 투명한 버튼을 만들어서 왼쪽의 빈 공간을 클릭하면 함수가 호출되도록 만들었습니다.

```cs
<C#>
using UnityEngine;

public class Click : MonoBehaviour
{
    public void OnClick()
    {
        PlayerManager.Instance.ClickToIncom();
    }
}
```

---

## 필수 구현사항 2.자동 클릭 기능

---

자동으로 수입이 발생하는 기능에 대해서는 아래와 같은 코루틴을 PlayerMAnager.cs의 Start에서 실행되게 만들었습니다.

```cs
<C#>
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
```

---

## 필수 구현사항 3.점수 시스템

---

이 게임에서는 딱히 점수같은 것은 없고

클릭을 하거나 자동수입을 구입했을 때 발생하는 수입으로 업그레이드를 할 수 있도록 만들어두었습니다.

이런수치들은 화면 우측의 UI에 표시됩니다.

![image](https://github.com/hayoungbin/ClickerTest/assets/167050593/4c9f95cd-1522-413e-bdd9-363c816f26ae)


---

## 필수 구현사항 4.아이템 및 업그레이드 시스템

---

이 게임의 업그레이드에는 크게 두 종류가 있는데, 업그레이드 목록 상단의 두개는 단순히 수입을 늘려주는 업그레이드입니다.

그리고 하단의 두개의 경우 자동수입을 늘려주는 오브젝트를 생성하며, Instantiate로 아래와 같은 기능을 가진 오브젝트를 만들어냅니다.

```cs
<C#>
using UnityEngine;

public class Clickers : MonoBehaviour
{
    protected float positionx;
    protected float positiony;

    protected virtual void Start()
    {
        positionx = Random.Range(-0.85f, -7.6f);
        positiony = Random.Range(-3.7f, 3.8f);
        gameObject.transform.position = new Vector3 (positionx, positiony, 0);
    }
}
```
```cs
<C#>
public class Clicker1 : Clickers
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(PlayerManager.Instance.AutoIncom());
    }
}
```

이런 식으로 생성된 오브젝트는 수입을 위해 클릭하는 공간에 생성되며 최대 20개씩 총합 40개를 생성할 수 있습니다.

![image](https://github.com/hayoungbin/ClickerTest/assets/167050593/ba9c5963-9c11-4aa7-963d-706efcff3a16)


---

## 필수 구현사항 5.게임 내 통화 시스템

---

이 게임에서는 클릭이나 자동 수입으로 벌어들인 재화를 소모하여 업그레이드를 할 수 있습니다.

플레이어의 골드는 플레이어의 정보를 저장하는 PlayerManager.cs의 gold 변수를 사용하는데

이러한 플레이어의 정보들을 PlayerManager.cs 내에서만 변경이 가능하도록 만들어 보고 싶었습니다.

그러한 이유로 아래와 같은 방법으로 이 변수를 해당 매니저에서만 변경할 수 있도록 해보았습니다.

```cs
<C#>
public float gold { get; private set; }
```

우선 위와 같이 gold를 public으로 열어두되 private set을 걺으로서

다른 클래스에서는 참조만 가능하게 하고 위 변수를 수정하기 위해서는 PlayerManager.cs 내의 아래와 같은 함수를 호출해서 사용하도록 하였습니다.

```cs
<C#>
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
```

이것은 플레이어의 수입에 대한 변수에도 적용되지만, 해당 변수들은 아직 참조를 해야 할 일은 없기에 단순히 private을 걸어놓기만 하였습니다.

결과적으로 위와 같은 함수들을 이용하여 아래와 같이 업그레이드가 진행됩니다.

```cs
<C#>
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
```

---

## 그 외 구현해본 사항. 시스템 메세지

---

업그레이드에 필요한 자금이 부족하거나 업그레이드를 모두 완료했는데 더 하려고 시도하는 경우 시스템메세지가 나오게 하고싶었습니다.

그래서 GameManager.cs에서 시스템메세지에 관한 기능을 수행하도록 만들었습니다. 

```cs
<C#>
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
```

시스템 메세지는 SystemUI라는 빈 오브젝트에 생성이 되는데,

SystemUI는 Vertical Layout Group 컴포넌트를 가지고 있기 때문에 생성된 시스템 메세지는 자동으로 세로로 쌓이며 생성됩니다.

![image](https://github.com/hayoungbin/ClickerTest/assets/167050593/ac5dcb9f-7e37-41c5-bdf8-3c640725612f)

---
이상입니다.
