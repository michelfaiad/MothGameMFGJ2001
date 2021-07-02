using System.Collections;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    public static GameParameters inst;

    #region Private Variables
    float stageSpeed = 7f;
    float stageNormalSpeed = 7f;
    int maxSpawnedBulbs = 2;
    int maxSpawnedPowerups = 1;
    int stage = 1;
    #endregion

    #region Properties
    public float StageSpeed { get => stageSpeed; set => stageSpeed = value; }
    public int MaxSpawnedBulbs { get => maxSpawnedBulbs; set => maxSpawnedBulbs = value; }
    public int Stage { get => stage; set => stage = value; }
    public int MaxSpawnedPowerups { get => maxSpawnedPowerups; set => maxSpawnedPowerups = value; }
    #endregion

    #region Unity Methods

    void Awake()
    {
        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Custom Methods
    public void SpeedUp(float multiplier, float time)
    {
        StartCoroutine(SpeedUpRoutine(multiplier, time));
    }

    IEnumerator SpeedUpRoutine(float multiplier, float time)
    {
        StopCoroutine("SpeedUpRoutine");
        GameParameters.inst.StageSpeed = stageNormalSpeed;
        GameParameters.inst.StageSpeed *= multiplier;
        yield return new WaitForSeconds(time);
        GameParameters.inst.StageSpeed = stageNormalSpeed;
    }
    #endregion
}
