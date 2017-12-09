using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Camera mainCamera;
    Vector2 lastPos;
    bool isStarted = false;

	// Use this for initialization
	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPos = eventData.position;
        isStarted = true;
    }

    public void OnDrag(PointerEventData eventData) {
        if (isStarted) {
            Vector2 diff = eventData.position - lastPos;
            lastPos = eventData.position;
            float ratio = 0.1f;
            mainCamera.transform.position -= new Vector3(diff.x * ratio, diff.y * ratio, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        isStarted = false;
    }
}
