using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Leaderboard leaderboard;
    private bool ended = false;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    leaderboard.gameObject.SetActive(!leaderboard.gameObject.activeSelf);
        //    Time.timeScale = leaderboard.gameObject.activeSelf ? 0f : 1f;
        //}
    }

    public void EndGame(int score)
    {
        if (!ended)
        {
            ended = true;
            //leaderboard.AddLeaderboardEntry(score, "You");
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
