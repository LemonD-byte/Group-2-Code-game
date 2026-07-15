using System.Collections.Generic;
using UnityEngine;

// Đối tượng ScriptableObject dùng để lưu trữ hội thoại trong Assets
public class DialogueData : ScriptableObject
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

// Lớp tĩnh chứa toàn bộ kịch bản của 5 màn chơi để truy xuất nhanh bằng code
public static class DialogueDatabase
{
    // MÀN CHƠI 1: NGÀY KHỞI ĐẦU
    public static List<DialogueLine> GetLevel1_Scene1() // Thức dậy đọc tin nhắn
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Hệ thống", "Ngày 15 tháng 10. Tại khu phố Bình An."),
            new DialogueLine("Nam", "Ưm... sáng rồi sao? Để xem điện thoại nào."),
            new DialogueLine("Tin nhắn của Hoa", "Anh ơi, em đi chợ sớm rồi tiện đường đưa cu Bin đi học luôn nhé. Đồ ăn sáng em để trong tủ lạnh, anh nhớ hâm nóng lại rồi mới ăn đấy."),
            new DialogueLine("Nam", "Vợ chu đáo thật. Xuống bếp tìm cái gì bỏ bụng đã.")
        };
    }

    public static List<DialogueLine> GetLevel1_Scene2() // Tiếng động nhà hàng xóm
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Tiếng gì thế? Hình như bên nhà anh Hùng chị Lan? Có chuyện gì lớn lắm mới đổ vỡ thế kia."),
            new DialogueLine("Nam", "Cảm giác không lành... Mình nên cầm theo cây gậy bóng chày và khẩu súng lục phòng thân.")
        };
    }

    public static List<DialogueLine> GetLevel1_Scene3() // Gặp hàng xóm và tự vệ
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Anh Hùng? Chị Lan? Hai người có sao kh... Trời ơi! Chị Lan!"),
            new DialogueLine("Nam", "Máu... nhiều máu quá. Chị Lan nằm bất động rồi."),
            new DialogueLine("Nam", "Anh Hùng? Da anh... sao lại tái nhợt thế kia? Này, anh nghe tôi nói không?"),
            new DialogueLine("Hùng (Hàng xóm)", "Gừ... gào..."),
            new DialogueLine("Nam", "Này! Anh điên rồi à! Tránh xa tôi ra!"),
            // Sau khi hạ gục
            new DialogueLine("Nam", "Khốn kiếp... Anh ấy chết rồi sao? Mình chỉ tự vệ thôi mà... Tại sao anh ấy lại cắn xé như một con thú hoang dại vậy?")
        };
    }

    public static List<DialogueLine> GetLevel1_Scene4() // Ra ngoài thấy hỗn loạn
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Mọi người ơi, cứu... Ủa? Sao đường phố hỗn loạn thế này?"),
            new DialogueLine("Người dân 1", "Chạy đi! Có người điên cắn người!"),
            new DialogueLine("Người dân 2", "Gào... thịt..."),
            new DialogueLine("Nam", "Không ổn rồi, cả khu phố phát điên rồi sao?! Phải lấy xe đi tìm Hoa và Bin ngay!")
        };
    }

    // MÀN CHƠI 2: TRƯỜNG TIỂU HỌC
    public static List<DialogueLine> GetLevel2_Scene1() // Đến cổng trường
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Trường tiểu học đây rồi. Cổng trường đổ nát quá... Lũ quái vật kia tụ tập đông thật. Phải dọn đường mới vào trong được.")
        };
    }

    public static List<DialogueLine> GetLevel2_Scene2() // Tìm thấy con trong nhà vệ sinh
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Bin! Bin ơi! Con có trong này không? Bố đây!"),
            new DialogueLine("Bin", "Bố... bố ơi... cứu con... Có mấy người đáng sợ ngoài kia..."),
            new DialogueLine("Nam", "Bố đây rồi, tránh ra xa cửa để bố mở khóa nhé."),
            new DialogueLine("Bin", "Mẹ đưa con đến lớp rồi đi chợ... Sau đó các bạn và thầy cô bỗng nhiên cắn nhau, con sợ quá nên trốn vào đây."),
            new DialogueLine("Nam", "Ngoan nào, có bố ở đây rồi. Chúng ta phải đi tìm mẹ ngay.")
        };
    }

    public static List<DialogueLine> GetLevel2_Scene3() // Đàn zombie tấn công nhà vệ sinh
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Chết tiệt, tiếng động vừa nãy thu hút chúng tới rồi. Bin, trốn sau lưng bố!"),
            // Sau khi dọn sạch zombie
            new DialogueLine("Nam", "An toàn rồi. Bây giờ chúng ta ra chợ huyện tìm mẹ.")
        };
    }

    // MÀN CHƠI 3: CHỢ HUYỆN
    public static List<DialogueLine> GetLevel3_Scene1() // Vào chợ tìm kiếm
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Chợ huyện hỗn loạn hơn cả trường học. Bin, đi sát bên bố, không được rời nửa bước.")
        };
    }

    public static List<DialogueLine> GetLevel3_Scene2() // Tìm thấy vợ biến đổi
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Hoa! Là em phải không?"),
            new DialogueLine("Hoa", "Nam... Bin... Đừng... đừng lại gần em..."),
            new DialogueLine("Bin", "Mẹ ơi! Mẹ bị sao thế?"),
            new DialogueLine("Nam", "Em... em đã bị cắn sao? Nhưng tại sao em vẫn nhận ra anh?"),
            new DialogueLine("Hoa", "Em không biết... Cơn thèm khát thịt sống đang giằng xé bên trong em, nhưng đầu óc em vẫn tỉnh táo... Em nhớ anh, nhớ con..."),
            new DialogueLine("Nam", "Anh không thể bỏ em lại được. Chúng ta sẽ tìm cách.")
        };
    }

    public static List<DialogueLine> GetLevel3_Scene3() // Gặp quân nhân và nhà khoa học
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Đại úy Phong", "Có người sống sót! Khoan đã... người phụ nữ kia đã bị nhiễm! Chuẩn bị nổ súng!"),
            new DialogueLine("Nam", "Đừng bắn! Cô ấy không tấn công ai cả! Cô ấy vẫn giữ được lý trí!"),
            new DialogueLine("Tiến sĩ Minh", "Đại úy, dừng tay! Nhìn mắt cô ấy đi... Dù có triệu chứng biến đổi thể chất nhưng đồng tử không bị đục. Thật kỳ diệu."),
            new DialogueLine("Đại úy Phong", "Được rồi, chúng tôi sẽ đưa tất cả về khu tị nạn tạm thời. Đi theo chúng tôi.")
        };
    }

    public static List<DialogueLine> GetLevel3_Scene4() // Tại trại tị nạn giải thích về bệnh dịch
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Tiến sĩ Minh", "Tôi có tin mừng và tin xấu cho anh. Vợ anh có một kháng thể đặc biệt, nó giúp cô ấy không bị virus kiểm soát não bộ. Đây chính là chìa khóa để chế tạo thuốc giải."),
            new DialogueLine("Nam", "Thật sao? Vậy hãy cứu cô ấy!"),
            new DialogueLine("Tiến sĩ Minh", "Vấn đề là thiết bị và nguyên liệu đặc hiệu hiện chỉ còn ở Bệnh viện Quân y cũ, nơi đó hiện đã bị cô lập hoàn toàn bởi hàng ngàn zombie."),
            new DialogueLine("Đại úy Phong", "Lực lượng của chúng tôi quá mỏng để mở đường máu."),
            new DialogueLine("Nam", "Tôi sẽ đi cùng các anh. Vì vợ tôi, vì tất cả mọi người.")
        };
    }

    // MÀN CHƠI 4: BỆNH VIỆN QUÂN Y
    public static List<DialogueLine> GetLevel4_Scene1() // Trước khi vào bệnh viện
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Đại úy Phong", "Chúng ta đã đến nơi. Nam, tôi và các binh sĩ sẽ giữ lối ra vào này. Cậu và Tiến sĩ Minh phải vào phòng thí nghiệm tầng 3 để thu thập mẫu hóa chất."),
            new DialogueLine("Nam", "Hiểu rồi. Hãy cẩn thận.")
        };
    }

    public static List<DialogueLine> GetLevel4_Scene2() // Thu thập nguyên liệu
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Tiến sĩ Minh", "Đây rồi! Các ống nghiệm chứa kháng nguyên gốc vẫn còn nguyên vẹn. Nam, giúp tôi dọn dẹp lũ zombie đang cố phá cửa kính phía kia!"),
            new DialogueLine("Nam", "Tôi lo liệu được. Ông nhanh tay lên!"),
            // Sau khi bảo vệ thành công
            new DialogueLine("Tiến sĩ Minh", "Đã đủ nguyên liệu! Chúng ta rút lui thôi!")
        };
    }

    // MÀN CHƠI 5: TRỞ VỀ CĂN CỨ QUÂN SỰ
    public static List<DialogueLine> GetLevel5_Scene1() // Giao nộp nguyên liệu và bị bao vây
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Tiến sĩ, nguyên liệu đây, ông hãy mau điều chế thuốc giải cho Hoa đi!"),
            new DialogueLine("Tiến sĩ Minh", "Tôi cần khoảng 15 phút. Nhưng chúng ta gặp rắc rối lớn rồi..."),
            new DialogueLine("Đại úy Phong", "Nam! Đàn zombie từ các khu vực lân cận bị thu hút bởi tiếng động động cơ xe lúc nãy. Chúng đang bao vây căn cứ!")
        };
    }

    public static List<DialogueLine> GetLevel5_Scene2() // Phòng thủ bên ngoài
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Nam", "Chờ anh, Hoa. Anh sẽ bảo vệ phòng thí nghiệm này bằng mọi giá."),
            new DialogueLine("Hoa", "Cẩn thận... anh yêu..."),
            new DialogueLine("Nam", "Đại úy Phong, tôi ra hỗ trợ các anh ngay!")
        };
    }

    public static List<DialogueLine> GetLevel5_Scene3() // Kết thúc cuộc chiến, tiêm thuốc giải
    {
        return new List<DialogueLine>()
        {
            new DialogueLine("Đại úy Phong", "Chúng ta làm được rồi... Thiệt hại không nhỏ, nhưng căn cứ vẫn đứng vững."),
            new DialogueLine("Tiến sĩ Minh", "Thuốc giải đã hoàn thành. Hãy tiêm nó cho vợ cậu."),
            new DialogueLine("Hoa", "Nam... Bin... Em cảm thấy... cơn khát biến mất rồi."),
            new DialogueLine("Bin", "Mẹ ơi!"),
            new DialogueLine("Nam", "Mọi chuyện qua rồi. Chúng ta sẽ cùng nhau xây dựng lại từ đầu.")
        };
    }
}
