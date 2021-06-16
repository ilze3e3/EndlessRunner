using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI start_text;

    public GameObject game_over_panel;

    private float score = 0;

    private bool game_start = false;
    private bool player_dead = false;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().IsPlayerDead())
        {
            player_dead = true;
            player.GetComponent<PlayerMovement>().IsGameStart(false);
        }
        if (game_start && !player_dead)
        {
            score += 10 * Time.deltaTime;
            score_text.text = "Score: " + score.ToString("0") + " Metres";
        }

        if(player_dead)
        {
            game_over_panel.SetActive(true);
            GetComponentInChildren<Spawner>().GameEnd();
            GetComponentInChildren<BackgroundSpawner>().GameEnd();
        }

        if(Input.GetKeyDown("space"))
        {
            start_text.enabled = false;
            game_start = true;
            GetComponentInChildren<Spawner>().SetGameStart();
            GetComponentInChildren<BackgroundSpawner>().SetGameStart();
            player.GetComponent<PlayerMovement>().IsGameStart(true);
        }

        

    }
}
