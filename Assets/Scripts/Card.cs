using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public int pairId;
    public Sprite cardImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override bool Equals(object other)
    {
        if ((other == null) || !this.GetType().Equals(other.GetType()))
        {
            return false;
        }
        else
        {
            Card card = (Card) other;
            return pairId == card.pairId;
        }
    }

    public override int GetHashCode()
    {
        return pairId;
    }
}
