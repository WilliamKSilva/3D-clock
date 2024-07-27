using UnityEngine;

public class Clock : MonoBehaviour {
    float speed = 1.0f;
    float angle = 6.0f;
    float minutesTimer = 0.0f;

    int minutesToUpdateHours = 0;

    [SerializeField]
    Transform hoursPivot,  minutesPivot, secondsPivot;

    void Update() {
        // Update seconds
        secondsPivot.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime * speed, -Vector3.forward);
        minutesTimer += Time.deltaTime * speed;

        // Update minutes
        if (minutesTimer >= 60.0f) {
            minutesTimer = 0.0f;
            minutesToUpdateHours += 1;
            minutesPivot.rotation *= Quaternion.AngleAxis(angle, -Vector3.forward);
        }

        // Update hours
        if (minutesToUpdateHours >= 12) {
            minutesToUpdateHours = 0;
            hoursPivot.rotation *= Quaternion.AngleAxis(angle, -Vector3.forward);
        }
    }
}