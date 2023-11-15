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
    public TMP_Text HPText;

    private List<string> dialogues;

    private bool processing = false;

    /*private int LinesCount
    {
        get
        {
            return linesCount;
        }
        set
        {
            linesCount = value;
        }
    }

    private int linesCount;

    private string CurrentLines
    {
        get
        {
            return currentLines;
        }
        set
        {
            currentLines = value;
        }
    }

    private string currentLines;

    [SerializeField]
    private DiaManager diaManager;*/

    public BattleState state;


    // Start is called before the first frame update
    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        //CurrentLines = lines[LinesCount];
        //linesCount = lines.Count;
    }

    /*string Linesmanage.UpdateDialogues()
    {
        LinesCount++;
        CurrentLines = lines[LinesCount];
        CurrentLines = CurrentLines.Substring(1);
        return CurrentLines;
    }*/

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            dialogueText.enabled = true;
        }
        else
        {
            dialogueText.enabled = false;
        }
    }

    IEnumerator SetupBattle()
    {
        GameObject playerFight = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerFight.GetComponent<Unit>();

        GameObject enemyFight = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyFight.GetComponent<Unit>();


        dialogueText.text = "Mommy and her daughter approaches!";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerBrag()
    {
        bool isLose = enemyUnit.TakeDamage(playerUnit.damage);
        Debug.Log("Health minus");

        dialogueText.text = "You: My daughter got 3 A+ out of 4 last semester, have I talked you about this?";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "[Your bragging successfully worked. You can see mommy's face turning red.]";
        yield return new WaitForSeconds(3f);


        //HPText.text = enemyUnit.unitName + "'s HP - " + enemyUnit.takeDamage;
        //yield return new WaitForSeconds(2f);

        //HPText.text = enemyUnit.unitName + "'s current HP is " + (enemyUnit.currentHP) + ", " + playerUnit.unitName + "'s current HP is " + (playerUnit.currentHP) + ".";
        //yield return new WaitForSeconds(3f);

        dialogueText.text = "[Mommy - 10 HP.]";
        yield return new WaitForSeconds(2f);

        if (isLose)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            dialogueText.text = "Mommy: Sure thing, babe. Your girl is talented.";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "Mommy: But that also reminds me of the spellingbee competition last year.";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "Mommy: That made MY daughter a star, Ooo. First prize.";
            yield return new WaitForSeconds(2f);

            dialogueText.text = "[What? Spellingbee? My daughter never even liked that one, come on!]";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "[You - 10HP.]";
            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerDthr()
    {
        bool isLose = enemyUnit.TakeDamage(playerUnit.damage);

        dialogueText.text = "You: Hey sweetie can you say something?";
        yield return new WaitForSeconds(2f);

        dialogueText.text = "Your daughter: Uhh..should I mention about my singing competition last year?";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "Your daughter: I don't know... I got second prize but win a lot of friends I guess?";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "You: See? That's my girl.";
        yield return new WaitForSeconds(2f);

        dialogueText.text = "[Mommy seems to be smiling at this, Damn I should know this was a bad idea!]";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "[Mommy - 10 HP.]";
        yield return new WaitForSeconds(2f);

        if (isLose)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            dialogueText.text = "Mommy: Well, why don't you tell us about yourself, honey?";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "Mommy's daughter: I don't have much to say, but I can tell you about my Summer Camp medal this year. I got this because I was the most popular one among the kids. The medal looks shiny, I like that.";
            yield return new WaitForSeconds(4f);

            dialogueText.text = "Mommy: So do I.";
            yield return new WaitForSeconds(2f);

            dialogueText.text = "[You don't really want to talk about how your daughter used to almost burn the Summer Camp tent. Accidentally.]";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "[You - 20 HP.]";
            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerItem()
    {
        bool isLose = enemyUnit.TakeDamage(playerUnit.damage);

        dialogueText.text = "The Famliy photo:";
        yield return new WaitForSeconds(1f);

        dialogueText.text = "You: Have you seen my sweet lil'potato when she was 1? She learned to say 'ma' when she was only 5 month old.";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "[This gives a heavy shot towards mommy, her daughter could only giggle at that age.]";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "[Mommy - 30 HP.]";
        yield return new WaitForSeconds(2f);

        if (isLose)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            dialogueText.text = "Mommy: She must have a good family teacher, am I right?";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "Mommy: My daughter used to have other specialtis when she was young.";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "Mommy: Can you believe this? She started to bake bread with me when she learned how to walk.";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "[Isn't that a little to dangerous for a kid at that age?]";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "[You wondered, but hoping your daughter can bake desserts with you sometimes.]";
            yield return new WaitForSeconds(3f);

            dialogueText.text = "[You - 10HP.]";
            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerFlee()
    {
        //bool isLose = enemyUnit.TakeDamage(playerUnit.damage);

        dialogueText.text = "You: I don't think I want to continue this...";
        yield return new WaitForSeconds(2f);

        dialogueText.text = "You: Alright, I admit both of our girls are great.";
        yield return new WaitForSeconds(2f);

        dialogueText.text = "You: why don't you two go play and leave the adults some space, sweetie?";
        yield return new WaitForSeconds(2f);

        dialogueText.text = "[You give up this daughter competition, your HP is now 0.]";
        yield return new WaitForSeconds(2f);

        EndBattle();
    }

    IEnumerator EnemyTurn()
    {
        //dialogueText.text = "Mommy:Nice try, your kid is nice, but this reminds me of my daughter when...";
        //yield return new WaitForSeconds(3f);

        bool isLose = playerUnit.TakeDamage(enemyUnit.damage);
        yield return new WaitForSeconds(1f);

        if (isLose)
        {
            dialogueText.text = "Mommy: It's nice to have a conversation like this, don't you agree?";
            yield return new WaitForSeconds(2f);

            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            dialogueText.text = "Mommy: How about your girl?";
            yield return new WaitForSeconds(2f);

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You: See? My daughter is this talented.";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You: It's harder than I expected.";
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

    public void OnDaughterButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerDthr());
    }

    public void OnItemButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerItem());
    }

    public void OnFleeButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerFlee());
    }
}
