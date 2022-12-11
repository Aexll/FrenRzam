using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MirorXY : MonoBehaviour
{

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float speed = 0.1f;

    private void Start()
    {
        StartCoroutine(FlipFlop());
    }


    private IEnumerator FlipFlop()
    {
        while (true)
        {
            sprite.flipX = !sprite.flipX;
            yield return new WaitForSeconds(speed);
            sprite.flipY = !sprite.flipY;
            yield return new WaitForSeconds(speed);
            sprite.flipX = !sprite.flipX;
            yield return new WaitForSeconds(speed);
            sprite.flipY = !sprite.flipY;
            yield return new WaitForSeconds(speed);
        }
    }
}
