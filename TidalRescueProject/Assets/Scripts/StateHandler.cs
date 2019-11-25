using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    GameState current_state;

    void Start()
    {
        current_state = GameState.STARTSCREEN;

        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // handle controllers interactions

        // handle mouse interactions

        //if (Input.GetKeyDown(KeyCode.


        switch (current_state)
        {
            case GameState.STARTSCREEN:
                //Debug.Log("STARTSCREEN");
                break;
            case GameState.TUTORIAL:
               // Debug.Log("TUTORIAL");
                break;
            case GameState.PLAYING:
               // Debug.Log("PLAYING");
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
        // TODO: handle state changes appropriately

        // update to new state
        current_state = new_state;
    }
}
