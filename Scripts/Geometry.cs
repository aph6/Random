using UnityEngine;

public class Geometry
{
    public static int cellSize = 10;
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = 5f + 10f * gridPoint.x;
        float z = 5f + 10f * gridPoint.y;
        return new Vector3(x, 0, z);
    }



    static public Vector3 GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(point.x / cellSize);
        int row = Mathf.FloorToInt(point.z / cellSize);
        return new Vector3(col * cellSize + 5, 0, row * cellSize + 5);
    }

    static public Vector3 BezierCurve(float t, params Vector3[] p)
    {
        Vector3 position = Mathf.Pow(1 - t, 2) * p[0] +
            2 * (1 - t) * t * p[1] + Mathf.Pow(t, 2) * p[2];

        return position;
    }

    static public Vector3 RoundVector(Vector3 vector)
    {
        return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
    }

    static public Quaternion RoundRotation(Quaternion rotation)
    {
        rotation.eulerAngles = new Vector3(Mathf.Round(rotation.eulerAngles.x), 
            Mathf.Round(rotation.eulerAngles.y), Mathf.Round(rotation.eulerAngles.z));
        return rotation;
    }
}
