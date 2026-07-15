using System;

[Serializable]
public class DialogueLine
{
    public string speakerName; // Tên nhân vật nói
    [UnityEngine.TextArea(3, 5)]
    public string sentence;    // Nội dung câu thoại

    // Constructor mặc định (Unity Inspector cần constructor không tham số)
    public DialogueLine() { }

    // Constructor tiện dụng để khởi tạo nhanh bằng code, ví dụ trong DialogueDatabase
    public DialogueLine(string speaker, string text)
    {
        this.speakerName = speaker;
        this.sentence = text;
    }
}