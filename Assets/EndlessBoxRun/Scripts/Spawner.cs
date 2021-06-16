using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool game_start = false;
    public List<GameObject> preFabList;

    public GameObject currLevel;
    public GameObject tmpLevel;
    public GameObject nextLevel;

    public GameObject spawnFlag;
    private Vector3 spawnLocation;

    public float Level_Speed = 0;

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
        if (game_start)
        {
            currLevel.GetComponent<LevelMovement>().SetLevelSpeed(Level_Speed);
            signalToSpawn = currLevel.GetComponent<LevelMovement>().GetSignalToSpawn();

            signalToDestroy = currLevel.GetComponent<LevelMovement>().GetSignalToDestroy();

            if (signalToSpawn && spawnOnce)
            {
                Debug.Log("Spawn Next Level");
                tmpLevel = Instantiate(nextLevel, spawnLocation, new Quaternion());
                tmpLevel.GetComponent<LevelMovement>().SetLevelSpeed(Level_Speed);
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

    public void SetGameStart()
    {
        Level_Speed = 5;
        game_start = true;
    }
    
    public void GameEnd()
    {
        Level_Speed = 0;
        currLevel.GetComponent<LevelMovement>().SetLevelSpeed(0);
        tmpLevel.GetComponent<LevelMovement>().SetLevelSpeed(0);

    }
}