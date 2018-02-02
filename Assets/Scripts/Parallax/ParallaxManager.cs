using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour {

    [SerializeField]
    private List<Background> backgrounds;

    private void Update()
    {
        MoveBackgrounds();
    }

    private void MoveBackgrounds()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].Move();
        }
    }
}
