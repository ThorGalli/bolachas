using UnityEngine;

public class DamageDealerBehaviour : MonoBehaviour {
    [SerializeField] protected int damage;

    public int GetDamage() {
        return damage;
    }
}
