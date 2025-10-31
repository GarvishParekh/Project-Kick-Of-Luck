using System.Collections;
using UnityEngine;

public class SlotSystem : MonoBehaviour
{
    [SerializeField] private Transform slot;
    [SerializeField] private float noOfRotation = 3;

    [SerializeField] private float rotationSpeed = 3;
    [SerializeField] private float stoppingSpeed = 300;

    [SerializeField] private float stopingPoint = 90;
    [SerializeField] private Vector3 rotationValue = Vector3.zero;

    private void Start()
    {
        StartCoroutine(nameof(StartRolling));
    }

    private IEnumerator StartRolling()
    {
        int rotationCount = 0;

        while (rotationCount <= noOfRotation)
        {

            if (rotationValue.x >= 360)
            {
                rotationCount += 1;
                rotationValue.x = 0;
            }

            rotationValue.x += Time.deltaTime * rotationSpeed;
            rotationValue.y = 0;
            rotationValue.z = 0;

            slot.localEulerAngles = (rotationValue);
            yield return null;
        }

        rotationCount = 0;
        while (rotationCount <= 2)
        {
            if (rotationSpeed > 100) rotationSpeed -= Time.deltaTime * stoppingSpeed;
            if (rotationValue.x >= 360)
            {
                rotationCount += 1;
                rotationValue.x = 0;
            }

            rotationValue.x += Time.deltaTime * rotationSpeed;
            rotationValue.y = 0;
            rotationValue.z = 0;

            slot.localEulerAngles = (rotationValue);
            yield return null;
        }

        while (rotationValue.x <= stopingPoint)
        {
            rotationValue.x += Time.deltaTime * rotationSpeed;
            rotationValue.y = 0;
            rotationValue.z = 0;

            slot.localEulerAngles = (rotationValue);
            yield return null;
        }
    }
}
