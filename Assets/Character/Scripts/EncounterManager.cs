using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EncounterManager : MonoBehaviour
{
    GameObject meleeAttackButton, rangedAttackButton, magicAttackButton;
    GameObject playerHealthText, enemyHealthText;

    int playerHealth = 20;
    int enemyHealth = 10;

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

        playerHealthText.GetComponent<Text>().text = playerHealth + "";
        enemyHealthText.GetComponent<Text>().text = enemyHealth + "";
        meleeAttackButton.GetComponent<Button>().onClick.AddListener(MeleeAttackButtonPressed);
        rangedAttackButton.GetComponent<Button>().onClick.AddListener(RangedAttackButtonPressed);
        magicAttackButton.GetComponent<Button>().onClick.AddListener(MagicAttackButtonPressed);
    }

    void EnemyAttack()
    {
        if (Random.Range(1,100) > 80)
        {
            // Special attack
            playerHealth -= Random.Range(3, 6);
        } 
        else
        {
            // Normal attack
            playerHealth -= Random.Range(1, 4);
        }

        playerHealthText.GetComponent<Text>().text = playerHealth + "";
    }

    void MeleeAttackButtonPressed()
    {
        enemyHealth -= Random.Range(1, 3);
        enemyHealthText.GetComponent<Text>().text = enemyHealth + "";
        EnemyAttack();
        checkHealth();
    }

    void RangedAttackButtonPressed()
    {
        enemyHealth -= Random.Range(1, 5);
        enemyHealthText.GetComponent<Text>().text = enemyHealth + "";
        EnemyAttack();

        checkHealth();
    }

    void MagicAttackButtonPressed()
    {
        enemyHealth -= Random.Range(2, 7);
        enemyHealthText.GetComponent<Text>().text = enemyHealth + "";
        EnemyAttack();

        checkHealth();
    }

    void checkHealth()
    {
        if (enemyHealth <= 0 || playerHealth <= 0)
        {
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
