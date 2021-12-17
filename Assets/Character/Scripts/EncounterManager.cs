using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EncounterManager : MonoBehaviour
{
    GameObject meleeAttackButton, rangedAttackButton, magicAttackButton;
    GameObject playerHealthText, enemyHealthText;

    public int startPlayerHealth = 20;
    public int startEnemyHealth = 10;

    private int m_curr_player_hp;
    private int m_curr_enemy_hp;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == "MeleeAttackButton")
            {
                meleeAttackButton = obj;
            }
            else if (obj.name == "RangedAttackButton")
            {
                rangedAttackButton = obj;
            }
            else if (obj.name == "MagicAttackButton")
            {
                magicAttackButton = obj;
            }
            else if (obj.name == "PlayerHealthText")
            {
                playerHealthText = obj;
            }
            else if (obj.name == "EnemyHealthText")
            {
                enemyHealthText = obj;
            }
        }

        m_curr_enemy_hp = startEnemyHealth;
        m_curr_player_hp = startPlayerHealth;

        playerHealthText.GetComponent<Text>().text = m_curr_player_hp + "";
        enemyHealthText.GetComponent<Text>().text = m_curr_enemy_hp + "";
        meleeAttackButton.GetComponent<Button>().onClick.AddListener(MeleeAttackButtonPressed);
        rangedAttackButton.GetComponent<Button>().onClick.AddListener(RangedAttackButtonPressed);
        magicAttackButton.GetComponent<Button>().onClick.AddListener(MagicAttackButtonPressed);
    }

    void EnemyAttack()
    {
        if (Random.Range(1,100) > 80)
        {
            // Special attack
            m_curr_player_hp -= Random.Range(3, 6);
        } 
        else
        {
            // Normal attack
            m_curr_player_hp -= Random.Range(1, 4);
        }

        playerHealthText.GetComponent<Text>().text = m_curr_player_hp + "";
    }

    void MeleeAttackButtonPressed()
    {
        m_curr_enemy_hp -= Random.Range(1, 3);
        enemyHealthText.GetComponent<Text>().text = m_curr_enemy_hp + "";
        EnemyAttack();
        checkHealth();
    }

    void RangedAttackButtonPressed()
    {
        m_curr_enemy_hp -= Random.Range(1, 5);
        enemyHealthText.GetComponent<Text>().text = m_curr_enemy_hp + "";
        EnemyAttack();

        checkHealth();
    }

    void MagicAttackButtonPressed()
    {
        m_curr_enemy_hp -= Random.Range(2, 7);
        enemyHealthText.GetComponent<Text>().text = m_curr_enemy_hp + "";
        EnemyAttack();

        checkHealth();
    }

    void checkHealth()
    {
        if (m_curr_enemy_hp <= 0 || m_curr_player_hp <= 0)
        {
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
