using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public IEnumerator Move(Transform t,Vector3 finish,int frames)
    {
        Vector3 speed = (finish-t.position)/frames;
        for (int i = 0; i < frames; i++)
        {
            t.position += speed;
            yield return null;
        }
    }


    public List<Transform> CamPoints;
    public List<Transform> Pics;
    public Transform focus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(focus!=null)transform.LookAt(focus);
    }
}
