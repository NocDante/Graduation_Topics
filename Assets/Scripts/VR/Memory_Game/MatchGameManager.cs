using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchGameManager : MonoBehaviour
{
    [Header("Game Rules")]
    [SerializeField] private float GameTime = 0.0f;
    private float remainingTime;
    [SerializeField] private Touch_Card[] cards;
    private List<Touch_Card> flippedCards = new List<Touch_Card>();
    private bool isChecking = false;

    [Header("UI Settings")]
    [SerializeField] private GameObject Progress_Bar;
    [SerializeField] private GameObject Tutorial;
    [SerializeField] private GameObject Start_Button;
    [SerializeField] private RectTransform Fill_Area;

    [SerializeField] private GameObject Vague_Photo;
    private float initialWidth;

    [Header("Test Mode Setting")]
    [SerializeField] private bool Test_Mode = false;
    [SerializeField] private KeyCode[] keyCodes;

    private enum Game_Status
    {
        WaitForStart,
        GameStart,
        GameInProgress,
        GameEnd,
    }
    private Game_Status state = Game_Status.WaitForStart;

    void Start()
    {
        // Initialize
        remainingTime = GameTime;
        initialWidth = Fill_Area.sizeDelta.x;
        Vague_Photo.SetActive(true);

        // Hide UI when start
        Hide_Game_2_Tutorial();
        Hide_Game_2();
    }
    void Update()
    {
        TestMode();
        GameStatus_Detect();
    }
    private void UpdateFillArea()
    {
        float fillAmount = remainingTime / GameTime;
        Vector2 sizeDelta = Fill_Area.sizeDelta;
        sizeDelta.x = initialWidth * fillAmount;
        Fill_Area.sizeDelta = sizeDelta;
    }
    public void RotateCard(Touch_Card card)
    {
        if (!card.isRotating && !isChecking && !flippedCards.Contains(card))
        {
            // Rotate.
            card.Rotate(180f, 0.5f);
            // Add two cards into the flippedCards list.
            flippedCards.Add(card);
            if (flippedCards.Count == 2)
            {
                // Match two cards
                StartCoroutine(CheckMatch());
            }
        }
    }
    private IEnumerator CheckMatch()
    {
        isChecking = true;

        yield return new WaitForSeconds(1f);

        if (flippedCards[0].card_Tag == flippedCards[1].card_Tag)
        {
            foreach (Touch_Card card in flippedCards)
            {
                // If two cards is the same
                card.gameObject.SetActive(false);
                // write the code here when finish ...
            }
        }
        else
        {
            // If two cards is not the same, turning back
            foreach (Touch_Card card in flippedCards)
            {
                card.Rotate(-180f, 0.5f);
            }
        }
        flippedCards.Clear();
        isChecking = false;
    }
    private void Hide_Game_2()
    {
        Progress_Bar.SetActive(false);

        foreach (Touch_Card card in cards)
        {
            card.gameObject.SetActive(false);
        }


    }
    public void Show_Game_2()
    {
        Progress_Bar.SetActive(true);
        foreach (Touch_Card card in cards)
        {
            card.gameObject.SetActive(true);
        }

    }
    public void Show_Game_2_Tutorial()
    {
        Tutorial.SetActive(true);
        Start_Button.SetActive(true);

    }
    public void Hide_Game_2_Tutorial()
    {
        Tutorial.SetActive(false);
        Start_Button.SetActive(false);


    }
    public void ChangeGameStatus(int nextStatusIndex)
    {
        state = (Game_Status)(nextStatusIndex - 1);
    }
    private void TestMode()
    {
        // Test mode settings.
        for (int i = 0; i < cards.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]) && Test_Mode)
            {
                RotateCard(cards[i]);
            }
        }

        Debug.Log(state);
    }
    private void GameStatus_Detect()
    {
        switch (state)
        {
            case Game_Status.GameStart:
                //=============================================== Change the state.
                if (AreAllCardsInState(true))
                {
                    state = Game_Status.GameInProgress;
                }
                break;

            case Game_Status.GameInProgress:
                // ============================================== Start counting times.
                if (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime;
                    UpdateFillArea();
                }

                //=============================================== If matches all the cards, game end. 
                if (AreAllCardsInState(false) || remainingTime <= 0)
                {
                    state = Game_Status.GameEnd;
                }
                break;

            case Game_Status.GameEnd:

                Hide_Game_2();
                Hide_Game_2_Tutorial();
                Vague_Photo.SetActive(false);
                // after the game2 end............
                break;

        }
    }
    private bool AreAllCardsInState(bool checkForActive) //Detect if all the cards are active or inactive.
    {
        foreach (Touch_Card card in cards)
        {
            if (card.gameObject.activeInHierarchy != checkForActive)
            {
                return false;
            }
        }
        return true;
    }
}
