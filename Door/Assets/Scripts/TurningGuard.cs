using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningGuard : MonoBehaviour
{
    [System.Serializable]
    public class Turn
    {
        public float TargetAngle;
        public float TurnSpeed;
        public float PreWait;
        public bool Clockwise;
    }

    public Rigidbody rb;
    public Transform trans;
    public bool KeepCounting = false;
    public int CurrentTurn;
    public Turn[] TurnList;
    
    public float _timer = 0f;
    private bool _spunOut = false;

    private void OnEnable()
    {
        if (_timer == 0f)
            _timer = TurnList[CurrentTurn].PreWait;
    }
    private void FixedUpdate()
    {
        if (!_spunOut)
        {
            if (_timer > 0f)
            {
                _timer -= Time.fixedDeltaTime;
            }
            else
            {
                if(KeepCounting)
                {
                    _timer -= Time.fixedDeltaTime;
                }
                Turn current = TurnList[CurrentTurn];
                float angle = AngularDifference();
                float direction;
                if (current.Clockwise)
                {
                    direction = 1f;
                }
                else
                {
                    direction = -1f;
                }

                if (angle < current.TurnSpeed * Time.fixedDeltaTime)
                {
                    trans.eulerAngles = new Vector3(0f, current.TargetAngle, 0f);
                    rb.angularVelocity = Vector3.zero;
                    Increment();
                    _timer += TurnList[CurrentTurn].PreWait;
                }
                else
                {
                    rb.angularVelocity = new Vector3(0f, current.TurnSpeed * direction, 0f);
                }
            }
        }
    }

    private void Increment()
    {
        CurrentTurn++;
        if(CurrentTurn == TurnList.Length)
        {
            CurrentTurn = 0;
        }
    }
    private float AngularDifference()
    {
        Turn current = TurnList[CurrentTurn];
        float angle;
        if(current.Clockwise)
        {
            if(trans.rotation.eulerAngles.y > current.TargetAngle)
            {
                angle = current.TargetAngle - trans.rotation.eulerAngles.y + 360f;
            }
            else
            {
                angle = current.TargetAngle - trans.rotation.eulerAngles.y;
            }
        }
        else
        {
            if (trans.rotation.eulerAngles.y < current.TargetAngle)
            {
                angle = current.TargetAngle - trans.rotation.eulerAngles.y + 360f;
            }
            else
            {
                angle = current.TargetAngle - trans.rotation.eulerAngles.y;
            }
            angle *= -1f;
        }
        angle *= Mathf.PI / 180f;
        return angle;
    }
    public void SpinOut()
    {
        _spunOut = true;
    }
}
