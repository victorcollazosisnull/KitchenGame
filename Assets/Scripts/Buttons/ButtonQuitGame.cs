using UnityEngine;

public class ButtonQuitGame : MyButton
{
    protected override void OnClick()
    {
        Application.Quit();
        Debug.Log("Se cerro el Juego");
    }
}
