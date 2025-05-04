using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonLoadScene : MyButton
{
    [SerializeField] private string scene;
    protected override void OnClick()
    {
        StartScaningLoadScene();
    }
    private void StartScaningLoadScene()
    {
        UIManager.Instance.UpdateUI(scene);
        UIManager.Instance.StartScanningEnter(LoadScene);
    }
    private void LoadScene()
    {
        UIManager.Instance.StartScaningExit();
        SceneManager.LoadScene(scene);
    }
}
