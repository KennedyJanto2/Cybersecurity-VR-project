using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RawImage mouseUI;
    [SerializeField] GameObject mousePad;
    [SerializeField] float mouseSpeedScale;

    private Vector3 previousPos;

    private Vector2 maxPoint;
    private Vector2 minPoint;

   
    void Start()
    {
        previousPos = transform.position;
     
        Bounds parentBounds = mousePad.GetComponentInParent<Renderer>().bounds;
        maxPoint = new Vector2(parentBounds.max.x, parentBounds.max.z);
        minPoint = new Vector2(parentBounds.min.x, parentBounds.min.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = transform.position;
        current.x = Mathf.Clamp(current.x, minPoint.x, maxPoint.x);
        current.z = Mathf.Clamp(current.z, minPoint.y, maxPoint.y);

        transform.position = current;

        if(current != previousPos)
        {

            Vector2 difference = new Vector2(current.x - previousPos.x, current.z - previousPos.z);
            difference *= mouseSpeedScale;

            Vector3 mouseUIPos = mouseUI.GetComponent<RectTransform>().localPosition;
            Vector3 finalPos = new Vector3(difference.x + mouseUIPos.x, difference.y + mouseUIPos.y, mouseUIPos.z);
            mouseUI.GetComponent<RectTransform>().localPosition = finalPos;

            ClampMouseToUI();
            previousPos = current;
        }
    }

    void ClampMouseToUI()
    {
        RectTransform mouse = mouseUI.GetComponentInParent<RectTransform>();
        RectTransform canvas = mouseUI.transform.parent.gameObject.GetComponent<RectTransform>();

        Vector3 pos = mouseUI.GetComponent<RectTransform>().localPosition;

        Vector3 minPosition = canvas.rect.min - mouse.rect.min;
        Vector3 maxPosition = canvas.rect.max - mouse.rect.max;

        pos.x = Mathf.Clamp(mouse.localPosition.x, minPosition.x, maxPosition.x);
        pos.y = Mathf.Clamp(mouse.localPosition.y, minPosition.y, maxPosition.y);

       mouse.localPosition = pos;
    }

}
