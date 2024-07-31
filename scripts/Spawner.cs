using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Target[] _targets;
    [SerializeField] private float _repeatRate = 2f;

    private SpawnPoint _spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(_repeatRate));
    }

    private void Spawn()
    {
        Enemy enemy;

        _spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        _spawnPoint.TakeTarget(_targets[Random.Range(0, _targets.Length)]);
        enemy = Instantiate(_spawnPoint.GetEnemyPrefab(), _spawnPoint.transform.position, Quaternion.identity);
        enemy.gameObject.SetActive(true);
        enemy.StartMoving(_spawnPoint.GetTargetToMove());
    }

    private IEnumerator SpawnEnemy(float seconds)
    {
        var wait = new WaitForSeconds(seconds);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }
}
