using UnityEngine;

public class DamageDealerBehaviour : MonoBehaviour {

    protected int baseDamage;
    protected int extraDamage;
    protected float damageMultiplier;

    public DamageDealerBehaviour() {
        baseDamage = 1;
        extraDamage = 0;
        damageMultiplier = 1;
    }

    public int GetBaseDamage() {
        return baseDamage;
    }

    public void SetBaseDamage(int damage) {
        this.baseDamage = damage;
    }

    public void SetExtraDamage(int extraDamage) {
        this.extraDamage = extraDamage;
    }

    public void SetDamageMultiplier(float damageMultiplier) {
        this.damageMultiplier = damageMultiplier;
    }

    public int GetTotalDamage() {
        return Mathf.CeilToInt((baseDamage + extraDamage) * damageMultiplier);
    }
}
