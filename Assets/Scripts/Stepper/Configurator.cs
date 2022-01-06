using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum Instruments {
    ArmLeft,
    ArmRight,
    Konulia
}

[Serializable]
public class Step {
    public Animator animator;
    public List<Instruments> triggerInstruments;    
}

[ExecuteAlways]
public class Configurator : MonoBehaviour
{
    public Step newStep;
    public Transform referenceStep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateStep();
        }        
    }

    public void CreateStep() {
        var step = new Step();
        step.animator = newStep.animator;
        step.triggerInstruments = newStep.triggerInstruments;
        //

        var stepEntity = referenceStep.gameObject.AddComponent<StepEntity>();
        stepEntity.step = step;
    }
}
*/