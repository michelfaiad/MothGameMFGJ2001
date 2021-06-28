using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBehaviour : MonoBehaviour
{
    #region Editor Variables
    [Header("Bulb Configuration")]
    [SerializeField] float pullStrength = 70f;
    [SerializeField] bool alwaysOn;
    [Tooltip("Time the bulb stays off if not 'always on'")]
    [SerializeField] float timeOff = 1f;
    [SerializeField] Color onColor;
    [SerializeField] Color offColor;
    #endregion



    #region Unity Methods

    private void Start()
    {
        if(!alwaysOn)
            InvokeRepeating("SwitchBulb", timeOff, timeOff);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = transform.position - collision.transform.position;

            playerRB.AddForce(direction.normalized * (pullStrength + (1f * GameParameters.inst.Stage)), ForceMode2D.Force);
        }
    }
    #endregion

    #region Custom Methods

    void SwitchBulb()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.enabled = !collider.enabled;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (collider.enabled)
        {
            sprite.color = onColor;
        }
        else
        {
            sprite.color = offColor;
        }
    }


    #endregion

}
