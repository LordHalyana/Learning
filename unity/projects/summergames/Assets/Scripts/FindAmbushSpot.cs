using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAmbushSpot : MonoBehaviour {

    public bool hasPickedLocation;
    public bool isChasingPlayer;

    private EnemyBug EnmBug;
    private GameObject positionToAmbush;

    void Start ()
    {
        EnmBug = FindObjectOfType<EnemyBug>();

        hasPickedLocation = false;

    }
	
	void Update ()
    {
        GetClosestAmbush();


    }

    private void GetClosestAmbush()
    {

        GameObject[] ambushL = GameObject.FindGameObjectsWithTag("AmbushLocation");

        if (!isChasingPlayer && !hasPickedLocation)
        {
            int ambushSpot = Random.Range(0, ambushL.Length);
            positionToAmbush = ambushL[ambushSpot];
            hasPickedLocation = true;
        }


        if (!EnmBug.playerClose)
        {
            EnmBug.transform.up = positionToAmbush.transform.position - transform.position;
            EnmBug.transform.position += transform.up * EnmBug.baseMoveSpeed * Time.deltaTime;
        }

        if (isChasingPlayer)
        {
            hasPickedLocation = false;
        }
    }
}
