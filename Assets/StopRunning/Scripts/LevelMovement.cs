using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public GameObject levelHead;
    public GameObject levelTail;

    public bool SignalToSpawn;
    public bool SignalToDestroy;

    public float moveSpeed = 5;
    public Vector3 userDirection = Vector3.left;
    Transform position;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SignalToSpawn = levelHead.GetComponent<SignalToSpawn>().GetSignal(); // Gets signal to spawn the next level

        SignalToDestroy = levelTail.GetComponent<SignalToDelete>().GetSignal(); // Gets signal to destroy this level

        transform.Translate(userDirection * moveSpeed * Time.deltaTime);  // Move Level      
    }

    public bool GetSignalToSpawn()
    {
        return SignalToSpawn;
    }
    public bool GetSignalToDestroy()
    {
        return SignalToDestroy;
    }
}
