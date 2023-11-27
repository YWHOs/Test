public interface IGacha
{
    // 아이템을 얻지 못하면 클릭이 불가능 하기 때문에 사용
    void InteractableButton(int _index);

    // 업그레이드가 가능한지 확인
    bool IsUpgradeValid();

    // (ex. Weapon의 Count 증가, Slider, Upgrade가 가능하면 노티로 알려 줌)
    void UpdateUI();

    public bool IsRarityItem(int _index);
    // 아이템들의 확률 가져오기
    int GetProbability(int _index);
    int GetAllProbability();
    void SetProbability(int _index, int _probability);

    string GetIcon(int _index);

    // Item Count 증가 (ex. Weapon Menu에 들어가 있는 Weapon들의 Count가 증가)
    int ItemDictCountUp(int _index);

    int GetListLength();

    void ShowMenuNotify();

}
