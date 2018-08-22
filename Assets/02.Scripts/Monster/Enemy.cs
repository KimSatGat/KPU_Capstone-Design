﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMY_STATE { NONE, PATROL, TRACE }

public abstract class Enemy : MoveObject {

    GameSystem system;
    protected Animator enemyAni;

    protected STATE eState = STATE.STAND;
    [SerializeField]
    protected ENEMY_STATE eEnemy_State = ENEMY_STATE.NONE;
    protected void Init()        //하위에서 호출해야함       //그리고 웬만하면 모든 멤버변수를 여기서 초기화해야함
    {
        system = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        enemyAni = GetComponent<Animator>();

        StartCoroutine(CheckPlayerInterface());
        obj = system.pPlayer2.gameObject;
    }

    public delegate ENEMY_STATE GetTraceState( ENEMY_STATE _Enemy_State );
    public GameObject obj;
    private IEnumerator CheckPlayerInterface()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(CheckPlayerInterface());
    }

    float detectf = 0.0f;
    float tracef = 0.0f;
    protected void SettingPlayerDistance(float _detect = 10.0f, float _trace = 5.0f)
    {
        detectf = _detect;
        tracef = _trace;
    }

    void OnTriggerEnter(Collider _obj)
    {
        /*
        if (_obj.tag == "Bullet")
        {
            _obj.gameObject.SetActive(false);
            Debug.Log("총알이 적과부딪힘");
            if (hp.getHp() <= 0)
            {
                eState = STATE.DIE;
            }
        }
        */
    }

    protected void BaseRender()
    {
        switch(eState)
        {
            case STATE.ATTACK:

                break;

        }
    }
}
