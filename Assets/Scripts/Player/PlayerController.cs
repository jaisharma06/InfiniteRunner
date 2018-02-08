using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Player attributes;
    [SerializeField]
    private Slider breathSlider;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject deathParticles;
    [SerializeField]
    private Rigidbody2D m_rigidbody;
    [SerializeField]
    private LayerMask groundLayer;

    private void Update()
    {
        Breath();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GetDamage(1f);
        }
    }

    public void Breath()
    {
        if (!(attributes.isRunning))
        {
            attributes.breath += Time.deltaTime / 7;
            attributes.breath = Mathf.Clamp(attributes.breath, 0, 1);
            animator.SetBool("isRunning", false);
        }
        else
        {
            attributes.breath -= Time.deltaTime / 3;
            attributes.breath = Mathf.Clamp(attributes.breath, 0, 1);
            if (attributes.breath > 0.1f)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        breathSlider.value = attributes.breath;
    }

    public void Slide()
    {

    }

    public void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        m_rigidbody.AddForce(new Vector2(0, attributes.jumpStrength));
    }

    private void GetDamage(float value)
    {
        attributes.health -= value;
        attributes.health = Mathf.Clamp(attributes.health, 1, 4);
        healthSlider.value = attributes.health;
        if (healthSlider.value == 1)
        {
            Dead();
        }
    }

    private bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer))
        {
            return true;
        }
        return false;
    }

    private void Dead()
    {
        attributes.isDead = true;
        deathParticles.SetActive(true);
    }
}
