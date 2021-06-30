using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Text Menu;
    [SerializeField] AudioSource BGMusic;
    [SerializeField] AudioSource specialEffect;

    [SerializeField] Image BGImage;

    AudioSource specialMusic;

    State curState;
    State[] nextState;

    // Start is called before the first frame update
    void Start()
    {
        curState = startingState;

        textComponent.text = curState.getStateStory();

        //Image
        BGImage.sprite = startingState.GetBG();

        //Sound
        BGMusic.clip = startingState.GetAudio();
        BGMusic.Play();


        nextState = curState.getNextStates();
    }

    // Update is called once per frame
    void Update()
    {
        if (curState != startingState) Menu.text = "";

        textComponent.text = curState.getStateStory();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            curState = nextState[0];
            ChangeImage(curState);
            PlaySpecialSound(curState);
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            curState = nextState[1];
            ChangeImage(curState); 
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

    void ChangeImage(State temp)
    {
        if (temp.GetBG())
        {
            BGImage.sprite = temp.GetBG();
        }
    }
}
