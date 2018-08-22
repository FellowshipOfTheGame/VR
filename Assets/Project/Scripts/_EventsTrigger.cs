using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class _EventsTrigger {

	public static EventTrigger AddComponent(GameObject _gameObject) {
		EventTrigger _eventTrigger = _gameObject.AddComponent<EventTrigger> ();

		return _eventTrigger;
	}

	public static void AddEnterAndExit(EventTrigger _eventTrigger, MonoBehaviour _script) {
		AddNewEvent (_eventTrigger, EventTriggerType.PointerEnter, (BaseEventData) => {
			_script.enabled = true;
		});

		AddNewEvent (_eventTrigger, EventTriggerType.PointerExit, (BaseEventData) => {
			_script.enabled = false;
		});
	}

	public static void AddNewEvent(EventTrigger _eventTrigger, EventTriggerType _eventType, System.Action<BaseEventData> _callback) {
		EventTrigger.Entry _entry = new EventTrigger.Entry();
		_entry.eventID = _eventType;
		_entry.callback.AddListener (new UnityEngine.Events.UnityAction<BaseEventData> (_callback));
		_eventTrigger.triggers.Add (_entry);
	}

}