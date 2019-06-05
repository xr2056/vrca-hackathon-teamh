using System.Collections; using System.Collections.Generic; using UnityEngine;  public class StartButtonSC : MonoBehaviour
{

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject capsulePrefab;     public GameObject spawner;

    void OnCollisionEnter(Collision col)
    {
           


        if (col.gameObject.tag == "hand")
        {
            //オブジェクトの初期化
            GameObject[] oldobjs = GameObject.FindGameObjectsWithTag("tsumiki");
            foreach (GameObject oldobj in oldobjs)
            {
                Destroy(oldobj);
            }             Instantiate(cubePrefab, spawner.transform.position, Quaternion.identity);             ////複数の場所に一気にオブジェクトを出す
            //for (int i = -2; i < 3; i += 2)
            //{
            //    int objrd = Random.Range(1, 11);
            //    GameObject obj = objrd > 8 ? capsulePrefab : (objrd > 5 ? spherePrefab : cubePrefab);
            //    Instantiate(obj, new Vector3(i, 2, 3), Quaternion.identity);
            //}
        }
    }
}