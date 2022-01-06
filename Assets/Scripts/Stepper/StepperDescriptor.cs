using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StepperDescriptor", menuName = "ScriptableObjects/StepperDescriptor", order = 1)]
public class StepperDescriptor : ScriptableObject {
    [SerializeField] private string animationControlerSelector;
    [SerializeField] private string animatedClipSelector;
    [SerializeField] private List<string> triggerSelectors;
    [SerializeField] private List<string> instrumentSelectors;

    public string AnimationControlerSelector => animationControlerSelector;
    public string AnimatedClipSelector => animatedClipSelector;
    public List<string> TriggerSelectors => triggerSelectors;
    public List<string> InstrumentSelectors => instrumentSelectors;
}
