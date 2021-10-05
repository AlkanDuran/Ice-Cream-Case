using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IceCreamMaker : MonoBehaviour
{
    [SerializeField] private GameObject IceCreamPart;
    [SerializeField] private Transform iceCreamMachine;
    [SerializeField] private Material smurf;

    private void Start() {
        StartCoroutine(EjectIceCream());
        StartCoroutine(EjectIceCreamBlack());
    }

    IEnumerator EjectIceCream(){
        if(Input.GetMouseButton(0)){
            GameObject ice = Instantiate(IceCreamPart,new Vector3(iceCreamMachine.transform.position.x,5f,iceCreamMachine.transform.position.z),Quaternion.identity);
            Layout.Instance.AssignTransform(ice.transform,iceCreamMachine);
            yield return new WaitForSeconds(.01f);
            StartCoroutine(EjectIceCream());
        }
        else{
            yield return new WaitForSeconds(.01f);
            StartCoroutine(EjectIceCream());
        }
    }

    IEnumerator EjectIceCreamBlack(){
        if(Input.GetMouseButton(1)){
            GameObject ice = Instantiate(IceCreamPart,new Vector3(iceCreamMachine.transform.position.x,5f,iceCreamMachine.transform.position.z),Quaternion.identity);
            ice.GetComponent<MeshRenderer>().material = smurf;
            Layout.Instance.AssignTransform(ice.transform,iceCreamMachine);
            yield return new WaitForSeconds(.01f);
            StartCoroutine(EjectIceCreamBlack());
        }
        else{
            yield return new WaitForSeconds(.01f);
            StartCoroutine(EjectIceCreamBlack());
        }
    }
}
