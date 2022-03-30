using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<Card> cardList;
    public void InitializeCard()
    {
        cardList = new List<Card>();
    }
}
