using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer BGM;
    public bool mute = false;
    public float origin_volume;
    //public AudioMixer Mute;
    //public float Main_value;
    private void Start()
    {
        BGM.GetFloat("BGM_1", out origin_volume);
        this.transform.Find("Panel/Pop_up/BGMSlider").GetComponent<Slider>().value = origin_volume;
        if (origin_volume == -40)
        {
            mute = true;
            this.transform.Find("Panel/Pop_up/Mute").GetComponent<Toggle>().SetIsOnWithoutNotify(true);
        }
        else
        {
            mute = false;
            this.transform.Find("Panel/Pop_up/Mute").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        }
    }
    public void SetBGM(float BgmName)
    {
        origin_volume = BgmName;
        this.transform.Find("Panel/Pop_up/Mute").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        mute = false;
        BGM.SetFloat("BGM_1", BgmName);
        if (BgmName == -40)
        {
            mute = true;
            this.transform.Find("Panel/Pop_up/Mute").GetComponent<Toggle>().SetIsOnWithoutNotify(true);
        }
        else
        {
            mute = false;
            this.transform.Find("Panel/Pop_up/Mute").GetComponent<Toggle>().SetIsOnWithoutNotify(false);
        }

    }
    public void SetMute()
    {
        if(mute == false)
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
