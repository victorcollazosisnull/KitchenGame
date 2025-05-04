using System;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = ("DialogueSO"), menuName = ("Scriptable Objects/Dialogues/DialogueCuySO"))]
public class DialogueCuySO : DialogueSO
{
    [Header("AnimationState")]
    [SerializeField] private StateCuy stateAnimator;
    public StateCuy StateAnimator => stateAnimator;

    public override void StartDialogues(TMP_Text text, Entity runner, Action onFinish = null)
    {
        base.StartDialogues(text, runner, onFinish);
        CuyController cuy = runner as CuyController;
    }
}
public enum StateCuy
{
    Triste,
    Feliz
}

