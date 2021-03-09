using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public int itemindex;
    private Canvas canvas;
    private CanvasGroup _cg;
    private RectTransform _rt;
    
    private AudioSource _as;
    public AudioClip pointerDownSound;

    private void Awake() {
        _rt = GetComponent<RectTransform>();
        _cg = GetComponent<CanvasGroup>();
        _as = GetComponentInParent<AudioSource>();
        canvas= GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        _cg.alpha = .6f;
        _cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rt.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        _cg.alpha = 1f;
        _cg.blocksRaycasts = true;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        _as.PlayOneShot(pointerDownSound);
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
