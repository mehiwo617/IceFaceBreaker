using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
	float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

	float delta = 0;

	public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
	public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

	public bool gameOver = false;

	Image fadeImage;                //透明度を変更するパネルのイメージ

	void Start()
	{
		fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
	}

	void Update()
	{
		if (isFadeIn)
		{
			StartFadeIn();
		}

		if (isFadeOut)
		{
			StartFadeOut();
		}

        if (gameOver)
        {
			this.delta += Time.deltaTime;
			if(delta > 3.0f)
            {
                SceneManager.LoadScene("StartScene");
			}
		}
	}

	public void StartFadeIn()
	{
		alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha();                      //b)変更した不透明度パネルに反映する
		if (alfa <= 0)
		{                    //c)完全に透明になったら処理を抜ける
			isFadeIn = false;
			fadeImage.enabled = false;    //d)パネルの表示をオフにする
		}
	}

	public void StartFadeOut()
	{
		if (alfa >= 0.7)
		{             // d)完全に不透明になったら処理を抜ける
			isFadeOut = false;
			gameOver = true;
        }
        else
        {
			fadeImage.enabled = true;  // a)パネルの表示をオンにする
			alfa += fadeSpeed;         // b)不透明度を徐々にあげる
			SetAlpha();
		}
	}

	void SetAlpha()
	{
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}
