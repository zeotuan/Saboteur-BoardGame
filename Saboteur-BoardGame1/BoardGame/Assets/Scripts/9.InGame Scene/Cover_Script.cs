﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover_Script : MonoBehaviour
{
    public void Buttons()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}