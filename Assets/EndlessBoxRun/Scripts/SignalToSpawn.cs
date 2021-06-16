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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndOfLevel")
        {
            //Debug.Log("Should Spawn");
            //Debug.Log(this.gameObject.GetComponentInParent<Transform>().name);
            spawnSignal = true;
            //Destroy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public bool GetSignal()
    {

        return spawnSignal;
    }
}
