using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteriorationObject : MonoBehaviour
{
    public float minTimeDeterioration = 5f;
    public float maxTimeDeterioration = 7f;

    private float _nextTime;
    private float _restTime;

    private void Start()
    {
        StartDeterioration();
    }

    private void StartDeterioration()
    {
        _restTime = 0;
        _nextTime = Random.Range(minTimeDeterioration, maxTimeDeterioration);
    }

    private void Update()
    {
        _restTime += Time.deltaTime;

        if (_restTime > _nextTime)
        {
            StartDeterioration();
        }
    }
}