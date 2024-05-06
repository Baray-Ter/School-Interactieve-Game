using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Before : MonoBehaviour
{
    public ModelList modelList;

    public void GoToModelBefore()
    {
        if (Scroll.count > 1)
        {
            float distanceBefore = modelList.differentScrollDistanceForEachModel[Scroll.count - 2];

            foreach (GameObject model in modelList.ModelsToScroll)
            {
                model.transform.position = model.transform.position + new Vector3(Mathf.Abs(distanceBefore), 0, 0);
            }

            //print(modelList.differentScrollDistanceForEachModel[Scroll.count] - 1);    
            Scroll.count--;
        }
    }
}
