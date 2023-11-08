using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text dialogueText;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerFight = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerFight.GetComponent<Unit>();

        GameObject enemyFight = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyFight.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " approaches.";

        yield return new WaitForSeconds(2f);
        
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerBrag()
    {
        bool isLose = enemyUnit.TakeDamage(playerUnit.damage);

        dialogueText.text = "Your bragging successfully brings shame to his face.";

        yield return new WaitForSeconds(3f);

        if (isLose)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }


    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Mommy:Nice try, your kid is nice, but this reminds me of my daughter when...";
        yield return new WaitForSeconds(3f);

        bool isLose = playerUnit.TakeDamage(enemyUnit.damage);
        yield return new WaitForSeconds(1f);

        if (isLose)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "See? My daughter is this talented.";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "It's harder than I expected...";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "What will you do?";
    }

    public void OnBragButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerBrag());
    }
}
