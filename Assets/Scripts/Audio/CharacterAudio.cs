using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAudio : MonoBehaviour
{

    [SerializeField] private AudioClip _slipping, _death, _falling;
    [SerializeField] private AudioClip[] _climbing;
    [SerializeField] private CharacterDeath _deathScript;
    [SerializeField] private CharacterMovement _movementScript;
    private void OnEnable()
    {
        _deathScript.deathEvent += Death;
        _movementScript.isSlidingEvent += Slipping;
    }

    private void Start()
    {
        InvokeRepeating("Climbing", 0, 0.5f);
    }
    void Update()
    {

    }

    void slidingDown()
    {
        if(_movementScript._isSliding)
        {

        }
        //sliding down
        //if (xAxis == 0 && yAxis == 0 && !hasPlayed)
        //{
        //   // AudioManager.instance.playLoopingEffect(_slidingDown);
        //    hasPlayed = true;
        //}

    }

    void Death()
    {
        AudioManager.instance.playEffect(_death);
        AudioManager.instance.playEffect(_falling);
    }

    void Slipping()
    {
        AudioManager.instance.playLoopingEffect(_slipping);
    }

    void Climbing()
    {
        if(!_movementScript._isSliding)
        {
            AudioManager.instance.playEffect(_climbing[Random.Range(0, _climbing.Length)]);
        }
    }
}
