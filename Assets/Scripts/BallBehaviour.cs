using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    [Header("Damage")]

    [SerializeField] protected DamageDealerBehaviour damage;
    [SerializeField] protected int baseDamage;
    [SerializeField] protected float pinkMultiplier;

    [Header("Speed")]
    [Range(0, 50)]
    [SerializeField] protected float minSpeed;
    [Range(0, 50)]
    [SerializeField] protected float maxSpeed;
    [Space(5)]
    [Range(0, 10)]
    [SerializeField] protected float acceleration;
    [Range(0, 10)]
    [SerializeField] protected float drag;
    [Space(5)]
    [Header("Debug")]
    [SerializeField] protected float currentSpeed;

    protected bool locked = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Color vanilla;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        vanilla = new Color(0.92f, 0.60f, 0.27f, 1);
        gameObject.AddComponent<DamageDealerBehaviour>();
        damage.SetBaseDamage(baseDamage);
    }

    private void Update() {
        if (rb.velocity.magnitude >= maxSpeed) {
            sprite.color = Color.magenta;
            damage.SetDamageMultiplier(pinkMultiplier);
        } else {
            sprite.color = vanilla;
            damage.SetDamageMultiplier(1);
        }
    }

    void FixedUpdate() {
        ControlBallLocking();
        if (!locked) {
            ControlSpeed();
            PreventWallStuck();
        }
        currentSpeed = rb.velocity.magnitude;
    }

    private void ControlBallLocking() {
        if (rb.velocity.magnitude >= minSpeed / 100) {
            locked = false;
        } else {
            rb.velocity = Vector2.zero;
            locked = true;
        }
    }

    private void PreventWallStuck() {
        if (Mathf.Abs(rb.velocity.x) <= 0.1f)
            rb.AddForce(RandomVector(1, 0));
        if (Mathf.Abs(rb.velocity.y) <= 0.1f)
            rb.AddForce(RandomVector(0, 1));
    }

    private Vector2 RandomVector(float maxAbsX = 1, float maxAbsY = 1) {
        return new Vector2(Random.Range(-maxAbsX, maxAbsX), Random.Range(-maxAbsY, maxAbsY)).normalized;
    }

    private void ControlSpeed() {
        if (rb.velocity.magnitude < minSpeed) {
            rb.AddForce(rb.velocity.normalized * acceleration);
        }
        if (rb.velocity.magnitude > maxSpeed) {
            rb.drag = drag;
        } else {
            rb.drag = 0;
        }
    }
}
