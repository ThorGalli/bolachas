using UnityEngine;

public class MouseMove : MonoBehaviour {

    [SerializeField] protected float sensitivity;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            rigidBody.drag = 15;
            ControlPlayer();
        } else {
            rigidBody.drag = 0;
        }
    }

    void ControlPlayer() {
        Vector2 movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        rigidBody.AddForce(movement * sensitivity);
    }
}
