using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        [Header ("Text Options")]
        private Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Text Parameters")]
        [SerializeField] float delay;
        [SerializeField] float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] AudioClip sound;

        [Header("Character Image")]
        [SerializeField] Sprite characterSprite;
        [SerializeField] Image imageHolder;

        private void Awake()
        {
            textHolder=GetComponent<Text>();
            textHolder.text = "";

            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));

        }
    }
}

