using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PopUp_menu_volume : MonoBehaviour
{
    public AudioMixer BGM;
    public bool mute = false;
    public float origin_volume;
    //public AudioMixer Mute;
    //public float Main_value;
    private void Start()
    {
        mute = false;
    }
    public void SetBGM(float BgmName)
    {
        origin_volume = BgmName;
        this.transform.Find("Mute").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        mute = false;
        BGM.SetFloat("BGM_1", BgmName);
    }
    public void SetMute()
    {
        if (mute == false)
        {
            mute = true;
            BGM.SetFloat("BGM_1", -40);
        }
        else
        {
            mute = false;
            BGM.SetFloat("BGM_1", origin_volume);
        }
    }
}
