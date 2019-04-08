﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Roll : MonoBehaviour
{
    NavMeshAgent agent;
    List<GameObject> activeBullet = new List<GameObject>();
    GameObject bullet;

    float delayTime;
    bool isPossibility_Roll = true;
    public void Setting(NavMeshAgent _agent,float _delayTime)
    {
        agent = _agent;
        delayTime = _delayTime;
    }

    public void Init()
    {

    }

    public RESULT IsBulletComeToMe()  // 총알이 나에게 오는가?
    {
        activeBullet = PrefabSystem.instance.Get_BulletPool();
        
        float distance;

        foreach( var obj in activeBullet)
        {
            distance = Mathf.Pow(transform.position.x - obj.transform.position.x, 2) + Mathf.Pow(transform.position.z - obj.transform.position.z, 2);
            if (distance <3.0f)
            {
                bullet = obj;
                return RESULT.SUCCESS ;
            }            
        }
        return RESULT.FAIL ;
    }

    public bool IsNotRollingCoolTime()  // 구르기가 쿨타임이 아닌가?
    {
        return isPossibility_Roll;
    }

    public bool Rolling()   // 구르기 액션
    {
        isPossibility_Roll = false;
        agent.isStopped = true;
        float rotateDegree = Mathf.Atan2(bullet.transform.position.x - transform.position.x, bullet.transform.position.z - transform.position.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0.0f, rotateDegree + 60.0f, 0.0f), Time.deltaTime * 10.0f);
        Invoke("Renew_Roll_DelayTime", delayTime);
        return true;
    }
    void Renew_Roll_DelayTime()
    {
        isPossibility_Roll = true;
    }


    
}
