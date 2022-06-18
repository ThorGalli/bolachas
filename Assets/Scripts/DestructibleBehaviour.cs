using UnityEngine;

public class DestructibleBehaviour : MonoBehaviour {

    [SerializeField] protected int maxHealth;
    [SerializeField] protected Sprite[] sprites;

    private int currentHealth;
    private Sprite currentSprite;
    bool isAlive;

    private void OnEnable() {
        currentHealth = maxHealth;
        isAlive = true;
        UpdateSprite();
    }

    private void TakeDamage(int damage) {
        currentHealth -= damage;
        OnTakeDamage();
    }

    private void OnTakeDamage() {
        CheckDestruction();
        if (isAlive) {
            UpdateSprite();
        }
    }

    private void UpdateSprite() {
        if (sprites.Length >= currentHealth - 1) {
            currentSprite = sprites[currentHealth - 1];
        } else {
            Debug.Log("Sprite out of bound in sprites array.");
        }
        GetComponent<SpriteRenderer>().sprite = currentSprite;
    }

    private void CheckDestruction() {
        if (currentHealth <= 0) {
            isAlive = false;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DamageDealerBehaviour hitter = collision.gameObject.GetComponent<DamageDealerBehaviour>();

        if (hitter != null) {
            int damage = hitter.GetTotalDamage();
            TakeDamage(damage);
        }
    }
}