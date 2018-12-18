using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    private enum State { OCCLUDED, NORMAL, HIGHLIGHTED, DEPLOYED };
    private State currentState;

    void Start()
    {
        this.currentState = State.NORMAL;
    }
}
