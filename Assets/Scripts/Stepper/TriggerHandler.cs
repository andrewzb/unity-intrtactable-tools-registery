using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {
    public Action OnTrigerEnterAction;

    [SerializeField] private List<Instrument> allowInstruments;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Instrument>(out var instrument)){
            if (allowInstruments.Contains(instrument)) {
                OnTrigerEnterAction?.Invoke();
            }
        }
    }

    public void SetAllowInstruments(List<Instrument> dallowInstruments) {
        var tempList = new List<Instrument>();
        foreach (var instrument in dallowInstruments) {
            tempList.Add(instrument);
        }
        this.allowInstruments = tempList;
    }
}
