using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VolumeTrigger : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public UnityEvent TriggerEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target)
        {
            TriggerEnter.Invoke();
        }
    }
}
