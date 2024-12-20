using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using Photon.Pun;

[RequireComponent(typeof(XRGrabInteractable))]
public class XRGrabbable : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public  UnityEvent grabEvent;
    public  UnityEvent releaseEvent;
    
    public bool usePrivate = false;
    private BlockHit bh;
    
    private void Awake()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register grab and release event listeners
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        
        if (usePrivate){
		bh = GetComponent<BlockHit>();
	}
    }

    private void OnDestroy()
    {
        // Unregister event listeners
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Logic to execute when the object is grabbed
        Debug.Log($"{gameObject.name} grabbed by {args.interactorObject.transform.name}");
        grabEvent.Invoke();
        if (usePrivate){
		bh.DisableCollider();
		PhotonView photonView = GetComponent<PhotonView>();
		if (photonView != null && !photonView.IsMine)
        	{
                photonView.RequestOwnership();
        	}
	}
        
    }

    private void OnRelease(SelectExitEventArgs args)
    {
    	releaseEvent.Invoke();
        // Logic to execute when the object is released
        Debug.Log($"{gameObject.name} released by {args.interactorObject.transform.name}");
        if (usePrivate){
		bh.EnableCollider();
	}
    }
}

