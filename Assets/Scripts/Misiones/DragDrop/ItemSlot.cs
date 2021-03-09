using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler,IPointerExitHandler
{
    public int itemindex;
    private DragMision _dm;
    private AudioSource _as;
    public AudioClip itemTrue,itemFalse;
    private bool ObjectInSlot;
    private void Start() {
        _dm = GetComponentInParent<DragMision>();
        _as = GetComponentInParent<AudioSource>();
        ObjectInSlot = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag !=null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            if(eventData.pointerDrag.GetComponent<DragDrop>().itemindex == itemindex)
            {
                ObjectInSlot = true;
                GetComponent<Image>().color = Color.green;
                _as.PlayOneShot(itemTrue);
                _dm.elements++;
                _dm.validateElements();
            }
            else
            {
                GetComponent<Image>().color = Color.red;
                _as.PlayOneShot(itemFalse);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(eventData.pointerDrag!= null)
        {
            Debug.Log(eventData.pointerDrag.GetComponent<DragDrop>().itemindex);
            GetComponent<Image>().color = new Color(0,0,0,0); 
            if(eventData.pointerDrag.GetComponent<DragDrop>().itemindex == itemindex)
            {
                if(ObjectInSlot)
                {
                    _dm.elements--;
                    ObjectInSlot = false;
                }
            }
        }
    }

}
