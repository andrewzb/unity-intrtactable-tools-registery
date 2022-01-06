using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {
    [SerializeField] private AnimatorControler animatorControler;
    [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
    [SerializeField] private List<TriggerHandler> triggers;
    [SerializeField] private List<Instrument> instruments;

    public Action OnAnimationFinishAction;

    public void ActivateStep() {
        foreach (var trigger in triggers) {
            trigger.OnTrigerEnterAction += AnimationStart;
            trigger.SetAllowInstruments(instruments);
        }
        animatorControler.OnAnimationFinishAction += AnimationEnd;
        animatorControler.SetAnimationClip(runtimeAnimatorController);
    }

    public void DeactivateStep() {
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
}
