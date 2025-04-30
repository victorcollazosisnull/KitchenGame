using UnityEngine;

public class MarckController : Entity
{
    private State stateMarck;
    private Animator animator;
    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }
    public void StartDialogue(int index)
    {
        //CheckState();
        StartDialogues(index);
    }
    private void CheckState()
    {
        switch (stateMarck)
        {
            case State.triste:
                StateAnimation("Triste");
                break;
            case State.sorprendido:
                StateAnimation("Sorprendido");
                break;
        }
    }
    private void StateAnimation(string state)
    {
        animator.SetTrigger(state);
    }
    private enum State
    {
        triste,
        sorprendido,
    }
}