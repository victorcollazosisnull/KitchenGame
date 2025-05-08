using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonLoadScene : MyButton
{
    [SerializeField] private string scene;
    protected override void OnClick()
    {
        if (interative)
        {
            StartScaningLoadScene();
            interative = false;
        }
    }
    private void StartScaningLoadScene()
    {
        UIManager.Instance.StartScanningEnter(LoadScene);
    }
    private void LoadScene()
    {
        UIManager.Instance.UpdateUI(scene);
        UIManager.Instance.StartScaningExit(ResetValue);
        SceneManager.LoadScene(scene);
    }
    private void ResetValue()
    {
        interative = true;
    }
}
