using System;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ChapterContinuity {
    [SerializeField] private List<Chapter> chapters;
    [SerializeField] private UnityAction startActions;
    [SerializeField] private UnityAction endActions;

    public List<Chapter> Chapters => chapters;
    public UnityAction StartActions => startActions;
    public UnityAction EndActions => endActions;
}
