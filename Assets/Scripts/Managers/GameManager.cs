using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterWin _characterWinScript;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelManager _sceneManager;
    [SerializeField] public int _playerScore;

    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Destroy(this);
        }

        _characterWinScript.playerWon += Win;
    }
    private void Start()
    {
        _playerScore = 0;
    }

    private void Update()
    {
        _playerScore = Mathf.FloorToInt(_player.transform.position.y);
    }

    void Win()
    {
        _sceneManager.fadeOutToLevel(2);
    }
}
