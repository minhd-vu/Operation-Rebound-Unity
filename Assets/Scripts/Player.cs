using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private float _health;
    public float health
    {
        get { return _health; }
        set
        {
            if ((_health = value) > maxHealth)
            {
                _health = maxHealth;
            }
            else if (_health <= 0)
            {
                FindObjectOfType<GameManager>().EndGame(score);
            }
        }
    }
    public float maxHealth;
    [SerializeField]
    private float healthPerSecond;
    [HideInInspector]
    public float healthPerSecondBonus;
    private float regenTimer;
    [SerializeField]
    private float regenTime;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject damageParticles;

    [HideInInspector]
    public int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private enum States
    {
        ONE_HAND,
        TWO_HAND,
    }

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        regenTimer = 0f;
        healthPerSecondBonus = 0f;
        score = 0;

        healthBar = Instantiate(healthBar);
        healthBar.GetComponent<HealthBar>().target = transform;

        weapon = Instantiate(weapon, transform);
        GetComponent<SpriteRenderer>().sprite = sprites[weapon.isOneHanded ? (int)States.ONE_HAND : (int)States.TWO_HAND];
    }

    // Update is called once per frame
    void Update()
    {
        if ((regenTimer += Time.deltaTime) >= regenTime)
        {
            health += healthPerSecond + healthPerSecondBonus;
            regenTimer = 0f;
        }

        // Update the health bar.
        healthBar.GetComponent<HealthBar>().image.fillAmount = health / maxHealth;
        scoreText.text = "Score: " + score;
    }

    /**
     * Deal damage to the player
     */
    public void damage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        Instantiate(damageParticles, transform);
    }
}
