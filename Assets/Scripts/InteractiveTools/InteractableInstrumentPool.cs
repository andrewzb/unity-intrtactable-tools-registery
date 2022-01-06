using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


sealed class InteractableInstrumentPool : MonoBehaviour {
    public static InteractableInstrumentPool Instance { private set; get; }

    [SerializeField] private static List<SliceInteractable> sliceList = new List<SliceInteractable>();
    [SerializeField] private static List<NeedleInteractable> needleList = new List<NeedleInteractable>();

    [SerializeField] private SliceInteractable test;

    private void Awake() {
        if (!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this);
            return;
        }
    }

    public void Update() {
        Debug.Log($"sclie count => {sliceList.Count}");
        Debug.Log($"needleList count => {needleList.Count}");
    }

    #region
    public static void RegisterInteractivrTool<T>(T tool) where T : ToolInteractable {
        //Debug.Log($"RegisterInteractivrTool {tool.gameObject.name} {typeof(T)}");
        //Debug.Log($"RegisterInteractivrTool {typeof(T)}");
        if (typeof(T) == typeof(SliceInteractable)) {
            if (tool != null) {
                var localTool = tool as SliceInteractable;
                sliceList.Add(localTool);
            }
        } else if (typeof(T) == typeof(NeedleInteractable)) {
            if (tool != null) {
                var localTool = tool as NeedleInteractable;
                needleList.Add(localTool);
            }
        }
    }

    public static void UnregisterInteractivrTool<T>(T tool) where T : ToolInteractable {
        //Debug.Log($"UnregisterInteractivrTool {tool.gameObject.name}");
        //Debug.Log($"UnregisterInteractivrTool {typeof(T)}");
        if (typeof(T) == typeof(SliceInteractable)) {
            if (tool != null) {
                var localTool = tool as SliceInteractable;
                sliceList.Remove(localTool);
            }
        } else if (typeof(T) == typeof(NeedleInteractable)) {
            if (tool != null) {
                var localTool = tool as NeedleInteractable;
                needleList.Remove(localTool);
            }
        }
    }

    public static bool IsRegistred<T>(T tool) where T : ToolInteractable {
        if (typeof(T) == typeof(SliceInteractable)) {
            if (tool != null) {
                var localTool = tool as SliceInteractable;
                return sliceList.Contains(localTool);
            }
        } else if (typeof(T) == typeof(NeedleInteractable)) {
            if (tool != null) {
                var localTool = tool as NeedleInteractable;
                return needleList.Contains(localTool);
            }
        }
        return false;
    }

    public static List<T> GetInteractiveTool<T>(InteractableToolDetector<T> toolDetector) where T : ToolInteractable {
        //return sliceList.FindAll((tool) => toolDetector.IsValidTool(tool)) as List<T>;
        if (typeof(T) == typeof(SliceInteractable)) {
            return sliceList.FindAll((tool) => toolDetector.IsValidTool(tool)) as List<T>;
        } else if (typeof(T) == typeof(NeedleInteractable)) {
            return needleList.FindAll((tool) => toolDetector.IsValidTool(tool)) as List<T>;
        }
        return new List<T>();
    }

    /*
    public static List<T> GetInteractiveTool<T>(Predicate<T> predicate) where T : ToolInteractable {
        if (typeof(T) == typeof(SliceInteractable)) {
            var castPredicate = predicate as Predicate<SliceInteractable>;
            return sliceList.FindAll(castPredicate) as List<T>;
        } else if (typeof(T) == typeof(NeedleInteractable)) {
            var castPredicate = predicate as Predicate<NeedleInteractable>;
            return needleList.FindAll(castPredicate) as List<T>;
        }
        return new List<T>();
    }
    */
    #endregion

    #region Api
    /*
    public static void RegisterInteractivrTool<T>(T tool) where T : SliceInteractable {
        if (tool != null) {
            var localTool = tool;
            sliceList.Add(localTool);
        }
    }

    public static void UnregisterInteractivrTool<T>(T tool) where T : SliceInteractable {
        if (tool != null) {
            var localTool = tool;
            sliceList.Remove(localTool);
        }
    }

    public static bool IsRegistred<T>(T tool) {
        return false;
    }

    public static bool GetInteractivrTool<T>(out T result) where T : SliceInteractable {
        result = (T)sliceList[0];
        return true;
    }
    */
    #endregion

    public void RegisterInstrument(ToolInteractable tool, TypeInteractable type) {

    }

    private void InitializeManager() {

    }
}

