using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private Player attributes;

    public void Breath()
    {
        if (!attributes.isRunning)
        {
            attributes.breath += Time.deltaTime;
            attributes.breath = Mathf.Clamp(attributes.breath, 0, 100);
            return;
        }

        attributes.breath -= Time.deltaTime;
        attributes.breath = Mathf.Clamp(attributes.breath, 0, 100);
    }

    public void Slide()
    {

    }

    public void Jump()
    {

    }
}
