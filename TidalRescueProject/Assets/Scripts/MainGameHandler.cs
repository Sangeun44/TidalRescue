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
    private Vector3 _scale_reduction = new Vector3(0.4f, 0.0f, 0.4f);
    private Vector3 _scale_reduction_floor = new Vector3(0.05f, 0.05f, 0.05f);

    public GameObject bubble_visual;
    public GameObject bubble_floor_visual;
    public StateHandler state_handler;

    private int _update_tick_timer = 0; // ticked every update. used for modding game_timer
    private int _timer_mod = 150;

    public int game_timer = 0;
    public bool game_started = false;
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
        score_text.text = "Score: " + (points).ToString();

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
        if (_paused)
        {
            return;
        }

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

        double temp = bubble_floor_visual.transform.localScale.x * 4;
        if (Vector2.Distance( new Vector2(hmd_pos.x, hmd_pos.z), new Vector2(0, 0)) < temp )
        {
            //Debug.Log("WITHIN FINE: " + (Vector2.Distance(new Vector2(hmd_pos.x, hmd_pos.z), new Vector2(0, 0))) + " IS LESS THAN: " + temp);
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

        if (temp_bubble_visual.x < 0 || temp_bubble_visual.y < 0 || temp_bubble_visual.z < 0)
        {
            state_handler.SetState(GameState.GAMEOVER);
        }

        bubble_visual.transform.localScale = new Vector3(temp_bubble_visual.x,
                                                         temp_bubble_visual.y,
                                                         temp_bubble_visual.z);

        //Debug.Log("BUBBLE SCALE: " + bubble_visual.transform.localScale.x);

        Vector3 temp_bubble_floor_visual = bubble_floor_visual.transform.localScale - _scale_reduction_floor;
        if (temp_bubble_floor_visual.x < 0 || temp_bubble_floor_visual.y < 0 || temp_bubble_floor_visual.z < 0)
        {
            state_handler.SetState(GameState.GAMEOVER);
        }
        bubble_floor_visual.transform.localScale = new Vector3(temp_bubble_floor_visual.x,
                                                         temp_bubble_floor_visual.y,
                                                         temp_bubble_floor_visual.z);

        //Debug.Log("BUBBLE FLOOR SCALE: " + bubble_floor_visual.transform.localScale.x);
    }

    public void ShrinkBubble()
    {
        if (_paused)
        {
            return;
        }
        ShrinkBubbleByTime();

        game_timer += 5;
    }

    public void IncreaseBubble()
    {
        if (_paused)
        {
            return;
        }

        Debug.Log("Increase");

        Vector3 temp_bubble_visual = bubble_visual.transform.localScale + _scale_reduction;
        bubble_visual.transform.localScale = new Vector3(temp_bubble_visual.x,
                                                         temp_bubble_visual.y,
                                                         temp_bubble_visual.z);
        Vector3 temp_bubble_floor_visual = bubble_floor_visual.transform.localScale + _scale_reduction_floor;
        bubble_floor_visual.transform.localScale = new Vector3(temp_bubble_floor_visual.x,
                                                         temp_bubble_floor_visual.y,
                                                         temp_bubble_floor_visual.z);


        game_timer -= 5;
    }

    void HandleTimerUpdate()
    {
        if (_paused)
        {
            return;
        }

        // end game?
        if (game_timer > _max_time_for_level)
        {
            Debug.Log("YOU DIED");
            gtext.text = "GAMEOVER";
            _paused = true;
            game_started = false;
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
        if (_paused)
        {
            return;
        }

        //ViveInput left = state_handler.vive_input_left;
        //ViveInput right = state_handler.vive_input_right;

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
