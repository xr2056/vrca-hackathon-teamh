using System.Collections; using System.Collections.Generic; using UnityEngine;  public class SpawnerSC : MonoBehaviour {      public GameObject spawner;     public GameObject[] BlockType;     bool run = false;     public Transform parent;

    //一箇所に一定時間ごとにオブジェクトを出す
    //オブジェクトの発生場所から少し先に不可視のCollider(IsTrigger)を置く
    void OnTriggerExit(Collider col){         if (col.gameObject.tag == "floor"&& !run)         {             StartCoroutine("ObjectInstantiateCoroutine");         }     }      //複数のCollider対策のコルーチン     IEnumerator ObjectInstantiateCoroutine()
    {
        run = true;         int number = Random.Range(0, BlockType.Length);
        Instantiate(BlockType[number], spawner.transform.position, Quaternion.identity,parent);         yield return new WaitForSeconds(2);         run = false;
    } } 