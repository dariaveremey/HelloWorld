using UnityEngine;
using UnityEngine.UI;

public class StartMagic : MonoBehaviour
{
    #region Variables

    public Button StartButton;
    public string StartLabel;

    #endregion


    #region Private methods

    private void Start()
    {
        StartButton.onClick.AddListener(StartButtonClicked);
    }

    private void StartButtonClicked()
    {
        SceneLoader.Instance.Load(StartLabel);
    }

    #endregion
}