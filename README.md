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



---

## 필수 구현사항 5.게임 내 통화 시스템

---



---


작성중...
