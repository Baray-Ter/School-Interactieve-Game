using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextModel : MonoBehaviour
{
    public ModelList modelList;

    public void GoToNextModel()
    {
        if (modelList.ModelsToScroll.Length > Scroll.count)
        {
            print("nextmodel");
            foreach (var item in modelList.ModelsToScroll)
            {
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.transform.rotation = Quaternion.identity;
            }

            foreach (var item in modelList.ModelsToScroll)
            {
                item.transform.position = item.transform.position + new Vector3(modelList.differentScrollDistanceForEachModel[Scroll.count - 1], 0, 0);
            }

            //print(modelList.differentScrollDistanceForEachModel[Scroll.count - 1]);

            Scroll.count++;
        }
    }
}
