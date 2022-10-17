using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeMover _cube;

    [SerializeField] private Transform _spawnPoint;

    private IEnumerator _coroutine;

    public void StartSpawnCubes(float speed, float distance, float interval)
    {
        if(_coroutine != null)  StopCoroutine(_coroutine);

        _coroutine = SpawnCubes(speed, distance, interval);
        StartCoroutine(_coroutine);
    }

    private IEnumerator SpawnCubes(float speed, float distance, float interval)
    {
        var endPoint = new Vector3(_spawnPoint.position.x, 
            _spawnPoint.position.y,
            _spawnPoint.position.z + distance);

        while (true)
        {
            var cube = Instantiate(_cube, _spawnPoint.position, Quaternion.identity);
            cube.StartMove(_spawnPoint.position, endPoint, speed);

            yield return new WaitForSeconds(interval);
        }
    }
}
