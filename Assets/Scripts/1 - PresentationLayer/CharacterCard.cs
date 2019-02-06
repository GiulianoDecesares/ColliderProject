using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    public enum State { OCCLUDED, NORMAL, HIGHLIGHTED, DEPLOYED };
    private State currentState;

    void Start()
    {
        this.currentState = State.NORMAL;
    }

    public void SetState(State thisState)
    {
        switch(thisState)
        {
            case State.OCCLUDED:

                if(this.Occlud())
                    this.currentState = State.OCCLUDED;
                else
                    Debug.LogWarning("Error trying to occlud character card");

                break;

            case State.NORMAL:

                if(this.Normalize())
                    this.currentState = State.NORMAL;
                else
                    Debug.LogWarning("Error trying to normalize character card");

                break;

            case State.HIGHLIGHTED:

                if(this.Highlight())
                    this.currentState = State.HIGHLIGHTED;
                else
                    Debug.LogWarning("Error trying to highlight character card");

                break;

            case State.DEPLOYED:

                if(this.Deploy())
                    this.currentState = State.DEPLOYED;
                else
                    Debug.LogWarning("Error trying to deploy character card");

                break;
        }
    }

    private bool Occlud()
    {
        // When occluded, the card will show the splash art, with a dark overlay. Size also would be a little decreased. 
        // Skill buttons will be not visible. 

        return false;
    }

    private bool Normalize()
    {
        // When normal, card will show a full coloured splash art. Skills buttons are not visible. 

        return false;
    }

    private bool Highlight()
    {
        // A higlight character card will show some animation, particle or something to catch atention. Skills buttons will be visible. 
        // A little "use" text will be visible also. 

        return false;
    }

    private bool Deploy()
    {
        // This is a full deployed character card, ready to use some skill for the character. 

        return false;
    }
}
