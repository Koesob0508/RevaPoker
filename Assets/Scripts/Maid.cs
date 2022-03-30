using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maid : MonoBehaviour
{
    public List<Player> players;
    public List<int> characterNumberList;
    public List<Deck> deckList;
    public Deck deck;
    private List<Card> communityCards {get; set;}
    private List<PlayerManager> playerManagers;
    private bool isOnBattle;

    public void Initialize(List<Player> _playerList, List<int> _characterNumberList, List<Deck> _deckList)
    {
        players = _playerList;
        characterNumberList = _characterNumberList;
        deckList = _deckList;

        deck = deckList[0];

        communityCards = new List<Card>();
        playerManagers = new List<PlayerManager>();

        isOnBattle = false;
    }

    public void GenerateGame()
    {
        GeneratePlayerManager();
        GenerateCards();
        // 4. 커뮤니티 카드 목록 만들기 → 카드 배분
        // 4.1. 덱 셔플
        this.deck.Shuffle();
        PreFlop();
        Flop();
        playerManagers[0].SetControllable(true);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            if(playerManagers[0].GetControllable())
            {
                playerManagers[0].SetControllable(false);
                playerManagers[0].gameObject.SetActive(false);

                playerManagers[1].SetControllable(true);
                playerManagers[1].gameObject.SetActive(true);

                Debug.Log(playerManagers[0].GetControllable());
            }
            else
            {
                playerManagers[0].SetControllable(true);
                playerManagers[0].gameObject.SetActive(true);

                playerManagers[1].SetControllable(false);
                playerManagers[1].gameObject.SetActive(false);

                Debug.Log(playerManagers[0].GetControllable());  
            }
        }
        // 한 판 구성을 여기다 적으면 된다.
        // 각 PlayerManager가 준비 완료 됐는지 확인
        if(GetReadyFromManagers() && !isOnBattle)
        {
            isOnBattle = true;
            // 모든 PlayerManager가 준비 완료 됐다면 전투 진행
        }
        
    }

    private void GeneratePlayerManager()
    {
        // 1. 각 Player별 캐릭터 만들기, characterList의 숫자를 참고해야지
        // → 각 Player별 Manager 만들기
        int playerIndex = 0;
        foreach (Player player in players)
        {
            GameObject playerManagerObject = new GameObject();
            playerManagerObject.AddComponent<PlayerManager>();
            playerManagerObject.name = string.Format("Player {0} Manager", playerIndex);

            PlayerManager playerManager = playerManagerObject.GetComponent<PlayerManager>();
            playerManager.Initialize();
            playerManager.SetIndex(playerIndex);
            playerManager.SetPlayer(player);
            playerManager.SetDeck(GetDeck(playerIndex));

            // 캐릭터 생성 및 등록
            for (int index = 0; index < characterNumberList[playerIndex]; index++)
            {
                GameObject characterObject = new GameObject();
                characterObject.AddComponent<Character>();
                characterObject.name = string.Format("Character (Player:{0} Index:{1})", playerIndex, index);

                Character character = characterObject.GetComponent<Character>();
                playerManager.AddCharacter(character);
            }

            playerManagers.Add(playerManager);

            playerIndex++;
        }
    }

    private void GenerateCards()
    {
        // 2. 각 Player별 카드 목록 만들기, Player Object에서 관리를 하냐 마냐인데, Player Object에서 관리
        // → Player가 아니라 Player Manager가 카드 관리할 수 있도록 바꾸는게 좋을듯. Initialize에 포함
        // Player는 말그대로 Player의 변하지 않는 정보 관리하는 객체로,
        // Player Manager는 게임 내에서 변화하는 정보들을 관리하는 객체, 게임 끝나면 사라짐
        // 3. 각 Character별 카드 목록 만들기, 이건 Character Object가 관리하는게 좋을거 같은데
        foreach (PlayerManager playerManager in playerManagers)
        {
            playerManager.InitializeCharacterCard();
        }
    }

    private void PreFlop()
    {
        // 4.3. 각 플레이어 패 돌리기
        // 패를 돌리는 숫자는 Character의 갯수 * 2
        foreach(PlayerManager playerManager in playerManagers)
        {
            foreach(Character character in playerManager.GetCharacters())
            {
                playerManager.AddCard(this.deck.DrawCard());
                playerManager.AddCard(this.deck.DrawCard());
            }
            Debug.Log(playerManager.LogHands());
        }
    }
    private void Flop()
    {
        // 4.2. 커뮤니티 카드 세팅
        for(int count=0; count<3; count++)
        {
            communityCards.Add(this.deck.DrawCard());
        }

        Debug.Log(LogCommunityCards());
    }

    private Deck GetDeck(int _index)
    {
        if (players.Count == deckList.Count)
        {
            return deckList[_index];
        }
        else
        {
            return deckList[0];
        }
    }

    private bool GetReadyFromManagers()
    {
        bool ready = true;
        foreach(PlayerManager playerManager in playerManagers)
        {
            if(playerManager.GetReady()==false)
            {
                ready = false;
            }
        }

        return ready;
    }

    private string LogCommunityCards()
    {
        string log = "현재 커뮤니티 카드는 ";

        foreach(Card communityCard in communityCards)
        {
            log += communityCard.Log();
            log += " ";
        }

        return log;
    }
}
