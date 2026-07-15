using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;

    // Xác định xem Scene hiện tại là task mấy dựa theo tên Scene
    private string currentSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ script này không bị xóa khi chuyển cảnh
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Hàm này tự động chạy mỗi khi một Scene mới được load xong
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = scene.name;
        TriggerStartDialogue();
    }

    // Tự động kích hoạt hội thoại mở đầu cho từng màn chơi
    private void TriggerStartDialogue()
    {
        if (DialogueManager.Instance == null) return;

        DialogueData tempDialogue = ScriptableObject.CreateInstance<DialogueData>();

        switch (currentSceneName)
        {
            case "task 1":
                tempDialogue.dialogueLines = DialogueDatabase.GetLevel1_Scene1();
                DialogueManager.Instance.StartDialogue(tempDialogue, OnLevel1StartCompleted);
                break;

            case "task 2":
                tempDialogue.dialogueLines = DialogueDatabase.GetLevel2_Scene1();
                DialogueManager.Instance.StartDialogue(tempDialogue);
                break;

            case "task 3":
                tempDialogue.dialogueLines = DialogueDatabase.GetLevel3_Scene1();
                DialogueManager.Instance.StartDialogue(tempDialogue);
                break;

            case "task 4":
                tempDialogue.dialogueLines = DialogueDatabase.GetLevel4_Scene1();
                DialogueManager.Instance.StartDialogue(tempDialogue);
                break;

            case "task 5":
                tempDialogue.dialogueLines = DialogueDatabase.GetLevel5_Scene1();
                DialogueManager.Instance.StartDialogue(tempDialogue);
                break;
        }
    }

    // Ví dụ xử lý sự kiện sau khi đọc xong hội thoại mở đầu ở Màn 1
    private void OnLevel1StartCompleted()
    {
        Debug.Log("Hội thoại mở đầu Màn 1 kết thúc. Người chơi bắt đầu di chuyển xuống bếp.");
        // Tại đây bạn có thể kích hoạt các tác vụ khác trong game (mở khóa di chuyển, spawn quái...)
    }

    // Hàm dùng để chuyển sang Scene tiếp theo (gọi khi hoàn thành nhiệm vụ của màn)
    public void LoadNextTask()
    {
        switch (currentSceneName)
        {
            case "task 1":
                SceneManager.LoadScene("task 2");
                break;
            case "task 2":
                SceneManager.LoadScene("task 3");
                break;
            case "task 3":
                SceneManager.LoadScene("task 4");
                break;
            case "task 4":
                SceneManager.LoadScene("task 5");
                break;
            case "task 5":
                Debug.Log("Chúc mừng! Bạn đã hoàn thành toàn bộ trò chơi.");
                break;
            default:
                Debug.LogWarning("Không tìm thấy màn chơi tiếp theo.");
                break;
        }
    }
}