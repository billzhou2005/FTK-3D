using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct CardInfo {
    public string name;
    public string status;
};

public class PlayControl : MonoBehaviour
{
    public List<GameObject> onHandCards = new List<GameObject>();
    public float startPosX = 0;
    public float startPosY = 1;
    public float startPosZ = -11;
    public int onHandCardsTotal = 12;
    public CardInfo[] onHandCardsInfo;
    private GameObject obj;

    public void sendCards(){
        int sendTotal = 0;
        for(int i = 0; i < onHandCardsInfo.Length; i++) {
            if(onHandCardsInfo[i].status == "Moved") {
                sendTotal++;
            }
        }
        if(sendTotal == 0) {
            Debug.Log("No cards need to be sent!");
            return;
        }
        float startX = -sendTotal/2f;
        float startY = 1.10f;
        float targetX;
        float targetY;
        int index = 0;

        for(int i = 0; i < onHandCardsInfo.Length; i++) {
            if(onHandCardsInfo[i].status == "Moved") {
                obj = GameObject.Find(onHandCardsInfo[i].name);
                targetX = startX + index * 1.4f - obj.transform.position.x;
                targetY = startY + index * 0.01f - obj.transform.position.y;
                obj.transform.Translate(targetX, targetY, 14);
                onHandCardsInfo[i].status = "Sent";
                index++;
            }
        }

        int holdTotal = 0;

        for(int i = 0; i < onHandCardsInfo.Length; i++) {
            if(onHandCardsInfo[i].status == "Hold") {
                holdTotal++;
            }
        }
        if(holdTotal == 0) {
            return;
        }

        startX = -holdTotal/2f;
        startY = 1;
        index = 0;
        for(int i = 0; i < onHandCardsInfo.Length; i++) {
            if(onHandCardsInfo[i].status == "Hold") {
                obj = GameObject.Find(onHandCardsInfo[i].name);
                targetX = startX + index * 1.4f - obj.transform.position.x;
                targetY = startY + index * 0.01f - obj.transform.position.y;
                obj.transform.Translate(targetX, targetY, 0);
                index++;
            }
        }

    }

    public void moveCardsToDestroyedArea() {
        for(int i = 0; i < onHandCardsInfo.Length; i++) {
            if(onHandCardsInfo[i].status == "Sent") {
                obj = GameObject.Find(onHandCardsInfo[i].name);
                obj.transform.Translate(-100, 0, 100);;
                onHandCardsInfo[i].status = "Destroyed";
            }
        }
    }

}
