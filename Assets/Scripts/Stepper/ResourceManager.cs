using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct StepResources {
    public StepResources(AnimatorControler animatorControler, RuntimeAnimatorController runtimerAnimationControlers,
        List<TriggerHandler> triggerHandlers, List<Instrument> instruments) {
        this.animatorControler = animatorControler;
        this.runtimerAnimationControlers = runtimerAnimationControlers;
        this.triggerHandlers = triggerHandlers;
        this.instruments = instruments;
        isValid = true;
        
    }
    private bool isValid;
    private AnimatorControler animatorControler;
    private RuntimeAnimatorController runtimerAnimationControlers;
    private List<TriggerHandler> triggerHandlers;
    private List<Instrument> instruments;

    public bool IsValid => isValid;
    public AnimatorControler AnimatorControler => animatorControler;
    public RuntimeAnimatorController RuntimeAnimatorController => runtimerAnimationControlers;
    public List<TriggerHandler> TriggerHandlers => triggerHandlers;
    public List<Instrument> Instruments => instruments;


    public void Deconstruct(out AnimatorControler AnimatorControler,
        out RuntimeAnimatorController RuntimeAnimatorController,
        out List<TriggerHandler> TriggerHandlers,
        out List<Instrument> Instruments) {
        AnimatorControler = this.AnimatorControler;
        RuntimeAnimatorController = this.RuntimeAnimatorController;
        TriggerHandlers = this.TriggerHandlers;
        Instruments = this.Instruments;
    }
}

public class ResourceManager : MonoBehaviour {
    [SerializeField] private List<AnimatorControler> animatorControlers;
    [SerializeField] private List<RuntimeAnimatorController> runtimerAnimationControlers;
    [SerializeField] private List<TriggerHandler> triggers;
    [SerializeField] private List<Instrument> instruments;


    public StepResources Get(string animationControlerSelector, string runtimeAnimationControlerSelector,
        List<string> triggerSelectors, List<string> instrumeSelectors) {

        var animatorControlerIndex = animatorControlers.FindIndex(
            (el) => el.name == animationControlerSelector);
        var runtimeAnimationControlerSelectorIndex = runtimerAnimationControlers.FindIndex(
            (el) => el.name == runtimeAnimationControlerSelector);
        var triggersPool = triggers.FindAll((el) => triggerSelectors.Contains(el.name));
        var instrumentsPool = instruments.FindAll((el) => instrumeSelectors.Contains(el.name));
        if (animatorControlerIndex == -1 || runtimeAnimationControlerSelectorIndex == -1
            || triggersPool.Count == 0 || instrumentsPool.Count == 0) {
            throw new System.Exception("Cant find search items in resource manager");
        }

        return new StepResources(animatorControlers[animatorControlerIndex],
            runtimerAnimationControlers[runtimeAnimationControlerSelectorIndex], triggersPool, instrumentsPool);
    }

    [ContextMenu("find all")]
    private void FindAllRefs() {
        triggers = FindObjectsOfType<TriggerHandler>().ToList();
        instruments = FindObjectsOfType<Instrument>().ToList();
        animatorControlers = FindObjectsOfType<AnimatorControler>().ToList();
    }

}
