using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class RocketController : MonoBehaviour
{
    [SerializeField] private SplineContainer _splineContainer;
    private float _distance;
    [SerializeField]private float _speed =2f;
    [SerializeField]private float _acceleration =2f;
    [SerializeField]private float _maxSpeed =10f;
    private Spline _spline;
    private bool _canFly;

    private Quaternion _startRotation;
    // Start is called before the first frame update
    void Start()
    {
        _startRotation = transform.rotation;
        _spline = _splineContainer.Spline;
        Debug.Log(_spline.GetLength());
        Launcher.LaunchSequenceCompleted += StartFlight;
    }

    private void StartFlight()
    {
        _canFly = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canFly)
        {
            if (Input.GetMouseButton(0))
            {
                _speed += _acceleration * Time.deltaTime;
            }
            else
            {
                _speed -= _acceleration * 0.3f * Time.deltaTime;
            }
            if (_distance < _spline.GetLength())
            {
                _distance += _speed * Time.deltaTime;
                float t = _distance / _spline.GetLength();
                transform.position = _splineContainer.transform.TransformPoint(_spline.EvaluatePosition(t));
                Vector3 tangent = _spline.EvaluateTangent(t);
                transform.rotation = quaternion.LookRotation(Vector3.forward, tangent.normalized);
            }
            _speed = Mathf.Min( Mathf.Max(_speed,2f), _maxSpeed);
        }
    }
    
}
