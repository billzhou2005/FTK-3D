using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public GameObject[] cardsPrefabs;
    public PlayControl playControl;
    // List<GameObject> onHandCards = new List<GameObject>();
    List<GameObject> onHandCards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCards() {
        onHandCards = playControl.onHandCards;
        onHandCards.Clear();
        getCards();

        playControl.onHandCardsInfo = new CardInfo[playControl.onHandCardsTotal];
        float startPosX = -playControl.onHandCards.Count/2f;
        Vector3 spawnPos = new Vector3(startPosX,playControl.startPosY,playControl.startPosZ);

        for(int i = 0; i < onHandCards.Count; i++) {
            spawnPos.x = startPosX + i*1.4f;
            spawnPos.y = playControl.startPosY + i*0.01f;
            onHandCards[i].name = "card" + i.ToString();
            Instantiate(onHandCards[i],spawnPos,onHandCards[i].transform.rotation);
            CardInfo cardInfo;
            cardInfo.name = onHandCards[i].name + "(Clone)";
            cardInfo.status = "Hold";
            playControl.onHandCardsInfo[i] = cardInfo;
        }
    }

    private void getCards() {
        playControl.onHandCardsTotal = 26;
        for(int i = 0; i < playControl.onHandCardsTotal; i++) {
            playControl.onHandCards.Add(cardsPrefabs[UnityEngine.Random.Range(0, cardsPrefabs.Length)]);
        }
    }
}
