using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBehaviour : MonoBehaviour
{
    public float mov_speed = 20.0f;
    public float rot_speed = 45f / 1f;
    public float fireRate = 1f;
    public bool mouseControl = true;
    private float timeSinceInstanciate = 0;
    public float touched = 0;
    public Rigidbody2D rb;
    private GameController mGameGameController;
    public Text controlMode = null;
    public Text eggCooldown = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mGameGameController = FindObjectOfType<GameController>();
        fireRate = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // check for change between mouse control
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mouseControl)
            {
                mouseControl = false;
                mGameGameController.mouseControl = false;
                controlMode.text = "Hero Control Mode: WASD";
            }
            else
            {
                mouseControl = true;
                mGameGameController.mouseControl = true;
                controlMode.text = "Hero Control Mode: Mouse";
            }
        }

        if (mouseControl)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log("Position is " + pos);
            pos.z = 0f;

            //set rotation to zero on entering mouse control mode
            transform.rotation = Quaternion.identity;
            transform.position = pos;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                mov_speed += 0.1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.forward, rot_speed * Time.smoothDeltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mov_speed -= 0.1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward, -rot_speed * Time.smoothDeltaTime);
            }

            rb.velocity = transform.up * mov_speed;

        }


        float t = Time.time - timeSinceInstanciate;
        if (t > fireRate)
        {
            eggCooldown.text = "Egg Cooldown: 0.000 s";
        }
        else
        {
            eggCooldown.text = "Egg Cooldown: " + t.ToString("F3") + " s";
            
        }


        if (Input.GetKey(KeyCode.Space))
        {
 
            if ((Time.time - timeSinceInstanciate) > fireRate || timeSinceInstanciate == 0)
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
                timeSinceInstanciate = Time.time;
                e.transform.localPosition = transform.localPosition;
                e.transform.rotation = transform.rotation;
                mGameGameController.totalEggs++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hero collision Object:" + collision.gameObject.name);
        if (collision.gameObject.name == "PlaneRed(Clone)")
        {
            Debug.Log("Hero entered enemy collider");
            touched++;
            mGameGameController.planesTouched.text = "Number of Planes Touched: " + touched;
            Destroy(collision.gameObject);
            mGameGameController.EnemyDestroyed();
        }
    }
}
