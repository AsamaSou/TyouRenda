using System.Collections;
using UnityEngine;
using UnityEngine.UI;//Text型を扱えるようにする.

/* タイトルからメインのシーンに移動させたいだけ.
 * ちょっとカッコつけてる.
 */
public class TitleController : MonoBehaviour {

    public Text presskeyText;//テキストをエディタ上で取得する.

	// １フレーム更新処理をこのUpdateメソッドという｛｝の中で行う.
    //（フレームレートは【1秒間に画面が何回更新されるか】のことで、その処理1回ぶんをここで行っている）
	void Update () {
        //何かしらのキーが押されたとき.
        if (Input.anyKeyDown) {
            StartCoroutine("LoadScene");//LoadSceneのコルーチンメソッドを呼ぶ.
        }
	}

    //IEnumratorにすると、コルーチンメソッドになる.
    //コルーチンメソッドは、yield returnを扱えて、待つ処理ができる.（普通はメソッドが実行されたら一瞬）
    IEnumerator LoadScene() {
        for (int i = 0; i < 5; i++) {
            presskeyText.enabled = !presskeyText.enabled;//現在のテキスト表示状態の反対.真なら偽、偽なら真になる.
            yield return new WaitForSeconds(0.1f);//0.1秒待つ.
        }
        Application.LoadLevel("Main");//Mainという名前のシーンに切り替える.
    }
}
