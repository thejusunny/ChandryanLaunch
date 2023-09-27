using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    [SerializeField] private SplineContainer _splineContainer;

    private Spline _spline;

    [SerializeField] private float _speed;

    private float _distance;
    // Start is called before the first frame update
    void Start()
    {
        _spline = _splineContainer.Spline;
    }

    // Update is called once per frame
    void Update()
    {
        if (_distance < _spline.GetLength())
        {
            float t = _distance / _spline.GetLength();
            transform.position =  _splineContainer.transform.TransformPoint(_spline.EvaluatePosition(t));
            Vector3 tangent = _spline.EvaluateTangent(t);
            //transform.rotation =  quaternion.LookRotation(transform.up, tangent);
            _distance += _speed * Time.deltaTime;
        }
    }
}
