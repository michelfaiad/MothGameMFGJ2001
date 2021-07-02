using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothController : MonoBehaviour
{
    #region Editor Variables
    [Header("Moth Movement Config")]
    [SerializeField] float flapStrength = 30f;
    [SerializeField] float fowardStrength = 20f;
    [SerializeField] float flapRate = 0.3f;
    #endregion

    #region Private Variables
    Rigidbody2D _rb;
    bool _flapping;
    Vector2 _flapDirection;
    float minY = -13f;
    float maxY = 13f;
    #endregion

    #region Unity Methods
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_flapping && (transform.position.y > minY && transform.position.y < maxY))
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
            StartCoroutine(Flap());
        }
        if (transform.position.y < minY)
        {
            _rb.AddForce(Vector2.up * flapStrength, ForceMode2D.Impulse);
        }
        else if(transform.position.y > maxY)
        {
            _rb.AddForce(Vector2.down * flapStrength, ForceMode2D.Impulse);
        }
    }

    IEnumerator Flap()
    {
        _rb.AddForce(_flapDirection * flapStrength, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.right * fowardStrength, ForceMode2D.Impulse);

        yield return new WaitForSeconds(flapRate);

        _flapping = false;
    }
    #endregion

    #region Custom Methods

    #endregion
}
