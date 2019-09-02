﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPoint : MonoBehaviour
{
    GameSystem system;
    // Start is called before the first frame update
    void Start()
    {
        system = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    //카메라가 실제로 쳐다보는 지점을 계산
    void FixedUpdate()
    {
        Vector3 vec = PrefabSystem.instance.player.transform.position;   
        if (PrefabSystem.instance.player.GetIsAttackMode())
        {


            Vector3 vec2 = system.MousePoint();
            Vector3 sq = vec;
            if (Mathf.Abs(vec2.x - vec.x) > 2.5f)
            {
                sq.x = Mathf.Abs(vec2.x - (vec.x + 2.5f)) / 2;
                if (vec2.x >= vec.x)
                {
                    sq.x = sq.x + vec.x;

                }
                else
                {
                    sq.x = sq.x + vec2.x;
                }
                if (sq.x > PrefabSystem.instance.player.transform.position.x + 3.0f)
                {
                    sq.x = PrefabSystem.instance.player.transform.position.x + 3.0f;
                }
                else if (sq.x < PrefabSystem.instance.player.transform.position.x - 3.0f)
                {
                    sq.x = PrefabSystem.instance.player.transform.position.x - 3.0f;
                }
            }
            if (Mathf.Abs(vec2.z - vec.z) > 1.5f)
            {
                sq.z = Mathf.Abs(vec2.z - (vec.z + 1.5f)) / 2;

                if (vec2.z >= vec.z)
                {
                    sq.z = sq.z + vec.z;

                }
                else
                {
                    sq.z = sq.z + vec2.z;
                }
                if (sq.z > PrefabSystem.instance.player.transform.position.z + 2.0f)
                {
                    sq.z = PrefabSystem.instance.player.transform.position.z + 2.0f;
                }
                else if (sq.z < PrefabSystem.instance.player.transform.position.z -2.0f)
                {
                    sq.z = PrefabSystem.instance.player.transform.position.z - 2.0f;
                }
            }
            float x = Mathf.Lerp(transform.position.x, sq.x, Time.deltaTime * 1.5f);
            float z = Mathf.Lerp(transform.position.z, sq.z, Time.deltaTime * 1.5f);
            sq.x = x;
            sq.z = z;
            transform.position = sq;
        }
        else
        {
            float x = Mathf.Lerp(transform.position.x, PrefabSystem.instance.player.transform.position.x, Time.deltaTime * 1.5f);
            float z = Mathf.Lerp(transform.position.z, PrefabSystem.instance.player.transform.position.z, Time.deltaTime * 1.5f);
            vec.x = x;
            vec.z = z;
            transform.position = vec;
        }
    }

}
