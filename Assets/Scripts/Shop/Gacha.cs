using UnityEngine;

// ��í �����۵鿡 �ʿ��� ����
public abstract class Gacha : MonoBehaviour
{
    // �������� ���� ���ϸ� Ŭ���� �Ұ��� �ϱ� ������ ���
    public abstract void InteractableButton(int _index);

    // ���׷��̵尡 �������� Ȯ��
    public abstract bool IsUpgradeValid();

    // (ex. Weapon�� Count ����, Slider, Upgrade�� �����ϸ� ��Ƽ�� �˷� ��)
    public abstract void UpdateUI();

    // �����۵��� Ȯ�� ��������
    public abstract float GetProbability(int _index);

    public abstract string GetIcon(int _index);

    // Item Count ���� (ex. Weapon Menu�� �� �ִ� Weapon���� Count�� ����)
    public abstract int ItemDictCountUp(int _index);

    public abstract int GetListLength();

    public abstract void ShowMenuNotify();
}
