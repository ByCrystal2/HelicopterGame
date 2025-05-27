using System.Collections.Generic;
using UnityEngine;

public class PointHandler : MonoBehaviour
{
    [SerializeField] Transform _cargoPointsParent;
    [SerializeField] Transform _patrolPointsParent;

    List<Transform> _cargoPoints = new List<Transform>();
    List<Transform> _patrolPoints = new List<Transform>();

    public static PointHandler instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        InitPoints(_cargoPoints,_cargoPointsParent);
        InitPoints(_patrolPoints,_patrolPointsParent);
    }
    void InitPoints(List<Transform> points, Transform _pointsParent)
    {
        points.Clear();
        int length = _pointsParent.childCount;
        for (int i = 0; i < length; i++)
            points.Add(_pointsParent.GetChild(i));
    }
    public List<Transform> GetCargoPoints() => new List<Transform>(_cargoPoints);
    public List<Transform> GetPatrolPoints() => new List<Transform>(_patrolPoints);
}
