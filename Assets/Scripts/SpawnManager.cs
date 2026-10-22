using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform[] _spawnPoints;
    private float _spawnTimer = 5f;
    [SerializeField] private GameObject _enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var spawners = GameObject.Find("Spawners").GetComponentsInChildren<Transform>().ToList<Transform>();
        foreach (var spawnPoint in spawners)
        {
            print(spawnPoint.name);
        }
        spawners.RemoveAt(0);
        _spawnPoints = spawners.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnTimer < 0){
            int enemiesCount = 1;//Random.Range(1, 6);
            Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0,12)].transform.position, Quaternion.identity);
            _spawnTimer = Random.Range(1f, 4f);
        }
        _spawnTimer -= Time.deltaTime;
    }
}
