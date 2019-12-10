using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public enum GameState
{
    STARTSCREEN = 0,
    TUTORIAL,
    PLAYING,
    GAMEOVER,

    NUM_STATES
}

public class StateHandler : MonoBehaviour
{
    public TextMesh gtext;

    public GameState current_state;
    public ViveInput vive_input_left;
    public ViveInput vive_input_right;
    public ViveInput hmd;

    public MainGameHandler main_game;
    public StartSceneHandler start_scene_handler;

    void Start()
    {
        current_state = GameState.STARTSCREEN;
    }

    // Update is called once per frame
    void Update()
    {
        // handle interactions

        switch (current_state)
        {
            //if player touches the block
            case GameState.STARTSCREEN:
                if ((vive_input_left.colliding_object && vive_input_left.colliding_object.name == "StartBlock")
                    || (vive_input_right.colliding_object && vive_input_right.colliding_object.name == "StartBlock"))
                {
                    SetState(GameState.PLAYING);
                    Debug.Log("SET STATE TO GAMESTATE PLAYING");
                }
                break;
            // case GameState.TUTORIAL:
               // Debug.Log("TUTORIAL");
               // break;
            case GameState.PLAYING:
                main_game.HandleEvents();
                //Debug.Log("playing");
                break;
            case GameState.GAMEOVER:
               // Debug.Log("GAMEOVER");
                break;
            default:
                Debug.Log("Default case. ERROR: SHOULD NEVER HIT THIS.");
                throw new System.Exception("Crashing application in state check for unexpected case.");
        }
    }

    public void SetState(GameState new_state)
    {
        var old_state = current_state;
        if (old_state == GameState.STARTSCREEN)
        {
            start_scene_handler.LeaveStartScene();
        }

        // update to new state
        current_state = new_state;

        switch (new_state)
        {
            case GameState.STARTSCREEN:
                Debug.Log("SWITCHING TO : START SCREEN");
                start_scene_handler.Reset();
                break;
            case GameState.PLAYING:
                Debug.Log("SWITCHING TO : PLAYING");
                main_game.SetUpGame();
                main_game.game_started = true;
                break;
            case GameState.GAMEOVER:
                Debug.Log("SWITCHING TO : GAMEOVER");
                main_game.Pause();
                main_game.score_text.text = "GAME-OVER";
                break;
            default:
                Debug.Log("Default case. ERROR: SHOULD NEVER HIT THIS.");
                throw new System.Exception("Crashing application in state check for unexpected case.");
        }
    }
}
