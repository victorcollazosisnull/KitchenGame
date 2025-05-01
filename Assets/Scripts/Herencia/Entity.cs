using System;
using TMPro;
using UnityEngine;
abstract public class Entity : MonoBehaviour
{
    private Animator animator;

    [Header("Dialogue")]
    [SerializeField] private DialogueSO[] dialogue;
    [SerializeField] private TMP_Text textDialogue;
    [SerializeField] private GameObject Canvas;
    static public event Action EventTermDialogue;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected void StartDialogues(int index)
    { 
        Canvas.SetActive(true);
        dialogue[index].StartDialogues(textDialogue, this, TermDialogue);
    }
    protected virtual void TermDialogue()
    {
        Canvas.SetActive(true);
        ActiveEventTermDialogue();
    }
    protected void ActiveEventTermDialogue()
    {
        EventTermDialogue?.Invoke();
    }
    public void StateAnimation(string state)
    {
        animator.SetTrigger(state);
    }
}
