using UnityEngine;

public class MouseMove : MonoBehaviour {

    [SerializeField] protected float moveForce;
    [SerializeField] protected float maxForce;
    [SerializeField] protected float drag;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        rigidBody.drag = drag;
        ControlPlayer();
    }

    void ControlPlayer() {
        Vector2 movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        movement *= moveForce;
        movement = Vector2.ClampMagnitude(movement, maxForce);
        rigidBody.AddForce(movement);
    }
}
