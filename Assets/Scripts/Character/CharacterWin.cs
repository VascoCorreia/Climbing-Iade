using System;

using UnityEngine;

public class CharacterWin : MonoBehaviour
{
    [SerializeField] private GameObject _winTrigger;
    [SerializeField] private CharacterMovement _characterMovementScript;

    private bool _hasWon;

    public event Action playerWon;

    private void Start()
    {
        _hasWon = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.Equals(_winTrigger) && !_hasWon)
        {
            Win();
        }
    }

    void Win()
    {
        if(playerWon != null)
        {
            playerWon?.Invoke();
            _hasWon = true;
            _characterMovementScript.enabled = false;
        }
    }
}
