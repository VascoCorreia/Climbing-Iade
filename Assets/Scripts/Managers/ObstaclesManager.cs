using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{

    //There are 2 obstacles pigeons + falling obstacles
    //these need to be spawned randomly in random intervals
    //falling obstacles just go down

    [SerializeField] private GameObject[] _fallingObstacles;
    [SerializeField] private GameObject _pigeon;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _finalHeight;
    [SerializeField] private float _fallingObstaclesSpawnRateMax;
    [SerializeField] private float _fallingObstaclesSpawnRateMin;
    [SerializeField] private float _fallingObstaclesSpawnRate;
    [SerializeField] private float _pigeonSpawnRateMax;
    [SerializeField] private float _pigeonSpawnRateMin;
    [SerializeField] private float _pigeonSpawnRate;



    void Start()
    {
        Invoke("spawnRandomObject", 3f);
        Invoke("spawnPigeon", 5f);
    }
    void Update()
    {
        float percentageComplete = _player.transform.position.y / _finalHeight;

        _fallingObstaclesSpawnRate = Mathf.Lerp(_fallingObstaclesSpawnRateMax, _fallingObstaclesSpawnRateMin, percentageComplete);
        _pigeonSpawnRate = Mathf.Lerp(_pigeonSpawnRateMax, _pigeonSpawnRateMin, percentageComplete);

        Debug.Log(_fallingObstaclesSpawnRate);
    }

    void spawnRandomObject()
    {
        Instantiate(_fallingObstacles[Random.Range(0, _fallingObstacles.Length)]);

        Invoke("spawnRandomObject", _fallingObstaclesSpawnRate);
    }

    void spawnPigeon()
    {
        Instantiate(_pigeon);

        Invoke("spawnPigeon", _pigeonSpawnRate);
    }
}