using TMPro;
using UnityEngine;

public class finalHeight : MonoBehaviour
{
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager != null)
        {
            GetComponent<TMP_Text>().text = "Final Height: " + _gameManager._playerScore;
        }
    }
}
