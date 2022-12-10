using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bounce : MonoBehaviour
{

    [SerializeField] GameObject toBouince;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void DoAnim(float speed)
    {
        StartCoroutine(Bouince(speed));
    }


    IEnumerator Bouince(float speed)
    {
        float time = 0;
        Vector3 startScale = toBouince.transform.localScale;
        while (time < 1)
        {
            var y = startScale.y;
            toBouince.transform.localScale = new Vector3(startScale.x, ((4 * (1-time) * ((1-time) - 1))+1)*0.5f+0.5f, startScale.z);
            time += Time.deltaTime * speed;
            yield return null;
        }
    }
}
