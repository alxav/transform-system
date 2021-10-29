using System;
using UnityEngine;

[RequireComponent(typeof(VisibleAthlete))]
public class Athlete : MonoBehaviour
{
    public static event Action<bool> Finish;
    
    private Transform _transform;
    private bool isRun;
    private Vector3 target;
    private float speed;
    private float distance;
    
    private void Awake()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        if (!isRun) return;

        _transform.position = Vector3.MoveTowards(_transform.position, target, Time.deltaTime * speed);

        if (Vector3.Distance(_transform.position, target) <= distance)
        {
            Finish?.Invoke(true);
        }

    }

    public void Instantiate(float speed, float distance)
    {
        this.speed = speed;
        this.distance = distance;
    }

    public void Run(Vector3 target)
    {
        this.target = target;
        _transform.LookAt(target);
        isRun = true;
    }

    public void Stop() => isRun = false;


    private void OnDestroy()
    {
        Finish = null;
    }
}
