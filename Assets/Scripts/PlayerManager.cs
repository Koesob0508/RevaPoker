using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    private int playerIndex;
    private Player player;
    private Deck deck;
    private List<Character> characters;
    private List<Card> hands;
    private bool isControllable;
    private bool isReady;

    public int fromHandsIndex;
    public int handsToCharacter;
    public int handsToCardIndex;

    public int removedFromCharacter;
    public int removedFromCardIndex;
    public int fromCharacter;
    public int toCharacter;

    public void Initialize()
    {
        characters = new List<Character>();
        hands = new List<Card>();
        isControllable = false;
        isReady = false;
    }

    public void Update()
    {
        if (isControllable)
        {

        }

    }

    public void SetIndex(int _playerIndex)
    {
        playerIndex = _playerIndex;
    }

    public void SetPlayer(Player _player)
    {
        player = _player;
    }

    public void SetDeck(Deck _deck)
    {
        deck = _deck;
    }

    public void AddCharacter(Character _character)
    {
        characters.Add(_character);
    }

    public void InitializeCharacterCard()
    {
        foreach (Character character in characters)
        {
            character.InitializeCard();
        }
    }

    public List<Character> GetCharacters()
    {
        return characters;
    }

    public bool GetReady()
    {
        return isReady;
    }

    public bool GetControllable()
    {
        return isControllable;
    }

    public void AddCard(Card _card)
    {
        this.hands.Add(_card);
    }

    public void SetControllable(bool _bool)
    {
        this.isControllable = _bool;
    }

    public string LogHands()
    {
        string handsLog = this.gameObject.name + " 손 패는 ";

        foreach (Card hand in hands)
        {
            handsLog += hand.Log();
            handsLog += " ";
        }

        return handsLog;
    }

    public void SetCard()
    {
        if (isControllable)
        {
            Debug.Log(string.Format("{0}번째 손 패를 {1}번째 캐릭터의 {2}번째 인덱스에 뒀습니다.", fromHandsIndex, handsToCharacter, handsToCardIndex));
        }
        else
        {
            Debug.Log("현재 " + this.gameObject.name + "의 차례가 아닙니다.");
        }
    }

    public void RemoveCard()
    {
        if (isControllable)
        {
            Debug.Log(string.Format("{0}번째 캐릭터, {1} 인덱스에 있는 카드를 손 패로 가져왔습니다.", removedFromCharacter, removedFromCardIndex));
        }
        else
        {
            Debug.Log("현재 " + this.gameObject.name + "의 차례가 아닙니다.");
        }
    }

    public void SetDirection()
    {
        if (isControllable)
        {
            if (toCharacter >= 0)
            {
                Debug.Log(string.Format("{0}번째 캐릭터가, {1}번째 캐릭터에게 공격합니다.", fromCharacter, toCharacter));
            }
            else
            {
                Debug.Log(string.Format("{0}번째 캐릭터가 공격을 취소했습니다.", fromCharacter));
            }
        }
        else
        {
            Debug.Log("현재 " + this.gameObject.name + "의 차례가 아닙니다.");
        }
    }
}

