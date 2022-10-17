using System.Collections;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _speed;
    private float _startPosition;

    public void StartMove(Vector3 start, Vector3 end, float speed)
    {
        var distance = Vector3.Distance(start, end);
        var time = distance / speed;

        StartCoroutine(Move(start, end, time));
    }

    private IEnumerator Move(Vector3 start, Vector3 end, float time)
    {
        var currentTime = 0f;
        var progress = currentTime / time;

        while (progress < 1f)
        {
            currentTime += Time.deltaTime;

            transform.position = Vector3.Lerp(start, end, progress);

            progress = currentTime / time;

            yield return null;
        }

        Destroy(gameObject);
    }
}
