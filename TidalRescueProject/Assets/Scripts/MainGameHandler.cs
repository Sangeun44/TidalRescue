using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MainGameHandler : MonoBehaviour
{
    public TextMesh gtext;
    public TextMesh score_text;
    public static int score = 0;

    private int _max_time_for_level = 500;
    private int _max_points_for_level = 500;

    // do not reduce vertical so person still has room to stand
    private Vector3 _scale_reduction = new Vector3(0.05f, 0.05f, 0.05f);

    public GameObject bubble_visual;
    public StateHandler state_handler;

    private int _update_tick_timer = 0; // ticked every update. used for modding game_timer
    private int _timer_mod = 30;

    public int game_timer = 0;
    public bool game_started = false;
    public int points = 0;

    private bool _paused = false;

    private int sick_points = 15;
    private int tagged_points = 10;

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
        _max_time_for_level = 300;
        points = 0;
        _max_points_for_level = 500;
        UnPause();
    }

    public void Pause()
    {
        _paused = true;
    }

    public void UnPause()
    {
        _paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        state_handler.gtext.text = (_max_time_for_level - game_timer).ToString();
        score_text.text = "Score: " + (score).ToString();

        if (_paused) { return; } 

        ++_update_tick_timer;

        CheckPlayerPos();

        if (_update_tick_timer % _timer_mod == 0)
        {
            ++game_timer;
            HandleTimerUpdate();
        }
    }

    List<XRNodeState> nodeStatesCache = new List<XRNodeState>();
    private void CheckPlayerPos()
    {
        // circle of bubble: 
        // compare against center of sphere

        InputTracking.GetNodeStates(nodeStatesCache);
        Vector3 hmd_pos = new Vector3();
        for (int i = 0; i < nodeStatesCache.Count; i++)
        {
            XRNodeState nodeState = nodeStatesCache[i];
            if (nodeState.nodeType == XRNode.CenterEye)
            {
                nodeState.TryGetPosition(out hmd_pos);
            }
        }

        if (Vector2.Distance( new Vector2(hmd_pos.x, hmd_pos.y), new Vector2(0, 0)) < bubble_visual.transform.localScale.x / 1.5)
        {
            // within - fine
        } else
        {
            state_handler.SetState(GameState.GAMEOVER);
        }
    }

    private void ShrinkBubbleByTime()
    {
        Debug.Log("Shrink");
        
        Vector3 temp_bubble_visual = bubble_visual.transform.localScale - _scale_reduction;
        bubble_visual.transform.localScale = new Vector3(temp_bubble_visual.x,
                                                         temp_bubble_visual.y,
                                                         temp_bubble_visual.z);
    }

    public void ShrinkBubble()
    {
        ShrinkBubbleByTime();

        game_timer += 5;
    }

    private void IncreaseBubble()
    {
        Vector3 temp_bubble_visual = bubble_visual.transform.localScale + _scale_reduction;
        bubble_visual.transform.localScale = new Vector3(temp_bubble_visual.x,
                                                         temp_bubble_visual.y,
                                                         temp_bubble_visual.z);
        game_timer -= 5;
    }

    void HandleTimerUpdate()
    {
        // end game?
        if (game_timer > _max_time_for_level)
        {
            Debug.Log("YOU DIED");
            gtext.text = "GAMEOVER";
            state_handler.SetState(GameState.GAMEOVER);
        }
        //if (points >= _max_points_for_level)
        //{
        //    Debug.Log("LEVEL COMPLETE!");
        //    state_handler.SetState(GameState.STARTSCREEN);
        //}

        ShrinkBubbleByTime();
    }

    public void HandleEvents()
    {
        ViveInput left = state_handler.vive_input_left;
        ViveInput right = state_handler.vive_input_right;

        // if (left.colliding_object)     
        // {
        //     if (left.colliding_object.tag == "TAGGED")
        //     {
        //         // researching with research hand:
        //         IncreaseBubble();
        //         points += tagged_points; // point value rep
        //     }
        //     else
        //     {
        //         // incorrect hand for the job
        //         ShrinkBubble();
        //         points -= sick_points; // point value rep
        //     }
        // }

        //  if (right.colliding_object)
        //  {
        //     if (right.colliding_object.tag == "SICK")
        //     {
        //         // healing with healing hand:
        //         IncreaseBubble();
        //         points += sick_points; // point value rep
        //     }
        //     else
        //     {
        //         // incorrect hand for the job
        //         ShrinkBubble();
        //         points -= tagged_points; // point value rep
        //     }
        //  }
    }
}
