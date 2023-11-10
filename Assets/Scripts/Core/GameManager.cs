using UnityEngine;

public enum EGameState
{
    Idle,
    Dungeon,
    Rest,

    MAX
}
public class GameManager : MonoBehaviour
{
    EGameState gameState;
    public EGameState GameState => gameState;

    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = null;
            }
            return instance;
        }
    }
    void Awake()
    {
        Application.runInBackground = true;
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameState = EGameState.Idle;
    }
    public void ChangeGameState(EGameState _state)
    {
        switch(_state)
        {
            case EGameState.Idle:
                gameState = EGameState.Idle;
                break;
            case EGameState.Dungeon:
                gameState = EGameState.Dungeon;
                break;
            case EGameState.Rest:
                gameState = EGameState.Rest;
                break;
        }
    }
}
