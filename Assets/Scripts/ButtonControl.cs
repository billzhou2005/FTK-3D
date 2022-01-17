using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class ButtonControl : MonoBehaviour
{
    public CardsManager cardsManager;
    public PlayControl playControl;

    public APIManager apiManager;
    public void onButtonGetCards() {
        string ftkCardsStr = apiManager.GetCards();
        JObject ftkCards = (JObject)JsonConvert.DeserializeObject(ftkCardsStr);
        //Debug.Log(ftkCards);
        // Debug.Log(ftkCards["playersCards"][0]);
        // Debug.Log(ftkCards["playersCards"][0]["cards"][0]);
        Debug.Log(ftkCards["playersCards"][0]["cards"][0]["points"]);
        Debug.Log(ftkCards["playersCards"][0]["cards"][0]["suits"]);


        cardsManager.SpawnCards();
    }
    public void onButtonSend() {
        playControl.sendCards();
    }

    public void onButtonDestroy() {
        playControl.moveCardsToDestroyedArea();
    }
}
