using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> preFabList;

    public GameObject currLevel;
    public GameObject tmpLevel;
    public GameObject nextLevel;

    public GameObject spawnFlag;
    private Vector3 spawnLocation;

    public bool signalToSpawn;
    public bool signalToDestroy;

    private int index;

    [SerializeField]
    private bool spawnOnce = true;
    [SerializeField]
    private bool destroyOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = spawnFlag.transform.position;
        index = (int)Random.Range(0, preFabList.Count);

        nextLevel = preFabList[index];

    }

    // Update is called once per frame
    void Update()
    {
        signalToSpawn = currLevel.GetComponent<LevelMovement>().GetSignalToSpawn();
        
        signalToDestroy = currLevel.GetComponent<LevelMovement>().GetSignalToDestroy();

        if (signalToSpawn && spawnOnce)
        {
            Debug.Log("Spawn Next Level");
            tmpLevel = Instantiate(nextLevel, spawnLocation, new Quaternion());
            signalToSpawn = false;
            spawnOnce = false;
            destroyOnce = true;
        }

        if (signalToDestroy && destroyOnce)
        {
            Debug.Log("Destroy Current Level");
            Destroy(currLevel);

            currLevel = tmpLevel;

            index = (int)Random.Range(0, preFabList.Count);

            nextLevel = preFabList[index];
            spawnOnce = true;
            destroyOnce = false;

        }
    }
}