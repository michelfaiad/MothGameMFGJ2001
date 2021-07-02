using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController inst;

    #region Editor Variables
    [Header("Object References")]
    [SerializeField] Slider healthSlider;
    #endregion

    #region Private Variables
    int maxHealth = 100;
    int health = 100;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
    }
    #endregion

    #region Custom Methods
    public void DamagePlayer(int damage)
    {
        if (health > 0)
            health -= damage;
    }

    public void HealPlayer(int life)
    {
        health += life;
        if (health > maxHealth)
            health = maxHealth;
    }
    #endregion
}
