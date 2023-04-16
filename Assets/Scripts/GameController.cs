using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool mouseControl = true;
    public int maxPlanes = 10;
    public int planesDestroyed = 0;
    public int totalEggs = 0;
    private int numberOfPlanes = 0;
    public Text planesDestroyedtxt = null;
    public Text totalEggstxt = null;
    public Text totalPlanestxt = null;
    // Start is called before the first frame update
    void Start()
    {
        //canvasObject = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
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
            ++numberOfPlanes;
        }

        if (GameObject.Find("A_Walk") == null)
        {
            GameObject e = Instantiate(Resources.Load("Prefabs/A_Walk") as GameObject);
            Vector3 pos = getRandomPosition();
            e.transform.localPosition = pos;
        }
        



        totalEggstxt.text = "Total Eggs: " + totalEggs;
        totalPlanestxt.text = "total Planes: " + maxPlanes;

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


    public void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        numberOfPlanes--;
        planesDestroyed++;
        planesDestroyedtxt.text = "Planes Destroyed by Arrow: " + planesDestroyed; 
    }



}
