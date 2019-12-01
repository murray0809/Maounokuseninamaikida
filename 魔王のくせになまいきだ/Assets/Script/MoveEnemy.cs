using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float MoveTime = 0.1f;
    private float InverseMoveTime;

    protected virtual void AttemptMove(int Xdir, int Ydir)
    {
        Vector2 StartPosition = transform.position;
        Vector2 EndPosition = StartPosition + new Vector2(Xdir, Ydir);
        //移動判定用　衝突するレイヤーはすべて入れる
        int LayerObj = LayerMask.GetMask(new string[] { "Chara", "Object" });
        //攻撃判定用　HPのあるオブジェクトを置くレイヤーは全て入れる
        int LayerCha = LayerMask.GetMask(new string[] { "Chara" });

        this.rb = GetComponent<Rigidbody2D>();
        this.boxCollider = GetComponent<BoxCollider2D>();

        //自身の衝突判定を無くしてPhysics2Dの誤確認を無くす
        boxCollider.enabled = false;
        //移動先に障害物があるか判定する
        RaycastHit2D HitObj = Physics2D.Linecast(StartPosition, EndPosition, LayerObj);
        RaycastHit2D HitCha = Physics2D.Linecast(StartPosition, EndPosition, LayerCha);
        //衝突判定を戻す
        boxCollider.enabled = true;

        //RaycastHit2Dで移動先に障害物が無ければMovementを実行
        if (HitObj.transform == null)
        {
            StartCoroutine(Movement(EndPosition));
        }
        //RaycastHit2Dで移動先にプレイヤーかエネミーがいればHitComponentに入れてOnCantMoveを実行
        else if (HitCha.transform != null)
        {
            GameObject HitComponent = HitCha.transform.gameObject;
            OnCantMove(HitComponent);
        }


    }

    protected IEnumerator Movement(Vector3 EndPosition)
    {
        float sqrRemainingDistance = (transform.position - EndPosition).sqrMagnitude;
        InverseMoveTime = 1f / MoveTime;
        //EndPositionまでスムーズに移動するらしい　UNITY公式コード丸パクリ
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 NewPosition = Vector3.MoveTowards(rb.position, EndPosition, InverseMoveTime * Time.deltaTime);
            rb.MovePosition(NewPosition);
            sqrRemainingDistance = (transform.position - EndPosition).sqrMagnitude;
            yield return null;
        }
    }

    protected abstract void OnCantMove(GameObject hitComponent);
}