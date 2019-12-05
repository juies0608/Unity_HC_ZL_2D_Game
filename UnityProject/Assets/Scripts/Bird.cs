using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("跳躍高度"), Range(50, 1000)]
    public int jump = 50;
    [Header("是否死亡")]
    public bool dead;

    public GameObject goScore, goGM;
    [Header("剛體")]
    public Rigidbody2D r2d;

    public GameManager gm;

    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundJump, soundHit, soundAdd;
   

    /// <summary>
    /// 小雞跳躍功能
    /// </summary>
    private void Jump()
    {
        if (dead) return;
        // 如果 按下 左鍵
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("按下左鍵");

            goScore.SetActive(true);    // 分數 顯示
            goGM.SetActive(true);       // GM 顯示

            r2d.gravityScale = 1;       // 剛體.重力 = 1
            r2d.Sleep();                // 剛體.睡覺
            r2d.AddForce(new Vector2(0, jump)); //剛體.增加推力

           aud.PlayOneShot(soundJump, 1.5f);
                                                

        }
        print(r2d.velocity);
        r2d.SetRotation(5 * r2d.velocity.y);              //剛體.設定角度
    }

    /// <summary>
    /// 小雞死亡功能
    /// </summary>
    private void Dead()
    {
        if (dead) return; // 跳出此方法
   
        dead = true;
        gm.GameOver();
        goScore.SetActive(true);
        aud.PlayOneShot(soundHit, 1.5f);
    }

    /// <summary>
    /// 小雞通過水管
    /// </summary>
    private void PassPipe()
    {
        if (dead) return; // 跳出此方法

        print("加分!");
        aud.PlayOneShot(soundAdd, 2);
        gm.AddScore(1);
    }

    // 監聽玩家輸入：滑鼠、鍵盤、搖桿
    private void Update()
    {
        Jump();
    }

    // 碰撞事件：碰到其他碰撞器開始時執行一次 (碰到物件的碰撞資訊)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);

        Dead();
    }
    // 觸發事件：觸發其他碰撞器開始時執行一次 (針對勾選 IsTrigger 的物件)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "水管 - 上" || collision.gameObject.name == "水管 - 下")
        {
            Dead();
        }
        if (collision.gameObject.name == "加分區域")
        {
            PassPipe();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "加分區域")
        {
            PassPipe();
        }
    }
}