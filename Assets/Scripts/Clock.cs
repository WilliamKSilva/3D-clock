using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    float speed = 1.0f;
    float minutesTimer = 0.0f;

    int minutesToUpdateHours = 0;

    float hoursToDegrees = -30f;
    float minutesToDegrees = -6f;
    float secondsToDegrees = -6f;

    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    [SerializeField]
    bool startFromCurrentTime;

    void updateFromZero()
    {
        // Update seconds
        // We also could use Quaternion.Euler(0, 0, -30) to deal with the rotation
        secondsPivot.rotation *= Quaternion.AngleAxis(secondsToDegrees * Time.deltaTime * speed, Vector3.forward);
        minutesTimer += Time.deltaTime * speed;

        // Update minutes
        if (minutesTimer >= 60.0f)
        {
            minutesTimer = 0.0f;
            minutesToUpdateHours += 1;
            minutesPivot.rotation *= Quaternion.AngleAxis(minutesToDegrees, Vector3.forward);
        }

        // Update hours
        if (minutesToUpdateHours >= 12)
        {
            minutesToUpdateHours = 0;
            hoursPivot.rotation *= Quaternion.AngleAxis(hoursToDegrees, Vector3.forward);
        }
    }

    void updateFromCurrentTime() {
        // Local rotation is relative to the parent object
        DateTime time = DateTime.Now;
        int hour = time.Hour;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hour * hoursToDegrees);

        int minute = time.Minute;
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minute * minutesToDegrees);

        int seconds = time.Second;
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, seconds * secondsToDegrees);
    }

    void Update()
    {
        if (startFromCurrentTime) {
            updateFromCurrentTime();
        } else {
            updateFromZero();
        }
    }
}