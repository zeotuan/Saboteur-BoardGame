using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer BGM;
    //public AudioMixer Mute;
    //public float Main_value;
    public void SetBGM(float BgmName)
    {
        //    audioMixer.SetFloat("Audio Source", volume);
        BGM.SetFloat("BGM_1", BgmName);
    }
    /*public void SetMute(float MuteName)
    {
        Main_value = Mute.GetFloat("Main", Main_value);
    }
    */
    public void mute()
    {/*
        if()
        {
            BGM.SetFloat("BGM_1", 1);
        }
        */
    }
}
