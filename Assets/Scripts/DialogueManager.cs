using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI Components")]
    public GameObject dialoguePanel;
    public Text nameText;
    public Text dialogueText;

    private Queue<DialogueLine> sentences;
    private System.Action onDialogueComplete;

    private bool isTyping = false;        // Kiểm tra xem chữ có đang chạy hay không
    private string currentFullSentence = ""; // Lưu trữ câu thoại đầy đủ hiện tại

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        sentences = new Queue<DialogueLine>();
    }

    private void Update()
    {
        // Chỉ nhận tương tác khi bảng hội thoại đang mở
        if (dialoguePanel.activeSelf)
        {
            // Kiểm tra nếu người chơi click chuột trái (0) hoặc nhấn phím Cách (Space)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (isTyping)
                {
                    // Nếu chữ đang chạy mà người chơi nhấn nút, hiển thị ngay lập tức toàn bộ câu
                    StopAllCoroutines();
                    dialogueText.text = currentFullSentence;
                    isTyping = false;
                }
                else
                {
                    // Nếu chữ đã chạy xong hoàn toàn, chuyển sang câu tiếp theo
                    DisplayNextSentence();
                }
            }
        }
    }

    public void StartDialogue(DialogueData dialogueData, System.Action onComplete = null)
    {
        dialoguePanel.SetActive(true);
        onDialogueComplete = onComplete;
        sentences.Clear();

        foreach (DialogueLine line in dialogueData.dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = sentences.Dequeue();
        nameText.text = currentLine.speakerName;
        currentFullSentence = currentLine.sentence;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f); // Tốc độ chạy chữ
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        onDialogueComplete?.Invoke();
    }
}