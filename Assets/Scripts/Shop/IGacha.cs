public interface IGacha
{
    // �������� ���� ���ϸ� Ŭ���� �Ұ��� �ϱ� ������ ���
    void InteractableButton(int _index);

    // ���׷��̵尡 �������� Ȯ��
    bool IsUpgradeValid();

    // (ex. Weapon�� Count ����, Slider, Upgrade�� �����ϸ� ��Ƽ�� �˷� ��)
    void UpdateUI();

    // �����۵��� Ȯ�� ��������
    float GetProbability(int _index);

    string GetIcon(int _index);

    // Item Count ���� (ex. Weapon Menu�� �� �ִ� Weapon���� Count�� ����)
    int ItemDictCountUp(int _index);

    int GetListLength();

    void ShowMenuNotify();
}
