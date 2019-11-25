using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameHandler : MonoBehaviour
{
    private int _max_time_for_level = 500;
    private int _max_points_for_level = 500;

    // do not reduce vertical so person still has room to stand
    private Vector3 _scale_reduction = new Vector3(0.05f, 0, 0.05f);

    public GameObject bubble;
    public StateHandler state_handler;

    private int _update_tick_timer = 0; // ticked every update. used for modding game_timer
    private int _timer_mod = 200;

    public int game_timer = 0;
    public int points = 0;

    void Start()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        // separation between start and setupgame for reset purposes during
        // testing and if player ever wants to restart the game.
        _update_tick_timer = 0;
        game_timer = 0;
        _max_time_for_level = 500;
        points = 0;
        _max_points_for_level = 500;
    }

    // Update is called once per frame
    void Update()
    {
        ++_update_tick_timer;

        if (_update_tick_timer % _timer_mod == 0)
        {
            ++game_timer;
            HandleTimerUpdate();
        }
    }

    void HandleTimerUpdate()
    {
        // end game?
        if (game_timer > _max_time_for_level)
        {
            Debug.Log("YOU DIED");
            state_handler.SetState(GameState.GAMEOVER);
        }
        if (points >= _max_points_for_level)
        {
            Debug.Log("LEVEL COMPLETE!");
            state_handler.SetState(GameState.STARTSCREEN);
        }

        // shrink bubble
        bubble.transform.localScale -= _scale_reduction;
    }
}
