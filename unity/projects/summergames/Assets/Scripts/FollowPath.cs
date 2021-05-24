using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public enum moveType{Usetransform, UsePhysics};
    public moveType moveTypes;

    public Transform[] pathPoints;
    public GameObject gfx;
    public int currentPath = 0;
    public float reachDistance = 5.0f;
    public float speed = 5.0f;

    private Rigidbody2D rgbd2D;
    private EnemySeagull EnSegull;

	void Start ()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        EnSegull = GetComponent<EnemySeagull>();
	}
	
	void  FixedUpdate ()
    {
		switch (moveTypes)
        {
            case moveType.Usetransform:
                UseTransform();
                break;

            case moveType.UsePhysics:
                UsePhysics();
                break;
            
        }
	}


    void UseTransform()
    {
     if (!EnSegull.playerClose)
        {
            Vector3 dir = pathPoints[currentPath].position - transform.position;
            Vector3 dirNorm = dir.normalized;

            transform.Translate(dirNorm * speed * Time.fixedDeltaTime);
            gfx.transform.up = pathPoints[currentPath].position - transform.position;

            if (dir.magnitude <= reachDistance)
            {
                currentPath++;
                if (currentPath >= pathPoints.Length)
                {
                    currentPath = 0;
                }
            }
        }
    }

    void UsePhysics()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;

        rgbd2D.velocity = new Vector2 (dirNorm.x * (speed), rgbd2D.velocity.y);

        if (dir.magnitude <= reachDistance)
        {
            currentPath++;
            if (currentPath >= pathPoints.Length)
            {
                currentPath = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (pathPoints == null)
            return;
        foreach (Transform pathPoint in pathPoints)
        {
            if (pathPoint)
            {
                Gizmos.DrawSphere(pathPoint.position, reachDistance);
            }
        }
    }
}
