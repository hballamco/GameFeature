using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] public Transform keyObj;
    [SerializeField] public GameObject fence;
    

    //components
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {

            fence.transform.Translate(Vector3.down * Time.deltaTime * 0.8f);
            DestroyFence();
        }
    }

    void DestroyFence()
    {
        Destroy(fence, 10f);
    }
}
