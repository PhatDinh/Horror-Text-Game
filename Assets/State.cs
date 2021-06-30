using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextState;
    [SerializeField] AudioClip Sound;
    public string getStateStory()
    {
        return storyText;
    }

    public State[] getNextStates()
    {
        return nextState;
    }

    public AudioClip GetAudio()
    {
        return Sound;
    }
}
