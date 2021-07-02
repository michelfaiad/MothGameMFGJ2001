using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBehaviour : MonoBehaviour
{
    #region Editor Variables
    [Header("Bulb Configuration")]
    [SerializeField] float pullStrength = 70f;
    [SerializeField] float knockBack = 10f;
    [SerializeField] int damage = 20;
    [SerializeField] bool alwaysOn;
    [Tooltip("Time the bulb stays off if not 'always on'")]
    [SerializeField] float timeOff = 1f;
    [SerializeField] GameObject bulbLight;
    #endregion

    #region Private Variables
    bool isOn;
    #endregion

    #region Unity Methods

    private void Start()
    {
        isOn = true;

        if (!alwaysOn)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.transform.position - transform.position;

            playerRB.AddForce(direction.normalized * knockBack, ForceMode2D.Impulse);
            HealthController.inst.DamagePlayer(damage + (5 * GameParameters.inst.Stage));
        }
    }
    #endregion

    #region Custom Methods

    void SwitchBulb()
    {
        isOn = !isOn;
        CircleCollider2D[] colliders = GetComponents<CircleCollider2D>();
        foreach (CircleCollider2D collider in colliders)
        {
            collider.enabled = !collider.enabled;
        }
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (isOn)
        {
            bulbLight.SetActive(true);
        }
        else
        {
            bulbLight.SetActive(false);
        }
    }


    #endregion

}
