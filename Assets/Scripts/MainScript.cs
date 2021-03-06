﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using TMPro;

public class MainScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private GameObject gamePanel;

    [SerializeField]
    private Sprite backgroundImage;

    [SerializeField]
    private GameObject scoreText;

    [SerializeField]
    private GameObject finishPanel;

    MemoControls memoControls;

    private int cardAmount = 8;
    private int score = 0;
    private int cardsLeft;

    private List<GameObject> cards = new List<GameObject> ();
    private List<Sprite> cardImages = new List<Sprite>();

    private static System.Random random = new System.Random();

    private bool firstClick = true, secondClick = false;
    private bool clickBlocked = false;
    private int firstActiveCard = -1, secondActiveCard = -1;

    // Start is called before the first frame update
    public void StartGame(int cardAmount)
    {
        this.cardAmount = cardAmount;
        this.cardsLeft = cardAmount;
        AddCards();
        AddListeners();
        UpdateScoreText();
        memoControls = new MemoControls();
        memoControls.Duringgame.Exit.performed += _ => this.GetComponentInParent<Restart>().RestartGame();
        memoControls.Duringgame.Enable();
    }

    void AddCards()
    {
        LoadRandomSprites();

        for (int i = 0; i < cardAmount; i++)
        {
            GameObject card = Instantiate(cardPrefab, new Vector3(), Quaternion.identity);
            card.transform.SetParent(gamePanel.transform, false);
            card.name = $"Card {i}";
            card.GetComponent<Card>().id = i;
            card.GetComponent<Button>().image.sprite = backgroundImage;

            cards.Add(card);
        }

        RandomizeCards();
    }

    void LoadRandomSprites()
    {
        List<Sprite> allImages = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/CardImages"));
        List<Sprite> randomImages = new List<Sprite>();

        for(int i = 0; i < cardAmount/2; i++)
        {
            int imageId = random.Next(allImages.Count);
            randomImages.Add(allImages[imageId]);
            allImages.RemoveAt(imageId);
        }

        cardImages = randomImages;
    }

    void RandomizeCards()
    {
        int i = 0;

        foreach(GameObject card in cards.OrderBy(_ => random.Next()))
        {
            card.GetComponent<Card>().pairId = i / 2;
            card.GetComponent<Card>().cardImage = cardImages[i / 2];
            i++;
        }
    }

    void AddListeners()
    {
        foreach (GameObject card in cards)
        {
            card.GetComponent<Button>().onClick.AddListener(() => Click());
        }
    }

    void Click()
    {
        if (!clickBlocked)
        {
            GameObject card = EventSystem.current.currentSelectedGameObject;
            if (firstClick)
            {
                card.GetComponent<Button>().image.sprite = card.GetComponent<Card>().cardImage;
                firstActiveCard = card.GetComponent<Card>().id;

                firstClick = false;
                secondClick = true;
            }
            else if (secondClick)
            {
                card.GetComponent<Button>().image.sprite = card.GetComponent<Card>().cardImage;
                secondActiveCard = card.GetComponent<Card>().id;

                CheckPair();

                firstClick = true;
                secondClick = false;
            }
        }
    }

    void CheckPair()
    {
        if(cards[firstActiveCard].GetComponent<Card>().pairId == cards[secondActiveCard].GetComponent<Card>().pairId)
        {
            StartCoroutine(HidePair());
            score += 5;
            UpdateScoreText();
            cardsLeft -= 2;

            if (cardsLeft == 0)
            {
                finishGame();
            }
        } 
        else
        {
            StartCoroutine(TurnBackPair());
            score -= 1;
            UpdateScoreText();
        }
    }

    IEnumerator HidePair()
    {
        clickBlocked = true;
        yield return new WaitForSeconds(1f);

        cards[firstActiveCard].transform.localScale = new Vector3(0, 0, 0);
        cards[secondActiveCard].transform.localScale = new Vector3(0, 0, 0);

        clickBlocked = false;
    }

    IEnumerator TurnBackPair()
    {
        clickBlocked = true;
        yield return new WaitForSeconds(1f);

        cards[firstActiveCard].GetComponent<Button>().image.sprite = backgroundImage;
        cards[secondActiveCard].GetComponent<Button>().image.sprite = backgroundImage;
        clickBlocked = false;
    }

    void UpdateScoreText()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score:\t{score}";
    }

    void finishGame()
    {
        memoControls.Duringgame.Disable();
        gamePanel.transform.parent.gameObject.SetActive(false);
        finishPanel.SetActive(true);
        finishPanel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = $"Zdobyles {score} punktów!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
