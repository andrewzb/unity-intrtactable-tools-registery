using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Ñhapter", menuName = "ScriptableObjects/Ñhapter", order = 1)]
public class Ñhapter : ScriptableObject {
    [SerializeField] private string stageName;
    //before start actions
    [SerializeField] private List<IAction> beforeStartActions;
    // start actions
    [SerializeField] private List<IAction> startActions;
    // progressionTrack
    [SerializeField] ProggresionType proggresionType;
    [SerializeField] private List<Observer> observers;
    // end actions
    [SerializeField] private List<IAction> EndActions;
    // after end actions
    [SerializeField] private List<IAction> afterEndActions;
}