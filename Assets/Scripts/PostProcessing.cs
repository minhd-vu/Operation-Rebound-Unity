using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private ColorGrading colorGrading;

    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        player = gameObject.GetComponent<Player>();
        volume.profile.TryGetSettings(out colorGrading);
        colorGrading.enabled.value = true;
    }

    // Update is called once per frame
    void Update()
    {
        colorGrading.saturation.value = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
    }
}
