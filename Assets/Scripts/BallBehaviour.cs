using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    [Header("Speed Controls")]
    [Range(0, 20)]
    [SerializeField] protected float minSpeed;
    [Range(0, 40)]
    [SerializeField] protected float maxSpeed;

    [Range(0, 5)]
    [SerializeField] protected float speedStep;

    [Space(10)]
    [SerializeField] protected float currentSpeed;

    protected bool locked = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (rb.velocity.magnitude >= maxSpeed) {
            sprite.color = Color.red;
        } else {
            sprite.color = Color.white;
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
        if (rb.velocity.magnitude >= minSpeed / 4) {
            locked = false;
        } else {
            rb.velocity = Vector2.zero;
            locked = true;
        }
    }

    private void PreventWallStuck() {
        if (Mathf.Abs(rb.velocity.x) <= 0.5f)
            rb.AddForce(RandomVector(1, 0));
        if (Mathf.Abs(rb.velocity.y) <= 0.5f)
            rb.AddForce(RandomVector(0, 1));
    }

    private Vector2 RandomVector(float maxAbsX = 1, float maxAbsY = 1) {
        return new Vector2(Random.Range(-maxAbsX, maxAbsX), Random.Range(-maxAbsY, maxAbsY)).normalized;
    }

    private void ControlSpeed() {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.drag = speedStep / 2;
        } else {
            rb.drag = 0;
        }
        if (rb.velocity.magnitude < minSpeed) {
            rb.AddForce(rb.velocity.normalized * speedStep);
        }
    }
}
