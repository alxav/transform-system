using System.Collections.Generic;
using UnityEngine;

public class Waypoint2 : MonoBehaviour
{
    [SerializeField] private Athlete prefabAthlete;

    [SerializeField] private DataWaypoint[] listWaypoint;

    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private int currentWayPoint;
    private List<Athlete> listAthlete = new List<Athlete>();

    private void Awake()
    {
        Athlete.Finish += Finish;
    }

    private void Finish(bool obj)
    {
        listAthlete[currentWayPoint].Stop();
        currentWayPoint = FindNextWaypoint();
        Move();
    }

    void Start()
    {
        currentWayPoint = 0;
        for (var i = 0; i < listWaypoint.Length; i++)
        {
            Create(listWaypoint[i], i);
        }

        Move();
    }

    private void Create(DataWaypoint data, int index)
    {
        var athlete = Instantiate(prefabAthlete, data.waypoint.position, Quaternion.identity);
        listAthlete.Add(athlete);
        var number = index + 1;
        athlete.GetComponent<VisibleAthlete>().Instantiate(data.color, number);
        athlete.Instantiate(speed, distance);
    }

    private void Move()
    {
        var target = FindNextAthlete();
        listAthlete[currentWayPoint].Run(target);
    }

    private Vector3 FindNextAthlete()
    {
        var nextWayPoint = FindNextWaypoint();
        return listAthlete[nextWayPoint].transform.position;
    }

    private int FindNextWaypoint()
    {
        var nextWayPoint = currentWayPoint + 1;

        if (nextWayPoint >= listAthlete.Count)
        {
            return 0;
        }

        return nextWayPoint;
    }
}
