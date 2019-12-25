using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCursor : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = Input.mousePosition;
        //CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        //GetComponent<RectTransform>().anchoredPosition = new Vector2(Input.mousePosition.x * scaler.referenceResolution.x / Screen.width, Input.mousePosition.y * scaler.referenceResolution.y / Screen.height);
    }
}
