using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointBehaviour : MonoBehaviour
{
    private GameController mGameGameController;
    public Vector3 currPos;
    public int hits = 4;


    // Start is called before the first frame update
    void Start()
    {
        mGameGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //hide waypoint
        if (mGameGameController.hideWaypoints)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            this.GetComponent<Renderer>().enabled = true;
        }

        //if waypoint moved planes need to update
        currPos = transform.position;
    }

    public void hit()
    {
        Debug.Log("Entering hits = " + hits);
        hits--;

        if (hits > 0)
        {
            Color temp = GetComponent<Renderer>().material.color;
            temp.a = temp.a - 0.25f;

            GetComponent<Renderer>().material.SetColor("_Color", temp);
            Debug.Log("reduced alpha hits = " + hits);
        }
        else
        {
            Debug.Log("Destroying enemy");

            mGameGameController.WaypointDestroyed();
            Destroy(gameObject);

        }
        Debug.Log("leaving Hit");

    }












}

