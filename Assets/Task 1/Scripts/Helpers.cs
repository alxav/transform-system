using UnityEngine;

public class Helpers
{
    public Vector3 GetPosition(Vector3 range)
    {
        var x = Random.Range(0, Mathf.Abs(range.x));
        var y = Random.Range(0, Mathf.Abs(range.y));
        var z = Random.Range(0, Mathf.Abs(range.z));

        return new Vector3(x, y, z);
    }


}
