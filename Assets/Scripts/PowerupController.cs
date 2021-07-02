using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    #region Editor Variables
    [Header("Powerup Configuration")]
    [Header("0 = Health / 1 = Speed")]
    [SerializeField] int type;
    [SerializeField] int value;
    [SerializeField] float duration;
    [Header("Movement Factor")]
    [SerializeField] [Range(0, 1)] float movementFactor;
    [Header("Movement Vector")]
    [SerializeField] Vector3 movementVector;
    [Header("Period")]
    [SerializeField] float period = 2f;
    #endregion

    #region Private Variables
    Vector3 initialPosition;
    #endregion

    #region Unity Methods
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;

        transform.position = initialPosition + offset;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (type)
            {
                case 0:
                    HealthController.inst.HealPlayer(value);
                    break;
                case 1:
                    GameParameters.inst.SpeedUp(value, duration);
                    break;
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
    #endregion


}
