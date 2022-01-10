using System;
using System.Collections.Generic;
using UnityEngine;

public class StepControler : MonoBehaviour {
    [SerializeField] private List<Step> steps;

    public Action OnStepEndAction;
    public Action OnStepSequenceEndAction;

    public int StepCount => steps.Count;
    public int StepIndex => index;

    private Step currentStep;
    private int index = -1;

    private void Start() {
        SetStep(0);
        ActivateStep();
    }

    private void ActivateNextstep() {
        if (currentStep != null) {
            currentStep.OnAnimationFinishAction -= ActivateNextstep;
            currentStep.DeactivateStep();
            OnStepEndAction?.Invoke();
        }
        index++;
        if (index < steps.Count) {
            currentStep = steps[index];
            currentStep.ActivateStep();
            currentStep.OnAnimationFinishAction += ActivateNextstep;
        } else {
            OnStepSequenceEndAction?.Invoke();
        }
    }

    public void ActivateStep() {
        if (index < steps.Count) {
            currentStep = steps[index];
            currentStep.ActivateStep();
            currentStep.OnAnimationFinishAction += ActivateNextstep;
        }
    }

    public void SetStep(int index) {
        if (currentStep != null) {
            currentStep.OnAnimationFinishAction -= ActivateNextstep;
            currentStep.DeactivateStep();
            currentStep = null;
        }
        this.index = index;
    }
}
