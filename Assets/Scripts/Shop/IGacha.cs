public interface IGacha
{
    // �������� ���� ���ϸ� Ŭ���� �Ұ��� �ϱ� ������ ���
    void InteractableButton(int _index);

    // ���׷��̵尡 �������� Ȯ��
    bool IsUpgradeValid();

    // (ex. Weapon�� Count ����, Slider, Upgrade�� �����ϸ� ��Ƽ�� �˷� ��)
    void UpdateUI();

    public bool IsRarityItem(int _index);
    // �����۵��� Ȯ�� ��������
    int GetProbability(int _index);
    int GetAllProbability();
    void SetProbability(int _index, int _probability);

    string GetIcon(int _index);

    // Item Count ���� (ex. Weapon Menu�� �� �ִ� Weapon���� Count�� ����)
    int ItemDictCountUp(int _index);

    int GetListLength();

    void ShowMenuNotify();

}
