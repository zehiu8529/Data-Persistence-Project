using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] Color[] availableColors;
    public Button buttonPrefab;
    List<Button> colorButtonList;        

    // Start is called before the first frame update
    void Start()
    {              
        Init();    
    }   

    void Init()
    {
        colorButtonList = new List<Button>();        

        for (int i = 0; i < availableColors.Length; i++)
        {
            Button newButton = Instantiate(buttonPrefab);
            newButton.transform.SetParent(transform, false);
            newButton.transform.position = new Vector2(transform.position.x + i * 40, transform.position.y);
            newButton.GetComponent<Image>().color = availableColors[i];
            newButton.tag = transform.tag;

            newButton.onClick.AddListener(() =>
            {                
                if(newButton.tag.Equals("Ball Color"))
                {
                    SelectBallColor(newButton.GetComponent<Image>().color);                    
                }
                else if (newButton.tag.Equals("Paddle Color"))
                {
                    SelectPaddleColor(newButton.GetComponent<Image>().color);                    
                }
                else
                {
                    SelectBorderColor(newButton.GetComponent<Image>().color);                    
                }           
            });
            
            colorButtonList.Add(newButton);            
        }
    }

    void SelectBallColor(Color ballColor)
    {
        DataManager.Instance.ballColor = ballColor;        
    }

    void SelectPaddleColor(Color paddleColor)
    {
        DataManager.Instance.paddleColor = paddleColor;
    }

    void SelectBorderColor(Color borderColor)
    {
        DataManager.Instance.borderColor = borderColor;
    }
}
