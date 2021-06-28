using UnityEngine;

public class GameParameters : MonoBehaviour
{
    public static GameParameters inst;

    #region Private Variables
    float stageSpeed = 5f;
    int maxSpawnedBulbs = 2;
    int stage = 1;
    #endregion

    #region Properties
    public float StageSpeed { get => stageSpeed; set => stageSpeed = value; }
    public int MaxSpawnedBulbs { get => maxSpawnedBulbs; set => maxSpawnedBulbs = value; }
    public int Stage { get => stage; set => stage = value; }
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
}
