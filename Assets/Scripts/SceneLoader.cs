using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Variables

    public string ScreenLoader;
    private static SceneLoader _instance;
    public static SceneLoader Instance => _instance;

    #endregion


    #region Unity lifecycle

    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    #region Public methods

    public void Load(string sceneName)
    {
        ScreenLoader = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}