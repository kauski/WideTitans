using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: Henri Hienonen (last edited 1.4.22)


[RequireComponent(typeof(LineRenderer))]

public class ArrowTrajectory : MonoBehaviour
{
    public LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
