using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool mouseControl = true;
    public bool hideWaypoints = false;
    public bool enemyControlRand = false;
    public int maxPlanes = 10;
    public int planesDestroyed = 0;
    public int totalEggs = 0;
    public int numberOfPlanes = 0;
    public int waypointsDestroyed = 0;

    public Vector3[] waypoints = new Vector3[6];
    private waypointBehaviour obj;

    public Text planesDestroyedtxt = null;
    public Text totalEggstxt = null;
    public Text totalPlanestxt = null;
    public Text waypointOrdered = null;
    public Text planesTouched = null;
    public Text hideWaypointstxt = null;
    public Text waypointsDestroyedtxt = null;



    // Start is called before the first frame update
    void Start()
    {
       // Vector3 val = getPositionVariation(new Vector3(0, 0, 0));
        GameObject e;
        
        e = Instantiate(Resources.Load("Prefabs/A_Walk") as GameObject);
        e.transform.localPosition = waypoints[0];
        e.GetComponent<waypointBehaviour>().currPos = waypoints[0];
        
        e = Instantiate(Resources.Load("Prefabs/B_Walk") as GameObject);
        e.transform.localPosition = waypoints[1];
        e.GetComponent<waypointBehaviour>().currPos = waypoints[1];

        e = Instantiate(Resources.Load("Prefabs/C_Walk") as GameObject);
        e.transform.localPosition = waypoints[2];
        e.GetComponent<waypointBehaviour>().currPos = waypoints[2];

        e = Instantiate(Resources.Load("Prefabs/D_Walk") as GameObject);
        e.transform.localPosition = waypoints[3];
        e.GetComponent<waypointBehaviour>().currPos = waypoints[3];

        e = Instantiate(Resources.Load("Prefabs/E_Walk") as GameObject);
        e.transform.localPosition = waypoints[4];
        e.GetComponent<waypointBehaviour>().currPos = waypoints[4];

        e = Instantiate(Resources.Load("Prefabs/F_Walk") as GameObject);
        e.transform.localPosition = waypoints[5];
        e.GetComponent<waypointBehaviour>().currPos = waypoints[5];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J pressed");
            if (enemyControlRand)
            {
                enemyControlRand = false;
                Debug.Log("Control Random: " + enemyControlRand);
                waypointOrdered.text = "Enemy Control Mode: Ordered";
                Debug.Log("Bug Bug");
            }
            else
            {
                enemyControlRand = true;
                Debug.Log("Control Random: " + enemyControlRand);
                waypointOrdered.text = "Enemy Control Mode: Random";
                Debug.Log("Bug Bug");
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Waypoints Hidden?: " + hideWaypoints);
            if (hideWaypoints)
            {
                hideWaypoints = false;
            }
            else
            {
                hideWaypoints = true;
            }
        }


        if (numberOfPlanes < maxPlanes)
        {
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            Assert.IsTrue(s != null);

            GameObject e = Instantiate(Resources.Load("Prefabs/PlaneRed") as GameObject);
            Vector3 pos;
            //               size           *  random(0-1)  * 80%  +    minimum value        +       10% of size
            pos.x = s.GetWorldBound().size.x * Random.value * 0.8f + s.GetWorldBound().min.x + (s.GetWorldBound().size.x * 0.1f);
            pos.y = s.GetWorldBound().size.y * Random.value * 0.8f + s.GetWorldBound().min.y + (s.GetWorldBound().size.y * 0.1f);

            pos.z = 0;
            e.transform.localPosition = pos;
            Debug.Log("PlaneRed: " + pos);
            ++numberOfPlanes;
        }

        if (GameObject.Find("A_Walk(Clone)") == null)
        {
            Debug.Log("Instanciate A_Walk");
            GameObject e = Instantiate(Resources.Load("Prefabs/A_Walk") as GameObject);
            Vector3 pos = getPositionVariation(waypoints[0]);
            e.transform.localPosition = pos;
            e.GetComponent<waypointBehaviour>().currPos = pos;
            Debug.Log("A_Walk: " + pos);
        }
        if (GameObject.Find("B_Walk(Clone)") == null)
        {
            Debug.Log("Instanciate B_Walk");
            GameObject e = Instantiate(Resources.Load("Prefabs/B_Walk") as GameObject);
            Vector3 pos = getPositionVariation(waypoints[1]);
            e.transform.localPosition = pos;
            e.GetComponent<waypointBehaviour>().currPos = pos;
            Debug.Log("B_Walk: " + pos);
        }
        
        if (GameObject.Find("C_Walk(Clone)") == null)
        {
            Debug.Log("Instanciate C_Walk");
            GameObject e = Instantiate(Resources.Load("Prefabs/C_Walk") as GameObject);
            Vector3 pos = getPositionVariation(waypoints[2]);
            e.transform.localPosition = pos;
            e.GetComponent<waypointBehaviour>().currPos = pos;
            Debug.Log("C_Walk: " + pos);
        }
        if (GameObject.Find("D_Walk(Clone)") == null)
        {
            Debug.Log("Instanciate D_Walk");
            GameObject e = Instantiate(Resources.Load("Prefabs/D_Walk") as GameObject);
            Vector3 pos = getPositionVariation(waypoints[3]);
            e.transform.localPosition = pos;
            e.GetComponent<waypointBehaviour>().currPos = pos;
            Debug.Log("D_Walk: " + pos);
        }
        if (GameObject.Find("E_Walk(Clone)") == null)
        {
            Debug.Log("Instanciate E_Walk");
            GameObject e = Instantiate(Resources.Load("Prefabs/E_Walk") as GameObject);
            Vector3 pos = getPositionVariation(waypoints[4]);
            e.transform.localPosition = pos;
            e.GetComponent<waypointBehaviour>().currPos = pos;
            Debug.Log("E_Walk: " + pos);
        }
        if (GameObject.Find("F_Walk(Clone)") == null)
        {
            Debug.Log("Instanciate F_Walk");
            GameObject e = Instantiate(Resources.Load("Prefabs/F_Walk") as GameObject);
            Vector3 pos = getPositionVariation(waypoints[5]);
            e.transform.localPosition = pos;
            e.GetComponent<waypointBehaviour>().currPos = pos;
            Debug.Log("F_Walk: " + pos);
        }




        totalEggstxt.text = "Number of Eggs in World: " + totalEggs;
        totalPlanestxt.text = "Total Planes: " + maxPlanes;

        if (hideWaypoints)
        {
            hideWaypointstxt.text = "Waypoints: Hidden";
        }
        else
        {
            hideWaypointstxt.text = "Waypoints: Shown";
        }
        
    }
    public Vector3 getRandomPosition()
    {
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();
        Assert.IsTrue(s != null);
        Vector3 pos;
        //               size           *  random(0-1)  * 80%  +    minimum value        +       10% of size
        pos.x = s.GetWorldBound().size.x * Random.value * 0.8f + s.GetWorldBound().min.x + (s.GetWorldBound().size.x * 0.1f);
        pos.y = s.GetWorldBound().size.y * Random.value * 0.8f + s.GetWorldBound().min.y + (s.GetWorldBound().size.y * 0.1f);

        pos.z = 0;

        return pos;
    }

    public Vector3 getPositionVariation(Vector3 val)
    {
        float val_x = val.x;
        float val_y = val.y;
        float val_z = 0;
        float rand;
        
        rand = Random.Range(-15, 15);
        val_x = val_x + rand;

        rand = Random.Range(-15, 15);
        val_y = val_y + rand;

        val = new Vector3(val_x, val_y, val_z);
        return val;
    }



    public void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        numberOfPlanes--;
        planesDestroyed++;
        planesDestroyedtxt.text = "Number of Planes Destroyed: " + planesDestroyed; 
    }
    public void WaypointDestroyed()
    {
        Debug.Log("Waypoint Destroyed");
        waypointsDestroyed++;
        waypointsDestroyedtxt.text = "Number of Waypoints Destroyed: " + waypointsDestroyed;
    }



}
