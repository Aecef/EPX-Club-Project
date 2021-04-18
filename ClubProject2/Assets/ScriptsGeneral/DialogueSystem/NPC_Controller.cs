using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    // choose which DialogueHolder to use for NPC
    [SerializeField] private GameObject dialogue;

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}