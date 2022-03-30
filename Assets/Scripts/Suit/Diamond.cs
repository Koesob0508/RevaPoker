using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Card
{
    public override void Initialize(int _number)
    {
        base.Initialize(_number);
        this.suit = 1;
    }
    public override void Effect()
    {
        string Log = string.Format("Effect of Diamond {0} Activate", this.number);
        Debug.Log(Log);
    }
}
