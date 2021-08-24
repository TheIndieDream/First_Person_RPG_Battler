using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Combo Strategy",
    menuName = "Attack Strategy.../Melee Combo")]
public class MeleeComboStrategy : AttackStrategy
{
    public int NumberOfAttacks;
    public float minTimeBetweenAttacks;
    public float maxTimeBetweenAttacks;

    //TODO: The parameters for animation speed will need to be driven by the 
    //player's attack speed stat (or some weapon parameters). Might be better
    //to use animation events to open and close the combo window?

    private int attackCounter = 0;
    private float timer = 0.0f;

    private void OnEnable()
    {
        attackCounter = 0;
        timer = 0.0f;
    }

    public override void Execute(FighterComponent fighter)
    {
        fighter.StateData.CanAttack = false;
        fighter.WeaponAttackResponse.Invoke(attackCounter);

        if (attackCounter + 1 == NumberOfAttacks)
        {
            attackCounter = 0;
        }
        else
        {
            attackCounter++;
        }

        fighter.StopAllCoroutines();
        fighter.StartCoroutine(AttackTimer(fighter));
    }
    private IEnumerator AttackTimer(FighterComponent fighter)
    {
        timer = 0.0f;
        while(timer < maxTimeBetweenAttacks)
        {
            timer += Time.deltaTime;
            if(timer >= minTimeBetweenAttacks)
            {
                fighter.StateData.CanAttack = true;
            }
            if(timer >= maxTimeBetweenAttacks)
            {
                attackCounter = 0;
                yield break;
            }
            yield return null;
        }
    }
}
