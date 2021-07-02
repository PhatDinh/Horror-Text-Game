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


    [SerializeField] Button[] choice;
    int checkChoice;

    AudioSource specialMusic;

    State curState;
    State[] nextStates;
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

        //Move to next state
        nextStates = curState.getNextStates();
    }

    // Update is called once per frame
    void Update()
    {
        //Remove Tittle
        if (curState != startingState) Menu.text = "";

        //
        textComponent.text = curState.getStateStory();
        choiceComponent1.text = curState.getChoice(1);
        choiceComponent2.text = curState.getChoice(2);

        //
        choice[0].onClick.AddListener(() => checkClick(0));
        choice[1].onClick.AddListener(() => checkClick(1));
        //choice[2].onClick.AddListener(() => checkClick(2));

        //
        nextStates = curState.getNextStates();

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
    public void ManageState()
    {
        textComponent.text = curState.getStateStory();
        choiceComponent1.text = curState.getChoice(1);
        choiceComponent2.text = curState.getChoice(2);
    }

    void checkClick(int i)
    {
        curState = nextStates[i];
        ChangeImage(curState);
        PlaySpecialSound(curState);
    }
}
