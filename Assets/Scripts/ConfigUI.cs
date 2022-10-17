using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]

public class ConfigUI : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    [SerializeField] private InputField _speed;
    [SerializeField] private InputField _distance;
    [SerializeField] private InputField _interval;

    public void StartSpawn()
    {
        float speed = ParseStringToFloat(_speed.text);
        float distance = ParseStringToFloat(_distance.text);
        float interval = ParseStringToFloat(_interval.text);

        _cubeSpawner.StartSpawnCubes(speed, distance, interval);
    }

    private float ParseStringToFloat(string number)
    {
        number = number.Replace('.', ',');

        return float.Parse(number);
    }
}
