using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WinMagic : MonoBehaviour
{
    #region Variables

    public Button PlayAgainButton;
    public Button ExitButton;
    public string PlayAgainLabel;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        PlayAgainButton.onClick.AddListener(PlayAgainButtonClicked);
        ExitButton.onClick.AddListener(ExitButtonClicked);
    }

    #endregion


    #region Private methods

    private void PlayAgainButtonClicked()
    {
        SceneLoader.Instance.Load(PlayAgainLabel);
    }

    private void ExitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    #endregion
}