using UnityEngine;

public class TrailBehaviour : MonoBehaviour {

    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] float duration;

    private TrailRenderer trail;
    private Color defaultColor;

    void Start() {
        trail = this.GetComponent<TrailRenderer>();
        defaultColor = trail.startColor;
    }

    // Update is called once per frame
    void Update() {
        if (sprite.color.Equals(Color.magenta)) {
            trail.startColor = Color.magenta;
            trail.time = duration * 1.5f;
        } else {
            trail.startColor = defaultColor;
            trail.time = duration;
        }
    }
}
