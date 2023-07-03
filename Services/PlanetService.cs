using AppMVC01.Models;
using System.Collections.Generic;

namespace AppMVC01.Services
{
    public class PlanetService : List<PlanetModel>
    {
        public PlanetService() 
        {
            this.Add(new PlanetModel {
                Id =1 ,
                VnName = "Sao Thủy",
                Name = "Mercury",
                Content = @"Sao Thủy (cách Mặt Trời khoảng 0,4 AU) là hành tinh gần Mặt Trời nhất và là hành tinh nhỏ nhất trong Hệ Mặt Trời (0,055 lần khối lượng Trái Đất). Sao Thủy không có vệ tinh tự nhiên, và nó chỉ có các đặc trưng địa chất bên cạnh các hố va chạm đó là các sườn và vách núi,
                            có lẽ được hình thành trong giai đoạn co lại đầu tiên trong lịch sử của nó"
            });

            Add(new PlanetModel {
                Id = 2,
                VnName = "Sao Kim",
                Name = "Venus",
                Content = @"Sao Kim (cách Mặt Trời khoảng 0,7 AU) có kích cỡ khá gần với kích thước Trái Đất (với khối lượng bằng 0,815 lần khối lượng Trái Đất) và đặc điểm cấu tạo giống Trái Đất,
                            nó có 1 lớp phủ silicat dày bao quanh 1 lõi sắt. Sao Kim có 1 bầu khí quyển dày và có những chứng cứ cho thấy hành tinh này còn sự hoạt động của địa chất bên trong nó. Tuy nhiên, Sao Kim khô hơn Trái Đất rất nhiều và mật độ bầu khí quyển của nó gấp 90 lần mật độ bầu khí quyển của Trái Đất. Sao Kim không có vệ tinh tự nhiên. Nó là hành tinh nóng nhất trong hệ Mặt Trời với nhiệt độ của bầu khí quyển trên 400 °C, nguyên nhân chủ yếu là do hiệu ứng nhà kính của bầu khí quyển",
            });

            Add(new PlanetModel
            {
                Id = 3,
                VnName = "Trái Đất",
                Name = "Earth",
                Content = @"Trái Đất (cách Mặt Trời 1 AU) là hành tinh lớn nhất và có mật độ lớn nhất trong số các hành tinh vòng trong, cũng là hành tinh duy nhất mà chúng ta biết còn có các hoạt động địa chất gần đây, và là hành tinh duy nhất trong vũ trụ được biết đến là nơi có sự sống tồn tại",
            });

            Add(new PlanetModel
            {
                Id = 4,
                VnName = "Sao Hỏa",
                Name = "Mars",
                Content = "Sao Hỏa (cách Mặt Trời khoảng 1,5 AU) có kích thước nhỏ hơn Trái Đất và Sao Kim (khối lượng bằng 0,107 lần khối lượng Trái Đất). Nó có 1 bầu khí quyển chứa chủ yếu là cacbon dioxide (CO2) với áp suất khí quyển tại bề mặt bằng 6,1 millibar (gần bằng 0,6% áp suất khí quyển tại bề mặt của Trái Đất)",
            });

            Add(new PlanetModel
            {
                Id = 5,
                VnName = "Sao Mộc",
                Name = "Jupiter",
                Content = @"Sao Mộc (khoảng cách đến Mặt Trời 5,2 AU), với khối lượng bằng 318 lần khối lượng Trái Đất và bằng 2,5 lần tổng khối lượng của 7 hành tinh còn lại trong Thái Dương Hệ. Mộc Tinh có thành phần chủ yếu hiđrô và heli. Nhiệt lượng khổng lồ từ bên trong Sao Mộc tạo ra một số đặc trưng bán vĩnh cửu trong bầu khí quyển của nó, như các dải mây và Vết đỏ lớn",
            });

            Add(new PlanetModel
            {
                Id = 6,
                VnName = "Sao Thổ",
                Name = "Saturn",
                Content = @"Sao Thổ (khoảng cách đến Mặt Trời 9,5 AU), có đặc trưng khác biệt rõ rệt đó là hệ vành đai kích thước rất lớn, và những đặc điểm giống với Sao Mộc, như về thành phần bầu khí quyển và từ quyển. Mặc dù thể tích của Sao Thổ bằng 60% thể tích của Sao Mộc, nhưng khối lượng của nó chỉ bằng 1/3 so với Sao Mộc, hay 95 lần khối lượng Trái Đất, khiến nó trở thành hành tinh có mật độ nhỏ nhất trong hệ Mặt Trời (nhỏ hơn cả mật độ của nước lỏng). Vành đai Sao Thổ chứa bụi cũng như các hạt băng và đá nhỏ.",
            });

            Add(new PlanetModel
            {
                Id = 7,
                VnName = "Sao Thiên Vương",
                Name = "Uranus",
                Content = "Sao Thiên Vương (khoảng cách đến Mặt Trời 19,6 AU), khối lượng bằng 14 lần khối lượng Trái Đất, là hành tinh vòng ngoài nhẹ nhất. Trục tự quay của nó có đặc trưng lạ thường duy nhất so với các hành tinh khác, độ nghiêng trục quay >900 so với mặt phẳng hoàng đạo. Thiên Vương Tinh có lõi lạnh hơn nhiều so với các hành tinh khí khổng lồ khác và nhiệt lượng bức xạ vào không gian cũng nhỏ",
            });

            Add(new PlanetModel
            {
                Id = 8,
                VnName = "Sao Hải Vương",
                Name = "Neptune",
                Content = "Sao Hải Vương (khoảng cách đến Mặt Trời 30 AU), mặc dù kích cỡ hơi nhỏ hơn Sao Thiên Vương nhưng khối lượng của nó lại lớn hơn (bằng 17 lần khối lượng của Trái Đất) và do vậy khối lượng riêng lớn hơn. Nó cũng bức xạ nhiều nhiệt lượng hơn nhưng không lớn bằng của Sao Mộc hay Sao Thổ",
            });
        }  
    }
}
