using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public string characterName;
    public Sprite characterIMG;
}


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_CharacterIMG;    // 캐릭터 스프라이트
    [SerializeField] private SpriteRenderer sprite_DialogueBar;          // 대화창 스프라이트
    [SerializeField] private Text text_CharacterName;       // 캐릭터 이름 텍스트
    [SerializeField] private Text text_DialogueContent;     // 대화내용 텍스트

    private bool isTalking = false; // 대화가 진행중인지 확인하는 변수

    private int Talkcount = 0;  // 대화가 될때마다 카운트할 변수

    [SerializeField] private Dialogue[] DialogueContent;

    // Button click UI on function
    public void ShowDialogue()
    {
        DialogueOnOff(true);
        Talkcount = 0;
        NextDialogue();
    }

    private void DialogueOnOff(bool _flag)
    {
        sprite_DialogueBar.gameObject.SetActive(_flag);
        sprite_CharacterIMG.gameObject.SetActive(_flag);
        text_CharacterName.gameObject.SetActive(_flag);
        text_DialogueContent.gameObject.SetActive(_flag);
        isTalking = _flag;
    }

    private void NextDialogue()
    {
        text_DialogueContent.text = DialogueContent[Talkcount].dialogue;
        text_CharacterName.text = DialogueContent[Talkcount].characterName;
        sprite_CharacterIMG.sprite = DialogueContent[Talkcount].characterIMG;
        Talkcount++;
    }

    void Update()
    {
        if (isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Talkcount < DialogueContent.Length) { NextDialogue(); }
                else { DialogueOnOff(false); }
            }
        }
    }
}
