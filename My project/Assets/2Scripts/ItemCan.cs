using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float RotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime, Space.World); // Rotate(Vector3): �Ű����� �������� ȸ����Ű�� �Լ�.
    }
}
