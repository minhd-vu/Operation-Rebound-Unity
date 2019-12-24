using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;

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
    private Image healthBar;
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
        healthBar.GetComponent<Image>().fillAmount = health / maxHealth;
        scoreText.text = score + "";

        float shake = (maxHealth - health) / maxHealth * 2f;
        CameraShaker.Instance.ShakeOnce(shake, shake, 0.1f, Time.deltaTime);
    }

    /**
     * Deal damage to the player
     */
    public void damage(float damage)
    {
        if (!gameObject.GetComponent<PlayerController>().isDashing)
        {
            health -= damage;
            Instantiate(damageParticles, transform);
        }
    }
}
