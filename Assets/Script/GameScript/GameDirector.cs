using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    TouchManager _touch_manager;
    GameObject timetext;
    GameObject scoretext;
    GameObject generator;
    GameObject fadeout;
    GameObject hp;
    float time = 0;//時間を０スタートにする
    int score = 0;

    float life = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.timetext = GameObject.Find("Time");
        this.scoretext = GameObject.Find("Score");
        this.generator = GameObject.Find("KorippoGenerator");
        this.fadeout = GameObject.Find("Panel");
        this.hp = GameObject.Find("hpGauge");
        this._touch_manager = new TouchManager();
    }

    // Update is called once per frame
    void Update()
    {
        /*時間更新*/
        TimeSet();

        /*時間切れ動作*/
        if(life <= 0)
        {
            this.generator.GetComponent<KorippoGenerator>().StopGen();//こーりっぽの発生もストップ
            this.fadeout.GetComponent<FadeOut>().isFadeOut = true;//FadeOutスタート
            GameOver();

        }
        else
        {
            /*ゲームバランス調整*/
            if (this.time < 5)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.7f, 70, 2.0f, 10);
            }else if(this.time < 10)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.6f, 75, 1.2f, 10);
            }else if(this.time < 20)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.5f, 70, 1.0f, 20);
            }else if(this.time < 30)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.45f, 50, 1.0f, 20);
            }else if(this.time < 45)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.4f, 50, 0.8f, 30);
            }else if(this.time < 60)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.3f, 60, 0.7f, 40);
            }else if(this.time < 75)
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.25f, 70, 0.5f, 40);
            }
            else
            {
                generator.GetComponent<KorippoGenerator>().SetParameter(0.2f, 70, 0.3f, 50);
            }


            /*タップ操作*/
            this._touch_manager.update();
            TouchManager touch_state = this._touch_manager.GetTouch();

            if (touch_state._touch_frag == true)
            {
                Vector2 world_point = Camera.main.ScreenToWorldPoint(touch_state._touch_position);
                RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);
                if (hit)
                {
                    if(hit.collider.tag == "Korippo")
                    {
                        hit.collider.GetComponent<KorippoController>().Korippo_Click();
                    }
                    else if(hit.collider.tag == "KorippoEX")
                    {
                        hit.collider.GetComponent<KorippoController>().KorippoEX_Click();
                    }else if(hit.collider.tag == "Uni")
                    {
                        hit.collider.GetComponent<UniController>().Uni_Click();
                        hp.GetComponent<HPController>().Damage();
                        life --;
                    }
                }
            }

            /*スコア更新*/
            ScoreSet();
        }
    }

    void TimeSet()//制限時間を更新する
    {
        this.time += Time.deltaTime;
        this.timetext.GetComponent<Text>().text = this.time.ToString("F1");
    }

    void ScoreSet()
    {
        this.scoretext.GetComponent<Text>().text = this.score.ToString() + " point";
    }

    public void BrakeIce()
    {
        this.score += 100;
    }

    public void BrakeNice()
    {
        this.score += 150;
    }

    public void BrakeIceEX()
    {
        this.score += 500;
    }

    public void BrakeNiceEX()
    {
        this.score += 750;
    }

    public void TapUni()
    {
        if(score > 0)
        {
            this.score -= 500;
        }
    }

    void GameOver()
    {
        GameObject text = GameObject.Find("GameOver");
        GameObject score_final = GameObject.Find("Score_final");
        text.GetComponent<Text>().enabled = true;
        score_final.GetComponent<Text>().text = "Your Score is\n" + this.score.ToString();
        score_final.GetComponent<Text>().enabled = true;
    }

    public void Korippo_Crush()
    {
        this.life -= 0.5f;
        this.score -= 200;
        hp.GetComponent<HPController>().Damage2();
    }
}
