using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEffect : MonoBehaviour
{
    private Image image;
    [SerializeField]
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Player>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp((player.maxHealth - player.health) / player.maxHealth, 0, 1f) * 0.1f);
    }
}
