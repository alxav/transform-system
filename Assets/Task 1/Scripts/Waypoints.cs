using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private Vector3 range;
    [SerializeField] private int speed;

    private Helpers helpers;
    private EnumMove move;
    private int currentIndex;
    private Transform _transform;

    private List<Vector3> listPosition = new List<Vector3>();

    private void Awake()
    {
        _transform = transform;
        helpers = new Helpers();
        currentIndex = 0;      
        move = EnumMove.Forward;
    }

    private void Start()
    {
 
        GeneratePosition();

        if (listPosition.Count <= 1)
        {
            Debug.LogWarning("There must be more than 1 waypoints!");
        }
     
        transform.position = listPosition[currentIndex];

        StartCoroutine(StartMove());
    }

    private void GeneratePosition()
    {
        for (int i = 0; i < count; i++)
        {
            var waypoint = helpers.GetPosition(range);
            listPosition.Add(waypoint);
        }
    }

    private IEnumerator StartMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
            Move();
        }
        
    }

    private void Move()
    {
        int nextIndex = move == EnumMove.Forward ? currentIndex + 1 : currentIndex - 1;

        if (nextIndex >= listPosition.Count)
        {
            move = EnumMove.Back;
            return;
        }

        if (nextIndex < 0)
        {
            move = EnumMove.Forward;
            return;
        }

        Vector3 nextPoint = listPosition[nextIndex];
        
        _transform.position = Vector3.MoveTowards(_transform.position, nextPoint, Time.deltaTime * speed);

        if (Vector3.Distance(_transform.position, nextPoint) == 0)
        {
            currentIndex = nextIndex;
        }

    }
    
}
