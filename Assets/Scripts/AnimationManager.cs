using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public List<GameObject> animations;

    public int GetCount() {
        return animations.Count;
    }

    public void Activate(int index) {
        animations[index].SetActive(true);
    }

    public void DeActivate(int index) {
        animations[index].SetActive(false);
    }
}
