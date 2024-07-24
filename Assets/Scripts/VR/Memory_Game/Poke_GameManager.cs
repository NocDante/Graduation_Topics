using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poke_GameManager : MonoBehaviour
{
    
    [SerializeField] private Touch_Card[] cards;  
    [SerializeField] private KeyCode[] keyCodes;
    [SerializeField] private GameObject Progress_Bar;
    [SerializeField] private RectTransform Fill_Area;
    private float initialWidth;  
    private List<Touch_Card> flippedCards = new List<Touch_Card>();

    public float GameTime = 0.0f;
    private float remainingTime;

    private bool IsFinish = false;
    private bool TimesUp = false;
    private bool isChecking = false;
    public bool Test_Mode = false;
    void Start()
    {
        remainingTime = GameTime;
        initialWidth = Fill_Area.sizeDelta.x;
        TimesUp = false;
        Hide_Game_2();
        
    }
    void Update()
    {
        // Test Mode
        for (int i = 0; i < cards.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]) && Test_Mode)
            {
                RotateCard(cards[i]);
            }
        }
    //==============================================
       if (remainingTime > 0 && !IsFinish)
    {
        remainingTime -= Time.deltaTime;
        UpdateFillArea();
    }

    // Finish Detect
    IsFinish = true; // 先假设游戏结束
    foreach (Touch_Card card in cards)
    {
        if (card.gameObject.activeInHierarchy)
        {
            IsFinish = false; // 如果有卡片仍然活跃，游戏未结束
            break;
        }
    }

    if (IsFinish || remainingTime <= 0)
    {
        
        Hide_Game_2();
        Debug.Log("Game Over!");

        // 确保游戏结束状态只被设置一次
        if (!TimesUp)
        {
            TimesUp = true;
        }
    }

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
    private void Hide_Game_2(){
        Progress_Bar.SetActive(false);

        foreach (Touch_Card card in cards){
            card.gameObject.SetActive(false);
        }
    }
    public void Show_Game_2(){
        Progress_Bar.SetActive(true);
        foreach (Touch_Card card in cards){
            card.gameObject.SetActive(true);
        }
    }
}
