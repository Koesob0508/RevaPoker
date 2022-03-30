using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> deck;
    public List<int> intDeck;

    public void Initialize()
    {
        this.deck = new List<Card>();
        this.intDeck = new List<int>();
    }

    public void AddCard(Card _card)
    {
        this.deck.Add(_card);
        this.AddInt(deck.Count-1);
    }

    private void AddInt(int _int)
    {
        this.intDeck.Add(_int);
    }

    public void Shuffle()
    {
        List<int> shuffledDeck = new List<int>();
        // 계속 랜덤하게 새로 pop pop 하는거
        while(this.intDeck.Count != 0)
        {
            int index = Random.Range(0, intDeck.Count);
            shuffledDeck.Add(intDeck[index]);
            this.intDeck.RemoveAt(index);
        }

        this.intDeck = shuffledDeck;
    }

    public Card DrawCard()
    {
        Card drawnCard;
        // 마지막 Index는 무엇
        int lastIndex = this.intDeck.Count-1;
        // 실제로 뽑게되는 카드의 종류 index
        int resultIndex = this.intDeck[lastIndex];
        
        drawnCard = this.deck[resultIndex];

        // 해당 index는 삭제
        this.intDeck.RemoveAt(lastIndex);

        return drawnCard;
    }
}
