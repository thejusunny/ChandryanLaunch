using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private float _secondsBeforeLaunch;
    [SerializeField] private TMP_Text _countDownText;
    [SerializeField]private float _timer;

    private bool _startLaunch = false;

    private bool _launched = false;

    public static event Action LaunchSequenceCompleted;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !_launched)
        {
            _startLaunch = true;
        }

        if (_startLaunch)
        {
            if (_timer <= _secondsBeforeLaunch+0.1f)
            {
                int time = (int)_secondsBeforeLaunch - (int)_timer;
                _countDownText.text = time.ToString();
                _timer += Time.deltaTime;
            }
            else
            {
                _startLaunch = false;
                _timer = 0f;
                _launched = true;
                LaunchSequenceCompleted?.Invoke();
            }
        }
    }
}
