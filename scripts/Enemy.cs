using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
            Destroy(gameObject);
    }

    public void StartMoving(Target target)
    {
        StartCoroutine(Move(target));
    }

    private IEnumerator Move(Target target)
    {
        var wait = new WaitForEndOfFrame();

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
            yield return wait;
        }
    }
}  
