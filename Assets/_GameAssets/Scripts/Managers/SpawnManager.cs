using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _cargoHelicopter;
    [SerializeField] GameObject _patrolHelicopter;

    [SerializeField] Transform _helicopterSpawnPoint;

    private void Start()
    {
        SpawnCargoHelicopter();
    }
    void SpawnCargoHelicopter()
    {
        GameObject cargoHelicopter = Instantiate(_cargoHelicopter, _helicopterSpawnPoint.position, Quaternion.identity);
        cargoHelicopter.GetComponent<HelicopterPointHandler>().AddVisitPoints(PointHandler.instance.GetCargoPoints());
    }
}
