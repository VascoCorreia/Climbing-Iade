using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        DontDestroyOnLoad(gameObject);
    }

    //called through retry button click event in inspector
    public void Retry()
    {
        _levelManager.fadeOutToLevel(0);
    }

    //called through quit button click event in inspector
    public void Quit()
    {
        Application.Quit();
    }
}
