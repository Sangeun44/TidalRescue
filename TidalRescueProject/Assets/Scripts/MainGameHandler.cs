using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameHandler : MonoBehaviour
{
    private int _max_time_for_level = 500;
    private int _max_points_for_level = 500;

    // do not reduce vertical so person still has room to stand
    private Vector3 _scale_reduction = new Vector3(0.1f, 0, 0.1f);

    public GameObject bubble_visual;
    public StateHandler state_handler;

    private int _update_tick_timer = 0; // ticked every update. used for modding game_timer
    private int _timer_mod = 30;

    public int game_timer = 0;
    public int points = 0;

    private bool _paused = false;

    void Start()
    {
        SetUpGame();
        Pause();
    }

    public void SetUpGame()
    {
        // separation between start and setupgame for reset purposes during
        // testing and if player ever wants to restart the game.
        _update_tick_timer = 0;
        game_timer = 0;
        _max_time_for_level = 500;
        points = 0;
        _max_points_for_level = 500;
        Debug.Log("SETUP GAME");
        UnPause();
    }

    public void Pause()
    {
        _paused = true;
        Debug.Log("PAUSED");
    }

    public void UnPause()
    {
        _paused = false;
        Debug.Log("UNPAUSED");
    }

    // Update is called once per frame
    void Update()
    {
        if (_paused) { return; } 

        ++_update_tick_timer;

        if (_update_tick_timer % _timer_mod == 0)
        {
            ++game_timer;
            HandleTimerUpdate();
        }
    }

    private void ShrinkBubble()
    {
        Vector3 temp_bubble_visual = bubble_visual.transform.localScale - _scale_reduction;
        Debug.Log("TEMP BUBBLE VISUAL-------------------------------------------------------------");
        Debug.Log(temp_bubble_visual);
        bubble_visual.transform.localScale = new Vector3(temp_bubble_visual.x,
                                                         temp_bubble_visual.y,
                                                         temp_bubble_visual.z);
    }

    private void IncreaseBubble()
    {
        // TODO - CALL THIS WHEN GOOD THINGS HAPPEN - timer also increases with this
        Vector3 temp_bubble_visual = bubble_visual.transform.localScale + _scale_reduction;
        bubble_visual.transform.localScale = new Vector3(temp_bubble_visual.x,
                                                         temp_bubble_visual.y,
                                                         temp_bubble_visual.z);
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

        ShrinkBubble();
    }

    public void HandleEvents()
    {
        ViveInput left = state_handler.vive_input_left;
        ViveInput right = state_handler.vive_input_right;

        if ((left.colliding_object && left.colliding_object.name == "GenericSeaAnimal")
              || (right.colliding_object && right.colliding_object.name == "GenericSeaAnimal"))
        {
            // TODO: handle sea animal destruction properly

            Debug.Log("(HEALED) OR (GOT INFO FROM TAGGED) GENERIC SEA ANIMAL");
        }
    }
}
