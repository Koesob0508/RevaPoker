using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clover : Card
{
    public override void Initialize(int _number)
    {
        base.Initialize(_number);
        this.suit = 3;
    }
    public override void Effect()
    {
        string Log = string.Format("Effect of Clover {0} Activate", this.number);
        Debug.Log(Log);
    }
}
