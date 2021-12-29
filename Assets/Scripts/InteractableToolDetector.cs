using System.Collections.Generic;
using UnityEngine;

public enum rangeType {
    cube,
    sphere
}

public class InteractableToolDetector<U> : MonoBehaviour where U : ToolInteractable {
    [Header("detection")]
    [SerializeField] private protected ToolGrabType grabType;
    [SerializeField] private protected ToolTrakingType trakingType;
    [SerializeField] private protected List<U> interactablesTool = new List<U>();

    [SerializeField] private protected bool isCubeRange;
    [Header("CubeRange")]
    [SerializeField] private protected Vector3 halphSize;
    [SerializeField] private protected Vector3 offset;
    [Header("sphereRange")]
    [SerializeField] private protected Vector4 offsetRadius;


    public virtual bool IsValidTool<T>(T tool) where T : ToolInteractable {
        //TODO norm Validation
        if (grabType == ToolGrabType.grabed) {
            if (!tool.IsGrabed) {
                return false;
            }
        }

        if (isCubeRange) {
            return !isInCube();
        }
        if (!isCubeRange) {
            return !isInCircle();
        }

        return true;
    }

    private bool isInCircle() {
        return false;
    }

    private bool isInCube() {
        return true;
    }

    private void OnDrawGizmos() {
        if (isCubeRange) {
            Gizmos.DrawWireCube(transform.position - offset, halphSize * 2);
        } else {
            Gizmos.DrawWireSphere(transform.position - (Vector3)offsetRadius, offsetRadius.w);
        }
    }
} 
