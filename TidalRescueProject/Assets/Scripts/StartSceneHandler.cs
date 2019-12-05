using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneHandler : MonoBehaviour
{
    public GameObject start_button;
    public GameObject tutorial_button;

    public StateHandler state_handler;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPressed()
    {
        Debug.Log("start press");
        state_handler.SetState(GameState.PLAYING);
    }

    void TutorialPressed()
    {
        // TODO handle tutorial in start scene
        // done need to add another state to state handler for here.
        // maybe just pass through pages of instructions??
    }

    public void Reset()
    {
        start_button.SetActive(true);
        tutorial_button.SetActive(true);
    }

    public void LeaveStartScene()
    {
        start_button.SetActive(false);
        tutorial_button.SetActive(false);
    }
}
