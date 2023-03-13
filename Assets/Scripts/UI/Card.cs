using System;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class Card : MonoBehaviour
{ 
    public enum CardType
    {
        Move,
        Turn
    }

    [SerializeField]
    protected CardType type;
    [SerializeField]
    protected string cardText;
    [SerializeField]
    protected int arg;
    [SerializeField]
    protected TextMeshProUGUI text;

    protected Instruction instruction;

    private void Start()
    {
        instruction = type switch
        {
            CardType.Move => new MoveInstruction(cardText, arg),
            CardType.Turn => new TurnInstruction(cardText, arg),
            _ => throw new NotImplementedException()
        };
    }

    private void OnValidate()
    {
        text.text = cardText;
    }
}
