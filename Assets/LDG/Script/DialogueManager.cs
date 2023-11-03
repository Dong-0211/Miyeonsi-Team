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
    [SerializeField] private SpriteRenderer sprite_CharacterIMG;    // ĳ���� ��������Ʈ
    [SerializeField] private SpriteRenderer sprite_DialogueBar;          // ��ȭâ ��������Ʈ
    [SerializeField] private Text text_CharacterName;       // ĳ���� �̸� �ؽ�Ʈ
    [SerializeField] private Text text_DialogueContent;     // ��ȭ���� �ؽ�Ʈ

    private bool isTalking = false; // ��ȭ�� ���������� Ȯ���ϴ� ����

    private int Talkcount = 0;  // ��ȭ�� �ɶ����� ī��Ʈ�� ����

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
