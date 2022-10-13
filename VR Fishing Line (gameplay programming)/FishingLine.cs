using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    private class LineParticle
    {
        public Vector3 Pos;
        public Vector3 OldPos;
        public Vector3 Acceleration;

        public LineParticle(Vector3 vec)
        {
            Pos = vec;
            OldPos = vec;
            Acceleration = Physics.gravity;
        }
    }

    [SerializeField]
    List<LineParticle> points;
    [SerializeField]
    GameObject bobber;

    public int iterations = 5;
    public float length = 5f;

    LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        points = new List<LineParticle>();

        for (int i = 0; i < iterations; i++)
            points.Add(new LineParticle(this.transform.position + new Vector3(0, i, 0)));

        lineRenderer.positionCount = iterations;
    }

    void Update()
    {
        for (int i = 0; i < iterations; i++)
        {
            lineRenderer.SetPosition(i, points[i].Pos);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 1; i < iterations; i++)
        {
            Verlet(points[i], Time.deltaTime);
        }

        for (int i = 0; i < iterations - 1; i++)
        {
            for (int j = 0; i < 6; i++)
            {
                PoleConstraint(points[i], points[i + 1], iterations / length);
            }
        }
    }


    private void Verlet(LineParticle p, float dt)
    {
        var temp = p.Pos;
        p.Pos += p.Pos - p.OldPos + (p.Acceleration * dt * dt);
        p.OldPos = temp;
    }

    private void PoleConstraint(LineParticle p1, LineParticle p2, float restLength)
    {
        var delta = p2.Pos - p1.Pos;

        var deltaLength = delta.magnitude;

        var diff = (deltaLength - restLength) / deltaLength;

        p1.Pos += delta * diff * 0.5f;
        p2.Pos -= delta * diff * 0.5f;
    }
}

