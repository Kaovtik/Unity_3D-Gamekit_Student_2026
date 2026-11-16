using UnityEngine;
using FMOD.Studio;
using FMODUnity;

[CreateAssetMenu(fileName = "InteractableAudio", menuName = "Scriptable Objects/InteractableAudio")]
public class InteractableAudio : ScriptableObject
{
    //Declares a EventReference that holds a reference to our specific event
    [SerializeField] private EventReference pickupHealthAudio, boxDestroyAudio, switchAudio, doorAudio, pressurePlateAudio;

    //Declares a method that should play the pickupHealth sound without any 3D-positioning
    public void PickupHealthPlay()
    {
        /*PlayOneShot is used for 2D audio that doesn't follow an object when played,
        PlayOneShotAttached follows the object making sound when moving - so use it for 3D sounds*/
        RuntimeManager.PlayOneShot(pickupHealthAudio);
    }
    
    public void BoxDestroyPlay()
    {
        RuntimeManager.PlayOneShot(boxDestroyAudio);
    }
}
