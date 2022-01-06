using System.Collections.Generic;
using UnityEngine;

public class StepControler : MonoBehaviour {
    [SerializeField] private List<Step> steps;

    private Step currentStep;
    private int index = -1;

    private void Start() {
        ActivateNextstep();
    }

    private void ActivateNextstep() {
        if (currentStep != null) {
            currentStep.OnAnimationFinishAction -= ActivateNextstep;
            currentStep.DeactivateStep();
        }
        index++;
        if (index < steps.Count) {
            currentStep = steps[index];
            currentStep.ActivateStep();
            currentStep.OnAnimationFinishAction += ActivateNextstep;
        } else {
            Debug.Log("Sequence end");
        }
    }
}



















/*
public class StepControler : MonoBehaviour {
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private List<StepperDescriptor> stepperDescriptors;

    private int index = -1;
    private StepResources cachedResources;

    private void Start() {
        OnAnimationEnd();
    }

    private void OnAnimationStart() {
        cachedResources.AnimatorControler.Play();
    }

    private void OnAnimationEnd() {
        if (cachedResources.IsValid) {
            foreach (var trigger in cachedResources.TriggerHandlers) {
                trigger.OnTrigerEnterAction -= OnAnimationStart;
                trigger.CleanAllowInstruments();
            }
            cachedResources.AnimatorControler.OnAnimationFinishAction -= OnAnimationEnd;
        }
        index++;
        var descriptor = stepperDescriptors[index];
        cachedResources = resourceManager.Get(descriptor.AnimationControlerSelector,
            descriptor.AnimatedClipSelector,descriptor.TriggerSelectors, descriptor.InstrumentSelectors);
        var (AnimatorControler, RuntimeAnimatorController, TriggerHandlers, Instruments) = cachedResources;
        AnimatorControler.SetAnimationClip(RuntimeAnimatorController);
        foreach (var trigger in TriggerHandlers) {
            trigger.SetAllowInstruments(Instruments);
            trigger.OnTrigerEnterAction += OnAnimationStart;
        }
        cachedResources.AnimatorControler.OnAnimationFinishAction += OnAnimationEnd;
    }
}
*/