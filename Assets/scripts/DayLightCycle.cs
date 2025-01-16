using System.Collections;
using FunkyCode;
using UnityEngine;

public class DayLightCycle : MonoBehaviour
{
    [SerializeField] LightCycle _lightCycle;
    [SerializeField] int dayDuration;

    private float timeIncrement;
    private float totalSeconds;

    void Start()
    {
        if (_lightCycle == null)
        {
            Debug.LogError("LightCycle nie został przypisany!");
            return;
        }

        timeIncrement = 1f / dayDuration;

        StartCoroutine("DayCycle");
    }

    IEnumerator DayCycle()
    {
        _lightCycle.SetTime(0);

        while (_lightCycle.time < 1f)
        {
            _lightCycle.SetTime(_lightCycle.time + timeIncrement);
            yield return new WaitForSeconds(1f);
        }
    }
}
