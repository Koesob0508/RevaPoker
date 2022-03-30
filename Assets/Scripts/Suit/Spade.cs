using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spade : Card
{
    public override void Initialize(int _number)
    {
        base.Initialize(_number);
        this.suit = 0;
    }
    public override void Effect()
    {
        string Log = string.Format("Effect of Spade {0} Activate", this.number);
        Debug.Log(Log);
    }
}
