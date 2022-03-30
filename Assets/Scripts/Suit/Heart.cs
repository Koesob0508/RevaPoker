using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Card
{
    public override void Initialize(int _number)
    {
        base.Initialize(_number);
        this.suit = 2;
    }
    public override void Effect()
    {
        string Log = string.Format("Effect of Heart {0} Activate", this.number);
        Debug.Log(Log);
    }
}
