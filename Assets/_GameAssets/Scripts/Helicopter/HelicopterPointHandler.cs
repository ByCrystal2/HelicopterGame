using System.Collections.Generic;
using UnityEngine;

public class HelicopterPointHandler : MonoBehaviour
{
    [SerializeField] List<Transform> _visitPoints = new List<Transform>();

    public Transform GetRandomVisitPoint()
    {
        return _visitPoints[Random.Range(0, _visitPoints.Count)];
    }
    public void AddVisitPoints(List<Transform> _points)
    {
        foreach (var point in _points)
            _visitPoints.Add(point);
    }
}
