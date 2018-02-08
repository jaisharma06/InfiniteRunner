using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class InputHandler : MonoBehaviour {

    [SerializeField]
    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        if (!playerController)
        {
            playerController = GetComponent<PlayerController>();
        }
	}

    public void Breathing(bool breathing)
    {
        playerController.attributes.isRunning = breathing;
    }
}
