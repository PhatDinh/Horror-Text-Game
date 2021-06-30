using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] Text choiceComponent1;
    [SerializeField] Text choiceComponent2;

    [SerializeField] State startingState;
    [SerializeField] Text Menu;
    [SerializeField] AudioSource BGMusic;
    [SerializeField] AudioSource specialEffect;

    [SerializeField] Image BGImage;


    [SerializeField] Button choice1;
    [SerializeField] Button choice2;

    AudioSource specialMusic;

    State curState;
    State[] nextState;

    // Start is called before the first frame update
    void Start()
    {   
        curState = startingState;

        //Story Text
        textComponent.text = curState.getStateStory();
        //Choice Text
        choiceComponent1.text = curState.getChoice(1);
        choiceComponent2.text = curState.getChoice(2);
        //Image
        BGImage.sprite = startingState.GetBG();

        //Sound
        BGMusic.clip = startingState.GetAudio();
        BGMusic.Play();

        //Move to Next State
        nextState = curState.getNextStates();
    }

    // Update is called once per frame
    void Update()
    {
        //Remove Tittle
        if (curState != startingState) Menu.text = "";

        //update text
        textComponent.text = curState.getStateStory();
        choiceComponent1.text = curState.getChoice(1);
        choiceComponent2.text = curState.getChoice(2);

        //onClick
        choice1.onClick.AddListener(TaskOnClick1);
        choice2.onClick.AddListener(TaskOnClick2);

        //Move to next state
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

    public void TaskOnClick1()
    {
        curState = nextState[0];
        ChangeImage(curState);
        PlaySpecialSound(curState);
    }
    public void TaskOnClick2()
    {
        curState = nextState[1];
        ChangeImage(curState);
        PlaySpecialSound(curState);
    }
}
