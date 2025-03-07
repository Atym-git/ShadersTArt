using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Wobble : MonoBehaviour
{
    private Renderer _renderer;
    private Vector3 _lastPos;
    private Vector3 _velocity;
    private Vector3 _lastRot;
    private Vector3 _angularVelocity;
    [SerializeField] private float _maxWobble = 0.03f;
    [SerializeField] private float _wobbleSpeed = 1f;
    [SerializeField] private float _recovery = 1f;

    private float _wobbleAmountX;
    private float _wobbleAmountZ;
    private float _wobbleAmountToAddX;
    private float _wobbleAmountToAddZ;
    private float _pulse;
    private float _time = 0.5f;

    private const string _shaderWobbleX = "_WobbleX";
    private const string _shaderWobbleZ = "_WobbleZ";

    private const float _clampModifier = 0.2f;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

    }

    private void Update()
    {
        _time = Time.deltaTime;

        _wobbleAmountToAddX = Mathf.Lerp(_wobbleAmountToAddX, 0, Time.deltaTime * _recovery);
        _wobbleAmountToAddZ = Mathf.Lerp(_wobbleAmountToAddZ, 0, Time.deltaTime * _recovery);


        _pulse = 2 * Mathf.PI * _wobbleSpeed;
        _wobbleAmountX = _wobbleAmountToAddX * Mathf.Sin(_pulse * _time);
        _wobbleAmountZ = _wobbleAmountToAddZ * Mathf.Sin(_pulse * _time);

        _renderer.material.SetFloat(_shaderWobbleX, _wobbleAmountX);
        _renderer.material.SetFloat(_shaderWobbleZ, _wobbleAmountZ);

        _velocity = (_lastPos - transform.position) / Time.deltaTime;
        _angularVelocity = transform.rotation.eulerAngles - _lastRot;



        _wobbleAmountToAddX += Mathf.Clamp((_velocity.x + (_angularVelocity.z * _clampModifier)) * _maxWobble, -_maxWobble, _maxWobble);
        _wobbleAmountToAddZ += Mathf.Clamp((_velocity.z + (_angularVelocity.x * _clampModifier)) * _maxWobble, -_maxWobble, _maxWobble);

        _lastPos = transform.position;
        _lastRot = transform.rotation.eulerAngles;
    }
}
