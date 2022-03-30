using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : MonoBehaviour
{
    private List<Player> playerList;
    private List<Deck> deckList;
    private List<int> characterList;
    public int player1Number;
    public int player2Number;

    void Awake()
    {
        playerList = new List<Player>();
        deckList = new List<Deck>();
        characterList = new List<int>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerEnter();

        GameObject MaidObject = new GameObject();
        MaidObject.AddComponent<Maid>();
        Maid Maid = MaidObject.GetComponent<Maid>();
        MaidObject.name = "Maid";

        Maid.Initialize(playerList, characterList, deckList);
        Maid.GenerateGame();
    }

    void PlayerEnter()
    {
        GameObject player1Object = new GameObject();
        player1Object.AddComponent<Player>();
        player1Object.name = "Player1";
        Player player1 = player1Object.GetComponent<Player>();

        GameObject player2Object = new GameObject();
        player2Object.AddComponent<Player>();
        player2Object.name = "Player2";
        Player player2 = player2Object.GetComponent<Player>();

        playerList.Add(player1);
        playerList.Add(player2);

        GameObject deckObject = new GameObject();
        deckObject.AddComponent<Deck>();
        deckObject.name = "Deck";
        Deck deck = deckObject.GetComponent<Deck>();
        deck.Initialize();

        AddInitalTrumpCard(deck);

        deckList.Add(deck);

        int player1CharacterNumber = player1Number;
        int player2CharacterNumber = player2Number;

        characterList.Add(player1CharacterNumber);
        characterList.Add(player2CharacterNumber);
    }

    private void AddInitalTrumpCard(Deck _deck)
    {
        // deck에 카드 추가
        for(int number=1; number<14; number++)
        {
            Spade spade = new Spade();
            spade.Initialize(number);

            _deck.AddCard(spade);
        }

        for(int number=1; number<14; number++)
        {
            Diamond diamond = new Diamond();
            diamond.Initialize(number);

            _deck.AddCard(diamond);
        }

        for(int number=1; number<14; number++)
        {
            Heart heart = new Heart();
            heart.Initialize(number);

            _deck.AddCard(heart);
        }

        for(int number=1; number<14; number++)
        {
            Clover clover = new Clover();
            clover.Initialize(number);

            _deck.AddCard(clover);
        }
    }
}
