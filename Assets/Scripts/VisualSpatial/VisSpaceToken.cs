using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VisSpaceToken : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D lineCollider;
    public int value;

    List<Vector2> points;

    public void updateLine(Vector2 position)
    {
        if( points == null)
        {
            points = new List<Vector2>();
            setPoint(position);
        }

        if(Vector2.Distance(points.Last(), position) > .1f)
        {
            setPoint(position);
        }
    }

    public void setPoint(Vector2 point)
    {
        points.Add(point);
        lineCollider.points = points.ToArray();

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }

    public void resetLine()
    {
        lineRenderer.positionCount = 0;
    }
}
