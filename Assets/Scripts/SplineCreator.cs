using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineCreator : MonoBehaviour
{
    public Transform objectToRecord;
    public float pointSpacing = 0.5f;

    private List<Vector3> points = new();
    private float distanceSinceLastPoint = 0f;

    void Start()
    {            
        objectToRecord = transform;
        points.Add(objectToRecord.transform.position);
    }

    void Update()
    {
        distanceSinceLastPoint += Vector3.Distance(objectToRecord.transform.position, points[^1]);

        if (distanceSinceLastPoint >= pointSpacing)
        {
            points.Add(objectToRecord.transform.position);
            distanceSinceLastPoint = 0f;
            UpdateSpline();
            points.RemoveAt(0);
        }
    }

    void UpdateSpline()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
