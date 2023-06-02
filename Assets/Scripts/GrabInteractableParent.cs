using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInteractableParent : MonoBehaviour
{
    public void SetToInteractor(SelectEnterEventArgs args)
    {
        transform.SetParent(args.interactorObject.transform);
    }

    public void SetToWorld()
    {
        transform.SetParent(null);
        transform.localScale = Vector3.one;
    }
}