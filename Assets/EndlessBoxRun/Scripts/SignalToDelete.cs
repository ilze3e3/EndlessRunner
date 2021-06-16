using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalToDelete : MonoBehaviour
{
    public bool destroySignal = false;
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
            //Debug.Log("Should Destroy");
            destroySignal = true;
            //Destroy(this);
        }
    }
    public bool GetSignal()
    {
        return destroySignal;
    }
}
