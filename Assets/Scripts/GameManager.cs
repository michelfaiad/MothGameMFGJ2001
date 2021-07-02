using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    #region Editor Variables
    [SerializeField] TextMeshProUGUI stageTxt;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        FadeController.inst.FadeFromBlack();
    }

    void Start()
    {
        FadeController.inst.FadeFromBlack();
    }

    private void Update()
    {
        if (stageTxt != null)
            stageTxt.text = GameParameters.inst.Stage.ToString();
    }
    #endregion

    #region Custom Methods
    public void NextStage()
    {
        GameParameters parameters = GameParameters.inst;

        parameters.Stage++;
        parameters.StageSpeed++;
        if (parameters.Stage % 3 == 0)
        {
            parameters.MaxSpawnedBulbs++;
        }
        StartCoroutine(FadeAndLoadStage());
    }

    public void StartGame()
    {
        StartCoroutine(FadeAndLoadStage());
    }

    IEnumerator FadeAndLoadStage()
    {
        FadeController.inst.FadeToBlack();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    #endregion

}
