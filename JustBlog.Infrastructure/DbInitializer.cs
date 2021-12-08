using JustBlog.Common.Constants;
using JustBlog.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace JustBlog.Infrastructure
{
    public class DbInitializer
    {
        private readonly JustBlogDbContext _context;

        public DbInitializer(JustBlogDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            //add roles
            if (!_context.Roles.Any())
            {
                var roles = new AppRole[]
                {
                    new AppRole(){ Name= UserRole.BlogOwner, NormalizedName=UserRole.BlogOwner.ToUpper()},
                    new AppRole(){ Name= UserRole.User, NormalizedName=UserRole.User.ToUpper()},
                    new AppRole(){ Name= UserRole.Contributor, NormalizedName=UserRole.Contributor.ToUpper()},
                };
                _context.Roles.AddRange(roles);
                _context.SaveChanges();
            }


            //if Category has any data return, Database has seeded.
            if (_context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>()
            {
                new Category(){Name="Thể Thao"},
                new Category(){Name="Kinh Tế"},
                new Category(){Name="Du Lịch"},
            };

            var posts = new List<Post>()
            {
                new Post(){Title="Phó Chủ tịch Hà Nội: Dịch ở Bệnh viện Việt Đức phức tạp, nhiều nguy cơ", Category=categories[0], UrlSlug = "post-1", PostContent ="Nhận định nêu trên được Phó Chủ tịch UBND TP Hà Nội Chử Xuân Dũng đề cập tại buổi họp Sở Chỉ huy phòng, chống dịch Covid-19 với các cơ quan liên quan diễn ra chiều 2/10.Trước đó, báo cáo tại hội nghị, Phó Giám đốc Sở Y tế Hà Nội Vũ Cao Cương cho biết, sau khi ghi nhận các ca liên quan đến Bệnh viện Hữu nghị Việt Đức, cơ quan y tế đã lấy được 7.260 mẫu những người liên quan.", ViewCount=100, RateCount=4 },
                new Post(){Title="Lịch thi đấu bóng đá châu Âu cuối tuần: Barcelona đại chiến Atletico", Category=categories[0], UrlSlug = "post-2", PostContent ="Xét về phong độ, Liverpool được đánh giá cao hơn sau trận thắng tưng bừng Porto 5-1. Trong khi đó, Man City có phần sa sút tinh thần khi mới thua PSG 0-2 ở Champions League và phong độ khá bất ổn. Việc Man City và Liverpool đối đầu trực tiếp là cơ hội để Chelsea và Man Utd bứt phá. Chelsea tiếp đón Southampton trên sân nhà Stamford Bridge, đoàn quân HLV Thomas Tuchel cần một chiến thắng ấn tượng để thoát khỏi khủng hoảng, khi mới thua liên tiếp Man City, Juventus.", ViewCount=200, RateCount=5  },
                new Post(){Title="Mike Tyson muốn đại chiến Youtuber Logan Paul ở trận đấu 100 triệu USD", Category=categories[0], UrlSlug = "post-3", PostContent ="Trong số hai anh em, Logan Paul có thể hình tốt hơn nhưng Jack Paul lại có kỹ thuật tốt hơn. Do đó, nhiều khả năng Mike Tyson muốn né cậu em bởi ông đã cao tuổi và không còn uy lực, nhanh nhẹn như trước. Khi Freddie Gibbs hỏi tiếp rằng ông có sợ một trong hai anh em từ chối không, võ sĩ huyền thoại người Mỹ nói tiếp: `Với 100 triệu USD, họ có thể làm bất kỳ điều gì. Họ không quan tâm tới việc bị đánh bại đâu`", ViewCount=1000, RateCount=3  },
                new Post(){Title="Bất ngờ xin ý kiến Hà Nội mở cửa sân bay Nội Bài từ 5/10", Category=categories[2], UrlSlug = "post-4", PostContent ="Văn bản do Phó Cục trưởng Cục Hàng không Việt Nam Võ Huy Cường ký và gửi đi hôm nay (2/10) nêu rõ: Sau khi trao đổi với Sở GTVT TP Hà Nội, Cục Hàng không Việt Nam gửi UBND TP Hà Nội văn bản xin ý kiến địa phương kèm phụ lục kế hoạch khai thác vận tải hàng không nội địa giai đoạn 1, dự kiến áp dụng từ 5/10 với các thông tin về đường bay, hãng khai thác, tần suất đi/đến Cảng hàng không quốc tế Nội Bài.", ViewCount=100, RateCount=4  },
                new Post(){Title="Trung Quốc cam kết giải quyết cuộc khủng hoảng thiếu điện trầm trọng",Category=categories[2], UrlSlug = "post-5", PostContent ="Đang chờ để vào TP Đà Nẵng, ông Nguyễn Đắc Song (trú xã Tam Thanh, TP Tam Kỳ, Quảng Nam) cho biết mình cùng 19 người khác là ngư dân có thuyền cá tại Âu thuyền Thọ Quang (quận Sơn Trà, Đà Nẵng).", ViewCount=300, RateCount=4  },
                new Post(){Title="Nhan sắc gây thương nhớ và tài sản đáng nể của Yoona", Category=categories[1], UrlSlug = "post-6", PostContent ="Tháng 9 vừa rồi, trang SCMP đã công bố danh sách 7 sao nữ có thu nhập cao nhất làng nhạc xứ Hàn trong năm 2021 và Yoona nằm ở vị trí thứ 6 với khối tài sản lên tới 25 triệu USD. Thu nhập của cô đến từ hoạt động ca hát, đóng phim, làm người mẫu và tham dự sự kiện.", ViewCount=410, RateCount=3  },
                new Post(){Title="Liên hoan phim Việt Nam 2021 lần đầu được trao giải trực tuyến", Category=categories[2], UrlSlug = "post-6", PostContent ="Ông Vi Kiến Thành, Cục trưởng Cục Điện ảnh (Bộ Văn hóa, Thể thao & Du lịch) cho biết, do tình hình dịch Covid-19 diễn biến phức tạp, Liên hoan phim Việt Nam lần thứ 22 sẽ rút ngắn thời gian tổ chức xuống còn 3 ngày (từ 18 đến 20/11) tại thành phố Huế.", ViewCount=100, RateCount=4  },
            };

            var tags = new List<Tag>()
            {
                new Tag(){Name="tag 1", UrlSlug="tag-1"},
                new Tag(){Name="tag 2", UrlSlug="tag-2"},
                new Tag(){Name="tag 3", UrlSlug="tag-3"},
                new Tag(){Name="tag 4", UrlSlug="tag-4"},
                new Tag(){Name="tag 5", UrlSlug="tag-5"},
            };

            var postTagMaps = new List<PostTagMap>() {
                new PostTagMap(){Post = posts[0], Tag = tags[0]},
                new PostTagMap(){Post = posts[0], Tag = tags[1]},
                new PostTagMap(){Post = posts[0], Tag = tags[2]},
                new PostTagMap(){Post = posts[1], Tag = tags[0]},
                new PostTagMap(){Post = posts[1], Tag = tags[1]},
                new PostTagMap(){Post = posts[2], Tag = tags[1]},
                new PostTagMap(){Post = posts[2], Tag = tags[2]},
                new PostTagMap(){Post = posts[3], Tag = tags[1]},
                new PostTagMap(){Post = posts[4], Tag = tags[4]},
                new PostTagMap(){Post = posts[4], Tag = tags[1]},
                new PostTagMap(){Post = posts[5], Tag = tags[4]},
                new PostTagMap(){Post = posts[6], Tag = tags[0]},
            };

            _context.PostTagMaps.AddRange(postTagMaps);
            _context.SaveChanges();
        }
    }
}