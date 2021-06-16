using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public bool game_start = false;
    public GameObject prefab_bg;

    public GameObject curr_bg;
    public GameObject next_bg;

    public GameObject spawn_flag;
    public Vector3 spawn_location;

    public float bg_speed = 0;

    public bool signal_to_spawn;
    public bool signal_to_destroy;

    [SerializeField]
    private bool spawn_once = true;
    private bool destroy_once = true;

    // Start is called before the first frame update
    void Start()
    {

        spawn_location = spawn_flag.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (game_start)
        {
            curr_bg.GetComponent<BackgroundMovement>().SetLevelSpeed(bg_speed);
            signal_to_spawn = curr_bg.GetComponent<BackgroundMovement>().GetSignalToSpawn();
            signal_to_destroy = curr_bg.GetComponent<BackgroundMovement>().GetSignalToDestroy();


            if (signal_to_spawn && spawn_once)
            {
                next_bg = Instantiate(prefab_bg, spawn_location, new Quaternion());
                next_bg.GetComponent<BackgroundMovement>().SetLevelSpeed(bg_speed);
                signal_to_spawn = false;
                spawn_once = false;
                destroy_once = true;
            }

            if (signal_to_destroy && destroy_once)
            {
                Destroy(curr_bg);
                curr_bg = next_bg;

                spawn_once = true;
                destroy_once = false;

            }
        }
    }

    public void SetGameStart()
    {
        bg_speed = 1;
        game_start = true;
    }
    public void GameEnd()
    {
        bg_speed = 0;
        curr_bg.GetComponent<BackgroundMovement>().SetLevelSpeed(0);
        if(next_bg != null) next_bg.GetComponent<BackgroundMovement>().SetLevelSpeed(0);
    }
}
