using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    [SerializeField]
    int count;//クリック数.
    [SerializeField]
    Text text;
    [SerializeField]
    Text countText;

    float time;//ゲーム開始からの時間.
    bool isStart = true;

    /// <summary>
    /// よーいドン、の準備.
    /// 格ゲーならここでライフバーを出したり、戦う前のアレコレをする.
    /// </summary>
    /// <returns></returns>
	IEnumerator Start () {
        text.text = "";
        countText.text = "";
        yield return new WaitForSeconds(1);
        text.text = "連打";
        for (int i = 0; i < 3; i++) {
            text.text += "・";
            yield return new WaitForSeconds(0.3f);
        }
        text.text = "開始!!";
        yield return new WaitForSeconds(1);
        isStart = false;
	}
	
	/// <summary>
    /// ゲームのメイン部分.
    /// </summary>
	void Update () {
        if (!isStart) {
            if (time <= 20) {
                countText.text = "COUNT:" + count;
                text.text = "連打しろ!!";
                if (Input.GetMouseButtonDown(0) || Input.anyKeyDown) {
                    count++;
                }
                time += Time.deltaTime;
            } else {
                text.text = "RESULT : ";
                if (count < 10) {
                    text.text += "ミジンコ級";
                } else if(count < 20) {
                    text.text += "アリ級";
                } else if(count < 40){
                    text.text += "イヌ級";
                } else if(count < 60){
                    text.text += "素人級";
                } else if(count < 80){
                    text.text += "玄人級";
                } else if(count < 100){
                    text.text += "達人級";
                } else{
                    text.text += "伝説級";
                }

            }
        }
	}
}
