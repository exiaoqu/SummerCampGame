using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePoemShow : MonoBehaviour
{
    public float startDelay = 0.5f;
    public float showDelay = 0.4f;
    public GameObject energyUI;

    private bool isPoemFinished = false;

    private Text poemText;
    private string[] poemSentences =
    {
        "      清平乐  无何谷\n",
        "\n",
        "丹崖琼阁，渺渺无何谷\n",
        "红花碧草蓝蝶舞，明泉流云飞瀑\n",
        "冷月寒山清露，朱雀雪狸白狐\n",
        "幽幽寻仙之路，鬼木妖蕈歧途\n",
        null
    };



    //RectTransform rt;
    // Use this for initialization
    void Start()
    {
        poemText = GetComponent<Text>();
        energyUI.SetActive(false);

        StartCoroutine("showPoemContent");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPoemFinished)
        {
            gameObject.SetActive(false);
            energyUI.SetActive(true);
        }
    }


    IEnumerator showPoemContent()
    {
        yield return new WaitForSeconds(startDelay);

        int i = 0;
        while (i < 6)
        {
            string sentence = poemSentences[i];
            for (int j = 0; j < sentence.Length; j++)
            {
                poemText.text += sentence[j];

                yield return new WaitForSeconds(0.1f);

            }

            i++;

            yield return new WaitForSeconds(showDelay);
        }

        yield return new WaitForSeconds(7.0f);

        poemText.text = "";

        //gameObject.SetActive(false);

        isPoemFinished = true;
        yield return new WaitForSeconds(1.0f);


    }
}
