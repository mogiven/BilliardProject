using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    public void ReactToHit()//球被击打执行的操作
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        this.transform.Rotate(-78,0,0);//做一些死亡的动作

        yield return new WaitForSeconds(1.5f);//等待几秒再执行消失

        Destroy(this.gameObject);
    }

}

