using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyObject
{
    public SpriteRenderer Spr; // 表示スプライト
    public Animator anm; // アニメーションコンポーネント
    private GameObject Player; //プレイヤーの座標取得用
    private Vector2 TargetPos; //プレイヤーの位置情報
    public GameObject HitEffect;
    public GameObject DeathEffect;

    //ここからステータス
    [SerializeField] public int Hp = 10; //HP
    [SerializeField] public int Atk = 1; //攻撃力
    [SerializeField] public int Def = 1; //防御力

    [SerializeField] GameObject Item = default;

    [SerializeField] GameObject attack = default;

    public PlayerController playerController;

    Animator animator;
    //ここまでステータス

    private void Start()
    {
        Hp = 10;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(Item, this.transform.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.L))
        {
            Attack();
        }
        else
        {
            attack.SetActive(false);
        }
    }
    public void MoveEnemy()
    {
        // PLAYERタグの付いたオブジェクトを取得する
        Player = GameObject.FindGameObjectWithTag("Player");
        TargetPos = Player.transform.position;
        int Xdir = 0;
        int Ydir = 0;
        Xdir = (int)TargetPos.x - (int)this.transform.position.x;
        Ydir = (int)TargetPos.y - (int)this.transform.position.y;
        int AbsXdir = System.Math.Abs(Xdir); //絶対値を計算
        int AbsYdir = System.Math.Abs(Ydir); //絶対値を計算

        //５マス以上離れいている時はエネミーは移動停止
        if (AbsXdir > 5 || AbsYdir > 5)
        {
            return;
        }
        //プレイヤーとの座標差がX軸の方が大きいとき
        else if (AbsXdir > AbsYdir)
        {
            Xdir = Xdir / AbsXdir;
            AttemptMove(Xdir, 0);
        }
        //プレイヤーとの座標差がY軸の方が大きいとき
        else if (AbsXdir < AbsYdir)
        {
            Ydir = Ydir / AbsYdir;
            AttemptMove(0, Ydir);
        }
        //プレイヤーとの座標差がX軸・Y軸で等しい＝斜め45°にプレイヤーがいる
        else if (AbsXdir == AbsYdir)
        {
            Xdir = Xdir / AbsXdir;
            Ydir = Ydir / AbsYdir;
            AttemptMove(Xdir, Ydir);
        }
    }

    //継承クラスMovingObjectのプレイヤー移動処理を実行
    protected override void AttemptMove(int Xdir, int Ydir)
    {
        base.AttemptMove(Xdir, Ydir);
    }

    protected override void OnCantMove(GameObject hitComponent)
    {
        //衝突判定のあったオブジェクトの関数を取得し、変数を代入可能にする
        PlayerController Script = hitComponent.GetComponent<PlayerController>();
        //ダメージ計算
        int Damage = Atk * Atk / (Atk + PlayerController.Def);
        //オブジェクトのHP変数にダメージを与える
        PlayerController.Hp -= Damage;
        Instantiate(HitEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
        ////HPが0以下になったら敵をDestroyして死亡エフェクトを出すこと
        //if (Script.Hp <= 0)
        //{
        //    Destroy(hitComponent);
        //    Instantiate(DeathEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
        //}
        Debug.Log("敵はあなたに" + Damage + "のダメージを与えた");
        Debug.Log("あなたの残りHPは" + PlayerController.Hp);
    }

    //private void Destroy(GameObject hitComponent)
    //{
    //    throw new NotImplementedException();
    //}

    //private void Instantiate(GameObject hitEffect, Vector3 vector3, Quaternion identity)
    //{
    //    throw new NotImplementedException();
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            int Atk;

            Atk = PlayerController.Atk;

            Hp -= Atk;
        }
    }

    void Attack()
    {
        attack.SetActive(true);
    }
}
