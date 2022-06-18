using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour {

    [SerializeField] protected float moveForce;
    [SerializeField] protected float maxForce;
    [SerializeField] protected float drag;
    [SerializeField] protected ParticleSystem hitPulse;
    private Rigidbody2D rigidBody;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        HandleInput();
    }

    void FixedUpdate() {
        UpdateDrag();
        Move();
    }

    void UpdateDrag() {
        rigidBody.drag = drag;
    }

    private void HandleInput() {
        movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    void Move() {
        movement *= moveForce;
        movement = Vector2.ClampMagnitude(movement, maxForce);
        rigidBody.AddForce(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Transform other = collision.transform;
        if (other.GetComponent<BallBehaviour>() != null) {
            hitPulse.Play();
        }
    }
}
