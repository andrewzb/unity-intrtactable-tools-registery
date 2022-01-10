using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor;

public class Step : MonoBehaviour {
    [SerializeField] private AnimatorControler animatorControler;
    [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
    [SerializeField] private List<TriggerHandler> triggers;
    [SerializeField] private List<Instrument> instruments;
    [SerializeField] private UnityEvent OnActivateStepUnityEvent;
    [SerializeField] private UnityEvent OnDeactivateStepUnityEvent;

    public Action OnAnimationFinishAction;

    public void ActivateStep() {
        OnActivateStepUnityEvent?.Invoke();
        foreach (var trigger in triggers) {
            trigger.OnTrigerEnterAction += AnimationStart;
            trigger.SetAllowInstruments(instruments);
        }
        animatorControler.OnAnimationFinishAction += AnimationEnd;
        animatorControler.SetAnimationClip(runtimeAnimatorController);
    }

    public void DeactivateStep() {
        OnDeactivateStepUnityEvent?.Invoke();
        foreach (var trigger in triggers) {
            trigger.OnTrigerEnterAction -= AnimationEnd;
        }
        animatorControler.OnAnimationFinishAction -= AnimationEnd;
    }
    public void SetupStep() {
        triggers = transform.GetComponentsInChildren<TriggerHandler>().ToList();
        foreach (var trigger in triggers) {
            trigger.SetAllowInstruments(instruments);
        }
    }

    private void AnimationStart() {
        animatorControler.Play();
    }

    private void AnimationEnd() {
        OnAnimationFinishAction?.Invoke();
    }

    [MenuItem("3D sergery training/Generate step")]
    private static void GenerateStep() {
        var parent = GameObject.Find("Steps");
        if (parent == null) {
            var steps = new GameObject();
            steps.name = "Steps";
            parent = steps;
        }
        var step = new GameObject();
        step.name = "step";
        step.AddComponent<Step>();
        step.transform.parent = parent.transform;
    }
}
