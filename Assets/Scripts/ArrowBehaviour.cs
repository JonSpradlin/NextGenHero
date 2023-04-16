using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBehaviour : MonoBehaviour
{
    public float mov_speed = 20.0f;
    public float rot_speed = 45f / 1f;
    public bool mouseControl = true;
    private float timeSinceInstanciate = 0;
    public Rigidbody2D rb;
    private GameController mGameGameController;
    public Text controlMode = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mGameGameController = FindObjectOfType<GameController>();
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
                controlMode.text = "Control Mode: WASD";
            }
            else
            {
                mouseControl = true;
                mGameGameController.mouseControl = true;
                controlMode.text = "Control Mode: Mouse";
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
                // transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rot_speed, Space.World);
                transform.Rotate(transform.forward, rot_speed * Time.smoothDeltaTime);
                // Debug.Log("Hero Rotation (left): " + transform.localRotation.x + ", " + transform.localRotation.y + ", " + transform.localRotation.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mov_speed -= 0.1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward, -rot_speed * Time.smoothDeltaTime);
                // Debug.Log("Hero Rotation (right): " + transform.localRotation.x + ", " + transform.localRotation.y + ", " + transform.localRotation.z);
            }

            rb.velocity = transform.up * mov_speed;

        }

        if (Input.GetKey(KeyCode.Space))
        {
            // float two = DateTime.UtcNow.Ticks;// - timeSinceInstanciate; 
            // two = two - timeSinceInstanciate;

            if ((Time.time - timeSinceInstanciate) > 0.2 || timeSinceInstanciate == 0)
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
                timeSinceInstanciate = Time.time;
                e.transform.localPosition = transform.localPosition;
                e.transform.rotation = transform.rotation;
                mGameGameController.totalEggs++;
                // Debug.Log("Spawn Eggs:" + e.transform.localPosition);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hero collision Object:" + collision.gameObject.name);
        if (collision.gameObject.name == "PlaneRed(Clone)")
        {
            Debug.Log("Hero entered enemy collider");
            Destroy(collision.gameObject);
            mGameGameController.EnemyDestroyed();
        }
    }
}
