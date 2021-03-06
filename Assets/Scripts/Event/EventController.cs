﻿/*
 * Author(s): Isaiah Mann 
 * Description: A single event class that others can subscribe to and call events from
 * Currently relies on event names as strings
 * Event method can be overloaded to implement different event types
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventController : SingletonController<EventController> 
{
	#region Event Types

	public delegate void NamedEventAction(string nameOfEvent);
	public event NamedEventAction OnNamedEvent;

    public delegate void NamedEventActionWithID(string nameOfEvent, string id);
    public event NamedEventActionWithID OnNamedEventWithID;

	public delegate void NamedFloatAction(string valueKey, float key);
	public event NamedFloatAction OnNamedFloatEvent;

	public delegate void AudioEventAction(AudioActionType actionType, AudioType audioType);
	public event AudioEventAction OnAudioEvent;

	#endregion

	#region Event Subscription

	public static void Subscribe(NamedEventAction eventAction) 
	{
		if(hasInstance) 
		{
			Instance.OnNamedEvent += eventAction;
		}
	}

    public static void Subscribe(NamedEventActionWithID eventAction)
    {
        if(hasInstance)
        {
            Instance.OnNamedEventWithID += eventAction;
        }
    }

	public static void Subscribe(NamedFloatAction eventAction) 
	{
		if(hasInstance) 
		{
			Instance.OnNamedFloatEvent += eventAction;
		}
	}

	public static void Subscribe(AudioEventAction eventAction) 
	{
		if(hasInstance) 
		{
			Instance.OnAudioEvent += eventAction;
		}
	}

	public static void Unsubscribe(NamedEventAction eventAction) 
	{
		if(hasInstance) 
		{
			Instance.OnNamedEvent -= eventAction;
		}
	}

    public static void Unsubscribe(NamedEventActionWithID eventAction)
    {
        if (hasInstance)
        {
            Instance.OnNamedEventWithID -= eventAction;
        }
    }

    public static void Unsubscribe(NamedFloatAction eventAction) 
	{
		if(hasInstance) 
		{
			Instance.OnNamedFloatEvent -= eventAction;
		}
	}

	public static void Unsubscribe(AudioEventAction eventAction) 
	{
		if(hasInstance) 
		{
			Instance.OnAudioEvent -= eventAction;
		}
	}

	#endregion

	#region Event Calls

	public static void Event(string eventName, bool isCallback = false) 
	{
		if(hasInstance) 
		{
			if(Instance.OnNamedEvent != null) 
			{
				Instance.OnNamedEvent(eventName);
			}
		}
	}

    public static void Event(string eventName, string id, bool isCallback = false)
    {
        if (hasInstance)
        {
            if (Instance.OnNamedEventWithID != null)
            {
                Instance.OnNamedEventWithID(eventName, id);
            }
        }
    }

    public static void Event(string valueKey, float value) 
	{
		if(hasInstance && Instance.OnNamedFloatEvent != null) 
		{
			Instance.OnNamedFloatEvent(valueKey, value);
		}
	}

    public static void Event(AudioActionType actionType, AudioType audioType) 
	{
		if(hasInstance && Instance.OnAudioEvent != null) 
		{
			Instance.OnAudioEvent(actionType, audioType);
        }
    }
		
	#endregion

}
