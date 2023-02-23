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
    [SerializeField] float mouseSpeedScale;

    private Vector3 previousPos;
   
    void Start()
    {
        previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider))
        {
            MoveMouseUI();    
        }

        else if (collision.collider.GetType() == typeof(MeshCollider)) { }
    }

    void MoveMouseUI()
    {
        Vector3 current = transform.position;
        if (current != previousPos)
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
