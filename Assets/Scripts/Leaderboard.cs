using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private void Awake()
    {
        entryContainer = transform.Find("Leaderboard Entry Container");
        entryTemplate = entryContainer.Find("Leaderboard Entry Template");
        entryTemplate.gameObject.SetActive(false);

        float height = 50f;
        for (int i = 0; i < 10; ++i)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -height * i);
            entryTransform.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
