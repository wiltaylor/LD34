﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance { private set; get;}

    [HideInInspector]
    public AudioController AudioController;

    [HideInInspector]
    public FactoryController FactoryController;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AudioController = GetSubItem<AudioController>();
        FactoryController = GetSubItem<FactoryController>();
    }

    T GetSubItem<T>()
    {
        var ret = GetComponent<T>();

        if (ret == null)
        {
            ret = GetComponentInChildren<T>();
        }

        return ret;
    }
}
