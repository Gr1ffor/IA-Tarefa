using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercicio4 : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float lerpTime;
    [SerializeField] Vector3[] positions;
    int posIndex = 0; int length; float p = 0f;



    // Start is called before the first frame update
    void Start()
    {
        length = positions.Length;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, positions[posIndex], lerpTime * Time.deltaTime);
        p = Mathf.Lerp(p, 1f, lerpTime * Time.deltaTime);
        if (p > .9f)
        {
            p = 0f;
            posIndex++;
            posIndex = (posIndex >= length) ? 0 : posIndex;
        }

    }
}