using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image blackFadeImage;
    private int levelToLoad;

    private void Awake()
    {;
        DontDestroyOnLoad(gameObject);
    }

    public void fadeOutToLevel(int index)
    {
        blackFadeImage.enabled = true;
        levelToLoad = index;
        _animator.SetTrigger("FadeOut");
    }

    //called after fadeout animation is completed, using an animation event in Unity
    public void fadeInToLevel()
    {
        SceneManager.LoadScene(levelToLoad);
        _animator.SetTrigger("FadeIn");
    }

    public void onFadeInComplete()
    {
       blackFadeImage.enabled = false;
    }

    public void onFadeInStart()
    {
        blackFadeImage.enabled = true;
    }
}
