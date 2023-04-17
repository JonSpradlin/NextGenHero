using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.TerrainTools;
using UnityEngine.UI;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyBehaviour : MonoBehaviour
{

    public float hits;
    private GameController mGameGameController;
    private waypointBehaviour mWaypointBehaviour;
    public float mov_speed = 20.0f;
    public float rot_speed = 11f / 1f;
    public bool random = false;
    public int currWaypoint;
    public GameObject waypointObj;
    public Rigidbody2D rb;
    public Text controlMode = null;

    // Start is called before the first frame update    
    void Start()
    {
        hits = 1;
        mGameGameController = FindObjectOfType<GameController>();
        Debug.Log(mGameGameController);
        currWaypoint = Random.Range(0, 6);
        rb = GetComponent<Rigidbody2D>();


        // Vector3 mWay = mGameGameController.waypoints[currWaypoint];

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    if (random)
        //    {
        //        random = false;
        //        mGameGameController.waypointOrdered.text = "Enemy Control Mode: Ordered";
        //    }
        //    else
        //    {
        //        random = true;
        //        mGameGameController.waypointOrdered.text = "Enemy Control Mode: Random";
        //    }
        //}
        
        if (currWaypoint == 0)
        {
            waypointObj = GameObject.Find("A_Walk(Clone)");
        }
        else if(currWaypoint == 1)
        {
            waypointObj = GameObject.Find("B_Walk(Clone)");
        }
        else if (currWaypoint == 2)
        {
            waypointObj = GameObject.Find("C_Walk(Clone)");
        }
        else if (currWaypoint == 3)
        {
            waypointObj = GameObject.Find("D_Walk(Clone)");
        }
        else if (currWaypoint == 4)
        {
            waypointObj = GameObject.Find("E_Walk(Clone)");
        }
        else if (currWaypoint == 5)
        {
            waypointObj = GameObject.Find("F_Walk(Clone)");
        }

        PointAtPosition(waypointObj.GetComponent<waypointBehaviour>().currPos, rot_speed * Time.smoothDeltaTime);

        if (Vector3.Distance(waypointObj.GetComponent<waypointBehaviour>().currPos, transform.position) < 20)
        {
           // Debug.Log(mGameGameController.enemyControlRand);
            
            if (mGameGameController.enemyControlRand)
            {
                currWaypoint = Random.Range(0, 6);
            }
            else
            {
                if(currWaypoint < 5)
                {
                    currWaypoint++;
                }
                else
                {
                    currWaypoint = 0;
                }
            }
        }




          rb.velocity = transform.up * mov_speed;

        
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }




    public void hit()
    {
        Debug.Log("Entering hits = " + hits);
        hits--;

        if (hits > 0)
        {
            Color temp = GetComponent<Renderer>().material.color;
            temp.a = temp.a * 0.8f;

            GetComponent<Renderer>().material.SetColor("_Color", temp);
            Debug.Log("reduced alpha hits = " + hits);
        }
        else
        {
            Debug.Log("Destroying enemy");

            mGameGameController.EnemyDestroyed();
            Destroy(gameObject);
            
        }
        Debug.Log("leaving Hit");

    }

  
}
