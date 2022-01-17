[System.Serializable]

struct Kinds {
    int points;
    int counter;
};
struct Card {
    int points;
    int suits;
};
struct PlayerCards {
    //private Cards points;
    Card[] cards;
    int cardsScore;
    Kinds[] kindsGather;
    int bombFtkCounter;
    int[] bombFtkPure;
};

public class FTKCards
{
    int rID;
    PlayerCards[] playerCards;
}
