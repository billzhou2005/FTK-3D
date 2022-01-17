using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    public PlayControl playControl;

    GameObject obj;
    private bool isMoveUp = false;
        // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -30 || transform.position.z > 30) {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (isMoveUp) {
            transform.Translate(0,0,-1);

        } else {
            transform.Translate(0,0,1);
        }
        isMoveUp = !isMoveUp;

        for(int i = 0; i < playControl.onHandCardsInfo.Length; i++) {
            if(playControl.onHandCardsInfo[i].name == gameObject.name) {
                if(isMoveUp) {
                    playControl.onHandCardsInfo[i].status = "Moved";
                } else {
                    playControl.onHandCardsInfo[i].status = "Hold";
                }
            }
        }

    }

}
