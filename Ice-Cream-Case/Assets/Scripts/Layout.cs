using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Layout : MonoBehaviour
{
    public static Layout Instance;


    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    [SerializeField] private int numTurns;
    [SerializeField] private int transformCount;
    [SerializeField] private GameObject debug;
    [SerializeField] private float heightPerIter;   
    private List<Transform> transforms = new List<Transform>(); 
    private int currentTransformIndex = 0;

    private void Start() {
        InitTransforms();
    }

    private void InitTransforms(){
        for(int i = 0;i<transformCount;i++){
            GameObject gObject = Instantiate(debug,
            new Vector3(((float)(transformCount - i) / transformCount) * Mathf.Sin(((float)i/transformCount)*Mathf.PI * numTurns * 2),
            heightPerIter * i,
            ((float)(transformCount - i) / transformCount) * Mathf.Cos(((float)i/transformCount)*Mathf.PI * numTurns * 2)),
            Quaternion.identity);
            transforms.Add(gObject.transform);


            

        }

    }

    public void AssignTransform(Transform tr,Transform iceCreamMacine){
        tr.DOMove(transforms[currentTransformIndex].position,.6f);
        tr.DOLocalRotateQuaternion(Quaternion.Euler(0f,(float)currentTransformIndex/transformCount * 360 * numTurns,-89.5f),.6f);
        iceCreamMacine.transform.position = new Vector3(transforms[currentTransformIndex].position.x,iceCreamMacine.transform.position.y,transforms[currentTransformIndex].position.z);
        currentTransformIndex++;
    }
}
