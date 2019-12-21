using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private ColorGrading colorGrading;
    private PostProcessVolume volume;

    // Start is called before the first frame update
    void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out colorGrading);
        player = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        colorGrading.enabled.value = true;
        float saturation = (player.maxHealth - player.health) / player.maxHealth * -100f;
        colorGrading.saturation.value = Mathf.Clamp(saturation, -100f, 0f);
    }
}
