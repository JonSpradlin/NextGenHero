using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

public class EnemyBehaviour : MonoBehaviour
{

    public float hits = 4;
    private GameController gGameGameController;

    // Start is called before the first frame update    
    void Start()
    {
        gGameGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update(){}

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

            gGameGameController.EnemyDestroyed();
            Destroy(gameObject);
            
        }
        Debug.Log("leaving eggHit");

    }

  
}
