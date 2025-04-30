using TMPro;
using UnityEngine;
abstract public class Entity : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DialogueSO dialogue;
    [SerializeField] private TMP_Text textDialogue;
    public void StartDialogue()
    { 
        dialogue.StartDialogues(textDialogue, this, TermDialogue);
    }
    protected abstract void TermDialogue();
}
