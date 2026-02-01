using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] private bool _isStanding;
    [SerializeField] private ForceMode2D _forceMode;

    public Vector2 _targetOffset;
    public float _forceValue;

    private void Awake()
    {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _isStanding)
        {
            var direction = new Vector2(transform.position.x + _targetOffset.x, transform.position.y + _targetOffset.y);

            _rigid.AddForce(_targetOffset * _forceValue, _forceMode);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _isStanding = true;

        _rigid.velocity = Vector2.zero;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isStanding = false;
    }
}
