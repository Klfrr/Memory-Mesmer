using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VisSpaceToken : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D lineCollider;
    SpriteRenderer circle;
    public int value;

    List<Vector2> points;

    void Start()
    {
        lineCollider.transform.position -= transform.position;
    }

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

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        lineCollider.points = points.ToArray();
    }

    public void resetLine()
    {
        lineRenderer.positionCount = 0;
        lineCollider.points = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collission");
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        print("collission");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("colliding");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        print("colliding");
    }
}
