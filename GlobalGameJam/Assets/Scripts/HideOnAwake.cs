﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnAwake : MonoBehaviour
{

    void Awake()
    {
        this.gameObject.SetActive(false);
    }

}
