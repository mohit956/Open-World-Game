using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class joystick : MonoBehaviour ,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public Image joystickspon_area;
     public Image imagejoystickbg;
     public Image handler;
     private Vector2 posinput,posspon;
    // Start is called before the first frame update

    public void OnDrag(PointerEventData eventData)
    {
        // 1. ScreenPointToLocalPointInRectangle return bool value if you click on box then it run the code
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imagejoystickbg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posinput))
            {
                //2. to decrease the value of angel and conrol speed of the handler other wise it will run very fast
                posinput.x =posinput.x / (imagejoystickbg.rectTransform.sizeDelta.x);
                posinput.y = posinput.y/ (imagejoystickbg.rectTransform.sizeDelta.y);
                //3. ??
                if(posinput.magnitude >1f)
                {
                    posinput = posinput.normalized;
                }

                //5. move the handler we devide so it move inside the circle with the help ofnormalized (3)
                handler.rectTransform.anchoredPosition = new Vector2(
                    posinput.x*(imagejoystickbg.rectTransform.sizeDelta.x/2),
                    posinput.y*(imagejoystickbg.rectTransform.sizeDelta.y/2)
                );
            }

    }
    // if we touch screen then it will run ondrag event
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        
    }
    // it will re-position the handler to 0 and also the position when we lift the fingure
    public void OnPointerUp(PointerEventData eventData)
    {
        posinput = Vector2.zero;
        handler.rectTransform.anchoredPosition = Vector2.zero;
    }

    // for character movement
    public float inputHorizontal(){
        if (posinput.x != 0)
        return posinput.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float inputVertical(){
        if (posinput.y != 0)
        return posinput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
