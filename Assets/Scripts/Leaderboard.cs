using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class Leaderboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> leaderboardEntryTransforms;

    private void Awake()
    {
        entryContainer = transform.Find("Leaderboard Entry Container");
        entryTemplate = entryContainer.Find("Leaderboard Entry Template");
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("Leaderboards");

        if (jsonString.Equals(""))
        {
            ResetLeaderboard();
            jsonString = PlayerPrefs.GetString("Leaderboards");
        }

        Leaderboards leaderboards = JsonUtility.FromJson<Leaderboards>(jsonString);

        leaderboards.entries.Sort();

        leaderboardEntryTransforms = new List<Transform>();

        for (int i = 0; i < (leaderboards.entries.Count > 10 ? 10 : leaderboards.entries.Count); ++i)
        {
            CreateLeaderboardEntry(leaderboards.entries[i], entryContainer, leaderboardEntryTransforms);
        }
    }

    private void ResetLeaderboard()
    {
        // Used for resetting the leaderboard.
        Leaderboards leaderboards = new Leaderboards() { entries = new List<LeaderboardEntry>() };
        leaderboards.entries.Add(new LeaderboardEntry() { score = -1, name = "Minh" });

        // Used for resetting the leaderboard.
        string json = JsonUtility.ToJson(leaderboards);
        PlayerPrefs.SetString("Leaderboards", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("Leaderboards"));
    }

    private void CreateLeaderboardEntry(LeaderboardEntry entry, Transform container, List<Transform> transforms)
    {
        float height = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -height * transforms.Count);
        entryTransform.gameObject.SetActive(true);

        entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = transforms.Count + 1 + "";
        entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = entry.score + "";
        entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = entry.name;

        transforms.Add(entryTransform);
    }

    [Serializable]
    public class Leaderboards
    {
        public List<LeaderboardEntry> entries;
    }

    public void AddLeaderboardEntry(int score, string name)
    {
        LeaderboardEntry leaderboardEntry = new LeaderboardEntry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("Leaderboards");
        Leaderboards leaderboards = JsonUtility.FromJson<Leaderboards>(jsonString);

        leaderboards.entries.Add(leaderboardEntry);

        string json = JsonUtility.ToJson(leaderboards);
        PlayerPrefs.SetString("Leaderboards", json);
        PlayerPrefs.Save();
    }

    [Serializable]
    public class LeaderboardEntry : IComparable<LeaderboardEntry>
    {
        public int score;
        public string name;
        public int CompareTo(LeaderboardEntry other)
        {
            return other.score.CompareTo(score);
        }
    }
}
