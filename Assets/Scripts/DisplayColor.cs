using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayColor : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag.Equals("Ball Color"))
        {
            this.gameObject.GetComponent<Image>().color = DataManager.Instance.ballColor;
        }   
        else if(this.gameObject.tag.Equals("Paddle Color"))
        {
            this.gameObject.GetComponent<Image>().color = DataManager.Instance.paddleColor;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = DataManager.Instance.borderColor;
        }
    }
}
