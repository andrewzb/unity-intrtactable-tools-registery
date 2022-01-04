using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Watcher : MonoBehaviour {

}

public class ProgreesWatcher {
    public ProgreesWatcher(List<Watcher> watcherColection, ProggresionType proggresionType) {
        this.watcherColection = watcherColection;
        this.proggresionType = proggresionType;
    }

    private List<Watcher> watcherColection;
    private ProggresionType proggresionType;
}


public class ChapterControler {
    public ChapterControler() {

    }
}

public class ChapterContinuityController : MonoBehaviour {
    [SerializeField] private ChapterContinuity chapterContinuity;


}
