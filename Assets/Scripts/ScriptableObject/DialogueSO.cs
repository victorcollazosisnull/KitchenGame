using UnityEngine;
[CreateAssetMenu(fileName =("DialogueSO"),menuName =("Scriptable Objects/Dialogues/Dialogue"))]
public class DialogueSO : ScriptableObject
{
    [SerializeField] private string[] dialogues;
    public string[] Dialogues => dialogues;
}
