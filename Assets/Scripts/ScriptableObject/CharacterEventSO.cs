using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<BloodOfPlayer> OnEventRaised;

    public void RaiseEvent(BloodOfPlayer character)
    {
        OnEventRaised?.Invoke(character);
    }
}
