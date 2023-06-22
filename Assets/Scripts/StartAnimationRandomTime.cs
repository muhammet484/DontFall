
using UnityEngine;

public class StartAnimationRandomTime : MonoBehaviour
{
    [Tooltip("Min and max time as seconds")]
    [SerializeField] float min, max;
    [SerializeField] Animator animator;
    [SerializeField] bool DontStartSometimes = false;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(min, max);
        if (DontStartSometimes)
        {
            if (Random.value < 0.5f)
                Invoke("startAnimation", time);
        }
        else
        {
            Invoke("startAnimation", time);
        }
    }
    void startAnimation()
    {
        animator.enabled = true;
    }
}
