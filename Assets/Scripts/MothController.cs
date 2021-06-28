using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothController : MonoBehaviour
{
    #region Editor Variables
    [Header("Moth Movement Config")]
    [SerializeField] float flapStrength = 20f;
    #endregion

    #region Private Variables
    Rigidbody2D _rb;
    bool _flapping;
    Vector2 _flapDirection;
    #endregion

    #region Unity Methods
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_flapping)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                //Move Up
                _flapDirection = Vector2.up;
                _flapping = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                //Move Down
                _flapDirection = Vector2.down;
                _flapping = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (_flapping)
        {
            _rb.AddForce(_flapDirection * flapStrength, ForceMode2D.Impulse);
            _flapping = false;
        }
    }
    #endregion

    #region Custom Methods

    #endregion
}
