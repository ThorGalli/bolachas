using UnityEngine;

public class TrailBehaviour : MonoBehaviour {

    [SerializeField] protected SpriteRenderer sprite;
    private TrailRenderer trail;
    private Color defaultColor;

    void Start() {
        trail = this.GetComponent<TrailRenderer>();
        defaultColor = trail.startColor;
    }

    // Update is called once per frame
    void Update() {
        if (sprite.color.Equals(Color.red)) {
            trail.startColor = Color.red;
        } else {
            trail.startColor = defaultColor;
        }
    }
}
