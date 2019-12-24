using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadIndicator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //transform.position = (Vector2)Input.mousePosition + (Vector2.right + Vector2.down) * (GetComponent<Image>().sprite.rect.width / 2);
        transform.position = Input.mousePosition;
        //CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        //transform.position = new Vector2(Input.mousePosition.x * scaler.referenceResolution.x / Screen.width, Input.mousePosition.y * scaler.referenceResolution.y / Screen.height);
    }
}
