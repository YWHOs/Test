using UnityEngine;

// 가챠 아이템들에 필요한 정보
public abstract class Gacha : MonoBehaviour
{
    // 아이템을 얻지 못하면 클릭이 불가능 하기 때문에 사용
    public abstract void InteractableButton(int _index);

    // 업그레이드가 가능한지 확인
    public abstract bool IsUpgradeValid();

    // (ex. Weapon의 Count 증가, Slider, Upgrade가 가능하면 노티로 알려 줌)
    public abstract void UpdateUI();

    // 아이템들의 확률 가져오기
    public abstract float GetProbability(int _index);

    public abstract string GetIcon(int _index);

    // Item Count 증가 (ex. Weapon Menu에 들어가 있는 Weapon들의 Count가 증가)
    public abstract int ItemDictCountUp(int _index);

    public abstract int GetListLength();

    public abstract void ShowMenuNotify();
}
