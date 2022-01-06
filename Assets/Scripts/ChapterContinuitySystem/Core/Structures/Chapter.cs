using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[Serializable]
public struct Chapter {
    [SerializeField] private string stageName;
    //before start actions
    [SerializeField] private UnityEvent beforeStartActions;
    // start actions
    [SerializeField] private UnityEvent startActions;
    // progressionTrack
    [SerializeField] private List<ProgressTracker> progressTrackers;
    // end actions
    [SerializeField] private UnityEvent endActions;
    // after end actions
    [SerializeField] private UnityEvent afterEndActions;

    public string StageName => stageName;
    public UnityEvent BeforeStartActions => beforeStartActions;
    public UnityEvent StartActions => startActions;
    public List<ProgressTracker> ProgressTrackers => progressTrackers;
    public UnityEvent EndActions => endActions;
    public UnityEvent AfterEndActions => afterEndActions;
}
