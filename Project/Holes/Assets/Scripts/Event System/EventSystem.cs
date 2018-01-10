using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Callback = System.Action;

public class EventSystem : MonoBehaviour
{
	private List<Tuple3<EventType, IListener, Callback>> toRemove;

	// All the observers of all events
	private Dictionary<EventType, List<IListener>> listeners;

	void LateUpdate()
	{
		if (toRemove == null)
			return;
		foreach (Tuple3<EventType, IListener, Callback> tuple in toRemove)
		{
			if (tuple.first == EventType.NONE)
			{
				remove(tuple.second);
			}
			else
			{
				removeFrom(tuple.second, tuple.first);
			}

			if (tuple.third != null)
			{
				tuple.third();
			}
		}

		toRemove.Clear();
	}

	#region Singleton

	// The reference to the gameobject script
	public static EventSystem instance
	{
		get;
		private set;
	}

	void Awake()
	{
		// Enforces the singleton pattern
		if (EventSystem.instance != null)
		{
			Destroy(EventSystem.instance);
		}
		EventSystem.instance = this;

		this.initInstance();
	}

	void initInstance()
	{
		// Instaniate listener list
		this.listeners = new Dictionary<EventType, List<IListener>>();
		this.toRemove = new List<Tuple3<EventType, IListener, System.Action>>();
	}

	#endregion

	#region Static functions

	/*
		Subscribe an observer to a specfic event type
	*/
	public static void addListener(IListener _listener, EventType _eventType)
	{
		EventSystem.instance.add(_listener, _eventType);
	}

	/*
		Subscribe an observer to certain event types
	*/
	public static void addListener(IListener _listener, EventType[] _eventTypes)
	{
		foreach (EventType type in _eventTypes)
		{
			EventSystem.instance.add(_listener, type);
		}
	}

	/*
		Unsubscribe a listener from a specific event type
	*/
	public static void removeListenerFrom(IListener _listener, EventType _eventType, Callback _callBack)
	{
		//instance.removeFrom(_listener, _eventType);
		EventSystem.instance.toRemove.Add(new Tuple3<EventType, IListener, Callback>(_eventType, _listener, _callBack));
	}

	/*
		Unsubscribe a listener from all event types
	*/
	public static void removeListener(IListener _listener, Callback _callBack)
	{
		EventSystem.instance.toRemove.Add(new Tuple3<EventType, IListener, Callback>(EventType.NONE, _listener, _callBack));
	}


	/*
		Notify all observers of an event
	*/
	public static void dispatchEvent(Event _event)
	{
		EventSystem.instance.dispatch(_event);
	}

	#endregion

	#region Private functions

	/*
		Add an observer to the list of observers for a specific event type
	*/
	private void add(IListener _listener, EventType _eventType)
	{
		// Check if the map of event-lists contains the event
		if (!this.listeners.ContainsKey(_eventType))
		{
			// Does not contains, needs to be added
			this.listeners[_eventType] = new List<IListener>();
		}

		// Add the observer to the list of event observers
		this.listeners[_eventType].Add(_listener);
	}

	/*
		Remove an observer from the list of observers for a specific event type
	*/
	private void removeFrom(IListener _listener, EventType _eventType)
	{
		// Check if the event list exists and contains the observer
		if (this.listeners.ContainsKey(_eventType) &&
			this.listeners[_eventType].Contains(_listener))
		{
			this.removeFromMap(_eventType, _listener);
		}
	}

	/*
		Remove an observer from the list of observers for all of the event types
	*/
	private void remove(IListener listener)
	{
		// Iterating over the map of keys and calling removeFrom will cause the dictionary to be out of sync

		// So instead, lets cache what events are being watched,
		// and remove the observer from those without iterating over map

		List<EventType> eventTypesObservedBy = new List<EventType>();

		// Iterate over all possible keys and check to see if the observer is watching
		foreach (EventType eventType in listeners.Keys)
		{
			if (this.listeners[eventType].Contains(listener))
			{
				eventTypesObservedBy.Add(eventType);
			}
		}

		// Iterate over watched events and remove the listener from them
		foreach (EventType eventType in eventTypesObservedBy)
		{
			this.removeFromMap(eventType, listener);
		}

	}

	/*
		Notify all observers of an event
	*/
	private void dispatch(Event _event)
	{
		// Check if there are any observers watching this event
		if (this.listeners.ContainsKey(_event.type))
		{
			// If there are observers, notify them all
			foreach (IListener listener in this.listeners[_event.type])
			{
				// Notify the observer
				listener.handleEvent(_event);
			}
		}
	}

	// Remove an observer from the list under the eventType key
	private void removeFromMap(EventType eventType, IListener listener)
	{
		// Remove the observer
		this.listeners[eventType].Remove(listener);

		// Check to see if the list is now empty
		if (this.listeners[eventType].Count == 0)
		{
			// If empty, remove the list from the map of event-lists
			this.listeners.Remove(eventType);
		}
	}

	#endregion

}
