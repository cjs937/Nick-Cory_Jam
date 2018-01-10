using UnityEngine;

// Indicator for classes which listen for events
public interface IListener
{
    void handleEvent(Event _event);
}

//If an object should listen to multiple events make it an EventListener
public abstract class EventListener : MonoBehaviour, IListener
{
    [HideInInspector]
    public EventType[] eventTypes = null;

    public virtual void Start()
    {
        if (eventTypes != null)
        {
            EventSystem.addListener(this, eventTypes);
        }
        else
        {
            Debug.Log("eventTypes is set to null");
        }
    }

    public abstract void handleEvent(Event _event);

}
