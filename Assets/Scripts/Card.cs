using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    protected int number;
    protected int suit;

    public int GetIndex()
    {
        return this.number;
    }

    public int GetPattern()
    {
        return this.suit;
    }

    public virtual void Initialize(int _number)
    {
        this.number = _number;
    }

    public abstract void Effect();

    public string Log()
    {
        string log = string.Format("Card Suit:{0}, Number:{1}", this.suit, this.number);

        return log;
    }
}
