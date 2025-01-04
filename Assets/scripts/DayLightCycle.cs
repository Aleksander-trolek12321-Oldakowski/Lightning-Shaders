using System.Collections;
using FunkyCode;
using UnityEngine;

public class DayLightCycle : MonoBehaviour
{
    [SerializeField] LightCycle _lightCycle;
    [SerializeField] int StartDay = 6;
    [SerializeField] int EndDay = 18;

    private float timeIncrement;
    private float totalSeconds;

    void Start()
    {
        if (_lightCycle == null)
        {
            Debug.LogError("LightCycle nie został przypisany!");
            return;
        }

        int dayDurationInHours = EndDay - StartDay;
        if (dayDurationInHours <= 0)
        {
            Debug.LogError("Koniec dnia musi być późniejszy niż początek dnia!");
            return;
        }

        totalSeconds = dayDurationInHours * 60f;
        timeIncrement = 1f / totalSeconds;

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
