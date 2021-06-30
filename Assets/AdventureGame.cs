using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    [SerializeField] AudioSource BGMusic;
    [SerializeField] AudioSource specialEffect;

    AudioSource specialMusic;

    State curState;
    State[] nextState;

    // Start is called before the first frame update
    void Start()
    {
        curState = startingState;
        textComponent.text = curState.getStateStory();

        BGMusic.clip = startingState.GetAudio();
        BGMusic.Play();
        nextState = curState.getNextStates();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = curState.getStateStory();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            curState = nextState[0];
            PlaySpecialSound(curState);
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            curState = nextState[1];
            PlaySpecialSound(curState);
        }

        nextState = curState.getNextStates(); 

    }

    void PlaySpecialSound(State temp)
    {
        if (temp.GetAudio())
        {
            AudioClip t = temp.GetAudio();
            specialEffect.clip = t;
            specialEffect.Play();
        }
    }
}
