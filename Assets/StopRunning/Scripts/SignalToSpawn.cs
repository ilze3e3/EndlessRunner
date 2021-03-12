using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalToSpawn : MonoBehaviour
{
    public bool spawnSignal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "EndOfLevel")
        {
            Debug.Log("Should Spawn");
            Debug.Log(collision.gameObject.name);
            spawnSignal = true;
        }
    }

    public bool GetSignal()
    {

        return spawnSignal;
    }
}
