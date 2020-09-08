
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setkaskript : MonoBehaviour{
public int height = 1;
public Transform objec;

Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
         transform.position = new Vector3(1.5f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        position = objec.position;
        position.z = 0;
        position.x = 1.5f;
        position.y = position.y - height;
        transform.position = Vector3.Lerp (transform.position, position, 1f * Time.deltaTime );
    }
}