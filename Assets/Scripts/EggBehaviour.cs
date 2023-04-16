using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EggBehaviour : MonoBehaviour
{

    public float eggSpeed = 40f;
    private bool collided = false;
    public float mainCam;
    private GameController mGameGameController;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.orthographicSize;
        mGameGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * eggSpeed * Time.smoothDeltaTime;

        //if projectile leaves main camera boundaries then destroy the object 
        if (outOfBounds())
        {
            Destroy(gameObject);
            mGameGameController.totalEggs--;
            Debug.Log("(Out of bounds) Destroyed: Egg");

        }
        if (collided)
        {
            Destroy(gameObject);
            mGameGameController.totalEggs--;
            Debug.Log("(Object Collision) Destroyed: Egg");
        }
    }

    public bool outOfBounds()
    {

        CameraSupport s = Camera.main.GetComponent<CameraSupport>();
        Assert.IsTrue(s != null);

        if (transform.position.y > s.GetWorldBound().max.y)
        {
            return true;
        }
        if (transform.position.y < s.GetWorldBound().min.y)
        {
            return true;
        }
        if (transform.position.x > s.GetWorldBound().max.x)
        {
            return true;
        }
        if (transform.position.x < s.GetWorldBound().min.x)
        {
            return true;
        }
        return false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Egg collision Object:" + collision.gameObject.name);
        if (collision.gameObject.name == "PlaneRed(Clone)")
        {
            Debug.Log("Egg entered enemy collider");
            Debug.Log("----Calling hit()");
            collided = true;
            collision.gameObject.GetComponent<EnemyBehaviour>().hit();
        }
        //Destroy(collision.gameObject);
        //mGameGameController.EnemyDestroyed();

    }








}
