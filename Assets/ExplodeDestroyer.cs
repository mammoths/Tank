﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeDestroyer : MonoBehaviour {

    public float duration;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, duration);
    }
}
