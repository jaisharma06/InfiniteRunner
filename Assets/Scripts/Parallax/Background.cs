using UnityEngine;

public class Background : MonoBehaviour{
    public SpriteRenderer left_sprite;
    public SpriteRenderer right_sprite;
    public float speed = 1f;
    public int direction = -1;

    public SpriteRenderer m_sprite { get { return left_sprite; } }
    public float boundX { get { return m_sprite.size.x; } }

    private Transform left_sprite_transform;
    private Transform right_sprite_transform;

    private void Start()
    {
        left_sprite_transform = left_sprite.transform;
        right_sprite_transform = right_sprite.transform;
    }

    public void Move()
    {
        if ((left_sprite_transform.position.x < -boundX))
        {
            var position = left_sprite_transform.position;
            position.x = right_sprite_transform.position.x + boundX;
            left_sprite_transform.position = position;
        }
        else if ((right_sprite_transform.position.x < -boundX))
        {
            var position = right_sprite_transform.position;
            position.x = left_sprite_transform.position.x + boundX;
            right_sprite_transform.position = position;
        }

        left_sprite_transform.Translate(Time.deltaTime * speed * direction, 0, 0);
        right_sprite_transform.Translate(Time.deltaTime * speed * direction, 0, 0);
    }
}
