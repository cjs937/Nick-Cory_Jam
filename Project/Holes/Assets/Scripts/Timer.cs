using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    Dictionary<string, float> currentTimers;
    List<string> pausedTimers;

    public Timer()
    {
        currentTimers = new Dictionary<string, float>();
        pausedTimers = new List<string>();
    }

    // Update is called once per frame
    public void update (float _dt)
    {
        List<string> tags = new List<string>(currentTimers.Keys);

		foreach(string timerTag in tags)
        {
            if (pausedTimers.Contains(timerTag))
                continue;

            if (currentTimers[timerTag] != 0)
                currentTimers[timerTag] = Mathf.Max(0, currentTimers[timerTag] - _dt);
        }
    }

    public bool addTimer(string _timerTag)
    {
        if (hasTimer(_timerTag))
            return false;

        currentTimers.Add(_timerTag, 0.0f);

        return true;
    }

    public bool startTimer(string _timerTag, float _timerLength)
    {
        if (!hasTimer(_timerTag))
            currentTimers.Add(_timerTag, _timerLength);
        else
            currentTimers[_timerTag] = _timerLength;

        return true;
    }

    public bool checkIfCompleted(string _timerTag, bool _deleteIfComplete = false)
    {
        if (!hasTimer(_timerTag))
        {
            Debug.LogWarning("Timer " + _timerTag + " does not exist");

            return true;
        }

        if (currentTimers[_timerTag] == 0)
        {
            if (_deleteIfComplete)
                removeTimer(_timerTag);

            return true;
        }

        return false;
    }

    public void pauseTimer(string _tag)
    {
        if (!hasTimer(_tag) || pausedTimers.Contains(_tag))
            return;

        pausedTimers.Add(_tag);
    }

    public void unpauseTimer(string _tag)
    {
        pausedTimers.Remove(_tag);
    }

    public void stopTimer(string _timerTag)
    {
        if (!hasTimer(_timerTag))
        {
            return;
        }

        currentTimers[_timerTag] = 0.0f;
    }

    public void removeTimer(string _timerTag)
    {
        currentTimers.Remove(_timerTag);

        pausedTimers.Remove(_timerTag);
    }

    public bool hasTimer(string _tag)
    {
        return currentTimers.ContainsKey(_tag);
    }
}
