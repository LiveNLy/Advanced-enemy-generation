using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private Target _target;

    public void TakeTarget(Target target)
    {
        _target = target;
    }

    public Enemy GetEnemyPrefab()
    {
        return _enemyPrefab;
    }

    public Target GetTargetToMove()
    {
        return _target;
    }
}
