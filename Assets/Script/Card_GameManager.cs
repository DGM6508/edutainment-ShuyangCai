using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card_GameManager : MonoBehaviour
{


    private bool canPlayerClick = true;

    public Sprite BackSprite;
    public Sprite SuccessSprite;
    public Sprite[] FrontSprites;
    public Sprite[] FrontSprites2;
    public GameObject CardPre;
    public Transform CardsView;
    private List<GameObject> CardObjs;
    private List<Card> FaceCards;

    public static int clickTimes=40;
    public static int cardNum = 16;

    public AudioClip beep;
    AudioSource buttonSound;


    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
        buttonSound.clip = beep;
        CardObjs = new List<GameObject>();
        FaceCards = new List<Card>();

        
        for (int i = 0; i < 8; i++)
        {
            Sprite FrontSprite = FrontSprites[i];
                GameObject go = (GameObject)Instantiate(CardPre);

                Card card = go.GetComponent<Card>();
                card.InitCard(i, FrontSprite, BackSprite, SuccessSprite);
                card.cardBtn.onClick.AddListener(() => CardOnClick(card));

                CardObjs.Add(go);
            
        }

        for (int i = 0; i < 8; i++)
        {
            Sprite FrontSprite = FrontSprites2[i];
            GameObject go = (GameObject)Instantiate(CardPre);

            Card card = go.GetComponent<Card>();
            card.InitCard(i, FrontSprite, BackSprite, SuccessSprite);
            card.cardBtn.onClick.AddListener(() => CardOnClick(card));

            CardObjs.Add(go);

        }

        while (CardObjs.Count > 0)
        {

            int ran = Random.Range(0, CardObjs.Count);
            GameObject go = CardObjs[ran];

            go.transform.parent = CardsView;

            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            
            CardObjs.RemoveAt(ran);
        }
    }


    private void CardOnClick(Card card)
    {
        if (canPlayerClick)
        {
            clickTimes = clickTimes - 1;
            
            buttonSound.Play();
            card.SetFanPai();
            
            FaceCards.Add(card);
            
            if (FaceCards.Count == 2)
            {
                canPlayerClick = false;
                StartCoroutine(JugdeTwoCards());
            }
        }
    }

    IEnumerator JugdeTwoCards()
    {
    
        Card card1 = FaceCards[0];
        Card card2 = FaceCards[1];
        if (card1.ID == card2.ID)
        {
            Debug.Log("Success......");
            yield return new WaitForSeconds(0.6f);
            card1.SetSuccess();
            card2.SetSuccess();
            cardNum = cardNum - 2;
        }
        else
        {
            Debug.Log(cardNum);
            yield return new WaitForSeconds(1.0f);
            card1.SetRecover();
            card2.SetRecover();
        }
        if (cardNum == 0)
        {
            
            Application.LoadLevel("HEScene");
        } else if (clickTimes<=0)
        {
            Application.LoadLevel("SEScene");
        }
        FaceCards = new List<Card>();
        canPlayerClick = true;
    }
}