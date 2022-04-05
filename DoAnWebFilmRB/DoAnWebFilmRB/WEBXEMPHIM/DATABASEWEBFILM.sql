
CREATE DATABASE WEBFILM
GO

use WEBFILM
GO

CREATE TABLE ADMINFILM(
	ID_ADMIN int identity primary key,
	TEN_ADMIN nvarchar(50),
	MK_ADMIN nvarchar(50)
)
go

CREATE TABLE LOAI(
	IDLOAI int identity primary key,
	TENLOAI nvarchar(30)
)
go

CREATE TABLE QUOCGIA(
	ID_QG int identity primary key,
	TEN_QG nvarchar(30),
)
go

CREATE TABLE DIENVIEN(
	ID_DV int identity primary key,
	TEN_DV nvarchar(50),
)
go

CREATE TABLE NAMPHATHANH(
	ID_NAM int identity primary key,
	NAM_PHAT int
)
go

CREATE TABLE TRANGTHAI(
	ID_TRANGTHAI int identity primary key,
	TEN_TRANGTHAI nvarchar(30)
)
go

CREATE TABLE THANHVIEN(
	ID_TV int identity primary key,
	HOTEN nvarchar(50),
	TAIKHOAN varchar(50),
	MATKHAU varchar(50),
	EMAIL varchar(50),
	NGAYSINH datetime,
	DIACHI nvarchar(100),
	SDT varchar(15),
)
go
CREATE TABLE PHIM(
	ID_PHIM int identity primary key,
	TEN_PHIM nvarchar(50),
	IMAGE_PHIM varchar(100),
	LINK_PHIM nvarchar(100),
	MOTA nvarchar(max),
	ID_TRANGTHAI int,
	ID_QG int,
	ID_NAM int,
	LuotXem int,
	CONSTRAINT FK_TRANGTHAI_PHIM FOREIGN KEY (ID_TRANGTHAI) REFERENCES TRANGTHAI(ID_TRANGTHAI),
	CONSTRAINT FK_QUOCGIA_PHIM FOREIGN KEY (ID_QG) REFERENCES QUOCGIA(ID_QG),
	CONSTRAINT FK_NAMPHATHANH_PHIM FOREIGN KEY (ID_NAM) REFERENCES NAMPHATHANH(ID_NAM),
)
CREATE TABLE PHIMSAPCHIEU(
	ID_PHIMSP int identity primary key,
	TEN_PHIMSP nvarchar(50),
	IMAGE_PHIMSP varchar(100),
	LINK_PHIMSP nvarchar(100),
)
go

CREATE TABLE PHIM_DV(
	ID_PHIM int,
	ID_DV int,
	PRIMARY KEY (ID_PHIM,ID_DV),
	CONSTRAINT FK_DV_PHIM FOREIGN KEY (ID_DV) REFERENCES DIENVIEN(ID_dV),
	CONSTRAINT FK_PHIM_dV FOREIGN KEY (ID_PHIM) REFERENCES PHIM(ID_PHIM)
)
go

CREATE TABLE CHITIETLOAI(
	ID_PHIM int,
	IDLOAI int,
	PRIMARY KEY (ID_PHIM,IDLOAI),
	CONSTRAINT FK_LOAI_CTLOAI FOREIGN KEY (IDLOAI) REFERENCES LOAI(IDLOAI),
	CONSTRAINT FK_PHIM_CTLOAI FOREIGN KEY (ID_PHIM) REFERENCES PHIM(ID_PHIM)
)
go

CREATE TABLE BINHLUAN(
	ID_BINHLUAN int identity primary key,
	ID_TV int,
	ID_PHIM int,
	NOIDUNG nvarchar(200),
	NGAY_BINHLUAN date,
	CONSTRAINT FK_PHIM_BINHLUAN FOREIGN KEY (ID_PHIM) REFERENCES PHIM(ID_PHIM),
	CONSTRAINT FK_THANHVIEN_BINHLUAN FOREIGN KEY (ID_TV) REFERENCES THANHVIEN(ID_TV)
)
go

CREATE TABLE DANHGIA(
	ID_TV int,
	ID_PHIM int,
	DIEM int,
	TONGDIEM int,
	PRIMARY KEY (ID_PHIM,ID_TV),
	CONSTRAINT FK_PHIM_DANHGIA FOREIGN KEY (ID_PHIM) REFERENCES PHIM(ID_PHIM),
	CONSTRAINT FK_THANHVIEN_DANHGIA FOREIGN KEY (ID_TV) REFERENCES THANHVIEN(ID_TV)
)
go

delete LOAI
DBCC CHECKIDENT (LOAI, RESEED, 0)
DBCC CHECKIDENT (LOAI)
insert into LOAI values (N'Hành Động')
insert into LOAI values	(N'Kiếm Hiệp')
insert into LOAI values	(N'Tình Cảm')
insert into LOAI values	(N'HOẠT HÌNH')
insert into LOAI values	(N'HÀI HƯỚC')

delete NAMPHATHANH
DBCC CHECKIDENT (NamPhatHanh, RESEED, 0)
DBCC CHECKIDENT (NamPhatHanh)
insert into NAMPHATHANH(NAM_PHAT) values (2000)
insert into NAMPHATHANH(NAM_PHAT) values (2001)
insert into NAMPHATHANH(NAM_PHAT) values (2002)
insert into NAMPHATHANH(NAM_PHAT) values (2003)
insert into NAMPHATHANH(NAM_PHAT) values (2004)
insert into NAMPHATHANH(NAM_PHAT) values (2005)
insert into NAMPHATHANH(NAM_PHAT) values (2006)
insert into NAMPHATHANH(NAM_PHAT) values (2007)
insert into NAMPHATHANH(NAM_PHAT) values (2008)
insert into NAMPHATHANH(NAM_PHAT) values (2009)
insert into NAMPHATHANH(NAM_PHAT) values (2010)
insert into NAMPHATHANH(NAM_PHAT) values (2019) 

delete QUOCGIA
DBCC CHECKIDENT (QUOCGIA, RESEED, 0)
DBCC CHECKIDENT (QUOCGIA)
insert into QUOCGIA(TEN_QG) values (N'Việt Nam')
insert into QUOCGIA(TEN_QG) values (N'Trung Quốc')
insert into QUOCGIA(TEN_QG) values (N'Hàn Quốc')
insert into QUOCGIA(TEN_QG) values (N'Nhật Bản')
insert into QUOCGIA(TEN_QG) values (N'Mỹ')
insert into QUOCGIA(TEN_QG) values (N'Hồng Kong')


delete DIENVIEN
DBCC CHECKIDENT (DIENVIEN, RESEED, 0)
DBCC CHECKIDENT (DIENVIEN)
insert into DIENVIEN(TEN_DV) values (N'Châu Tinh Trì')
insert into DIENVIEN(TEN_DV) values (N'Diệp Vấn')
insert into DIENVIEN(TEN_DV) values (N'Lý Tiểu Long')

delete TRANGTHAI
DBCC CHECKIDENT (TRANGTHAI, RESEED, 0)
DBCC CHECKIDENT (TRANGTHAI)
insert into TRANGTHAI values (N'Đã Phát Hành')
insert into TRANGTHAI values (N'Chưa Phát Hành')

delete THANHVIEN
DBCC CHECKIDENT (THANHVIEN, RESEED, 0)
DBCC CHECKIDENT (THANHVIEN)
insert into THANHVIEN values (N'Nguyễn Phan Hoài Rin','hoairinn','123','hoairinn@gmail.com','7/7/2000',N'Bình Định','0355025599')
insert into THANHVIEN values (N'Trần Thiên Bảo','thienbao','123','thienbao@gmail.com','7/8/2000',N'Bến Tre','123456789') 

delete ADMINFILM
DBCC CHECKIDENT (ADMINFILM, RESEED, 0)
DBCC CHECKIDENT (ADMINFILM)
insert into ADMINFILM values (N'admin',N'123')

delete PHIM
DBCC CHECKIDENT (PHIM, RESEED, 0)
DBCC CHECKIDENT (PHIM)
insert into PHIM values (N'Hai Phượng',N'haiphuong.jpg','https://www.youtube.com/embed/kG0BeGGkn90',N'Hai Phượng kể về cuộc hành trình đầy gay cấn và gian của khi người mẹ vùng quê tìm cách cứu con mình thoát khỏi đường dây bắt cóc khổng lồ. Không tấc sắc trong tay, người phụ nữ thân cô thế cô làm sao chống lại bọn xã hội đen tàn ác để giành lại nguồn sống của đời mình.',1,1,5,1)
insert into PHIM values (N'Thiên Mệnh Anh Hùng ',N'thienmenh.jpg','https://www.youtube.com/embed/LAYqXnqFomo',N'Lấy cảm hứng từ các nhân vật và một phần câu chuyện trong tiểu thuyết Bức Huyết Thư của nhà văn Bùi Anh Tấn, bộ phim dựa trên nền bối cảnh thời Lê sơ. Một câu chuyện đầy chất anh hùng – hiệp khách được dựng lên xung quanh vụ thảm án Lệ Chi Viên với những nhân vật hư cấu đan xen với những nhân vật lịch sử - một hình mẫu phổ biến của dòng tiểu thuyết võ hiệp.Trong câu chuyện võ hiệp Việt Nam này, một hậu duệ của Nguyễn Trãi là Nguyên Vũ còn sống sót sau án tru di tam tộc đã lên đường hành hiệp với mục đích tìm sự thật cho nỗi oan khiên và trả thù những kẻ đã hãm hại cả gia tộc mình. Bộ phim xoay quanh hành trình ấy.',1,1,6,1)
insert into PHIM values (N'Thần Bài2',N'thanbai2.jpg','https://www.youtube.com/embed/iPjgpICdXr0',N'Phim God Of Gamblers 2(Thần Bài 2) tiếp tục phần 1. Lần này, đệ tử của Vua Bài đã trở lại, cùng với Syephen, một người có khả năng đặc biệt làm mưa làm gió trên các sòng bạc lớn ở Hong Kong, nhưng liệu họ có thể tiếp tục như vậy không? Đệ tử của Vua Bài đã trở lại!',1,6,6,1)
insert into PHIM values (N'Trường học Uy Long (1991)',N'truonghocuylong.jpg','https://www.youtube.com/embed/3dYdXVJ_mUQ',N'Bộ phim xoay quanh câu chuyện của tay cảnh sát chìm Chow Sing-Sing (Châu Tinh Trì đóng), với nhiệm vụ tham nhập vào một trường trung học để tìm lại cây súng của sếp bị mất cắp. Để dễ dàng thâm nhập hơn, các đồng nghiệp của Chow cũng giả dạng thành học sinh để giúp đỡ anh nhưng công cuộc tìm kiếm của Chow cũng vẫn gặp vô vàn khó khăn thử thách bởi sự lì lợm của những đứa học sinh khác, sự khó chịu của các thầy cô. Thử thách mới đối với Chow xuất hiện khi cô giáo trẻ mới chuyển tới trường và khiến anh bối rối.',1,6,7,1)
insert into PHIM values (N'Lộc Đỉnh Ký',N'locdinhky.jpg','https://www.youtube.com/embed/Dc-z8Cn8VUw',N'Bộ phim xoay quanh cuộc đời của gã lưu manh xuất thân từ Lệ Xuân Viện là Vi Tiểu Bảo. Nhờ may mắn, Vi Tiểu Bảo được vào làm trong hoàng cung, được phục vụ dưới trướng của Tổng quản Công Công Hải Đại Phú. Hắn trở thành bạn thân của vua Khang Hy và hợp sức với vị vua trẻ trừ đi nghịch tặc Ngao Bái.',1,6,8,1)
insert into PHIM values (N'Vua bịp ',N'vuabip.jpg','https://www.youtube.com/embed/E6evf9kPsdM',N'Bộ phim kể về tay cảnh sát ngầm Lương Khoan, do không cẩn thận khi hành động nên bị cấp trên khiển trách. Được giao cơ hội khám phá chứng cứ tội phạm của vua cờ bạc lừng danh Ferrari, Lương Khoan nhanh chóng lên đường làm nhiệm vụ . Tuy nhiên, anh lại chưa có kinh nghiệm liên quan đến việc phá án các tổ chức cờ bạc phi pháp, phải tự trau dồi và tìm cách thâm nhập vào tổ chức cờ bạc đó. Trên con đường tìm kiếm người thầy, Lương Khoan được bạn gái giới thiệu cho người họ hàng xa của cô là Hoàng Phi Hổ - vua bạc bịp Hồng Kông mới ra tù.',1,6,10,1)
insert into PHIM values (N'Quốc sản 007 ',N'quocsan007.jpg','https://www.youtube.com/embed/fEAq-8TyuK4',N'Quốc Sản 007 là một bộ phim hành động - hài hước của Hồng Kông do Châu Tinh Trì và Lý Lực Trì đồng đạo diễn. Châu Tinh Trì thủ vai chính trong phim. Bộ phim do hãng Wins Movie Production Ltd sản xuất, công chiếu lần đầu tiên vào năm 1994. Bộ phim giễu nhại lại loạt phim James Bond và nhân vật điệp viên 007.',1,6,11,1)
insert into PHIM values (N'Bệnh viện ma ',N'benhvienma.jpg','https://www.youtube.com/embed/zX9CB1m99Gc',N'Phim xoay quanh câu chuyện của chàng sinh viên y khoa vừa tốt nghiệp tên Thành (Trấn Thành đóng) đến làm việc tại bệnh viện An Tâm – nơi có những lời đồn ma ám. Liên tiếp chứng kiến những sự kiện ly kỳ, Thành quyết định truy tìm sự thật đang ẩn giấu với sự giúp đỡ nhiệt tình của y tá Hằng (Hari Won) ',1,1,12,1) 
insert into PHIM values (N'Vệ binh mặt trăng','vebinhmattrang.jpg','https://www.youtube.com/embed/kJARYQsP6kY',N'Phim hoạt hìnhGuardian of the Moon là một bộ phim giả tưởng phiêu lưu hoạt hình 3D trên máy tính của Pháp năm 2014 do Benoît Philippon và Alexandre Heboyan đạo diễn và Jérôme Fansten và Benoît Philippon viết kịch bản. ',1,1,12,1)
insert into PHIM values (N'Bí kíp luyện thần dược','bikipluyenthanduoc.jpg','https://https://www.youtube.com/embed/KBqCagES63U',N'là một bộ phim hài gia đình phiêu lưu phiêu lưu trên máy tính năm 2018 của Pháp do Alexandre Astier và Louis Clichy đồng đạo diễn. Kịch bản của Astier dựa trên các nhân vật truyện tranh Asterix do René Goscinny và Albert Uderzo tạo ra. ',1,1,12,1)
insert into PHIM values (N'Tây Du Ký Tái Thế Yêu Vương','tayduky.jpg','https://www.youtube.com/embed/fWCYDvgusSI',N'Tây Du Ký Tái Thế Yêu Vương Thời hỗn độn sơ khai, yêu tinh đệ nhất thế giang giáng thế, tên Nguyên Đế, được tôn sùng là Yêu tổ. Trăm ngàn vạn năm sau, yêu vương ngày xưa Tôn Ngộ Không được Đường Tăng cứu ra khỏi núi Ngũ Hành Sơn, Ngộ Không đồng ý bảo vệ Đường Tăng đến Tây Thiên thỉnh kinh. Còn yêu tổ Nguyên Đế trong truyền thuyết lần nữa xuất thế, tam giới tràn ngập nguy cơ. Hai đại yêu vương đã định phải quyết chiến một trận, nhưng lần này Tôn Ngộ Không gặp phải kình địch thật sự.',1,1,12,1)
insert into PHIM values (N'Vương Quốc Thú','vuongquocthu.jpg','https://www.youtube.com/embed/sNSfH7at7WM',N'Một nhóm các loài động vật chờ lũ lụt hàng năm để có thức ăn và nước uống phát hiện ra rằng con người, những người đã bị phá hủy môi trường sống của chúng đã xây dựng một con đập cho khu nghỉ mát giải trí. Các loài động vật cố gắng để lưu các đồng bằng và gửi tin nhắn đến con người không can thiệp với thiên nhiên. ',1,1,12,1)
insert into PHIM values (N'Thỏ Peter ','thopeter.jpg','https://www.youtube.com/embed/tMOdyWfY9B0',N'Thỏ Peter thể hiện tính cách của một chú thỏ tiệc tùng đúng chất khi lập hội, làm thống soái, dẫn cả tổ đội vào “phá đảo” khu vườn xanh tốt. Thêm vào đó, với chất tài lanh, tăng động, Peter sẽ có những màn nhào lộn như 1 tay pakour thứ thiệt hay màn drift nặng mông giữa các luống rau chẳng kém gì Fast & Furious phiên bản động vật. Từ đây, Peter còn không ngần ngại đối đầu với chủ vườn điển trai mới toanh – McGregor để giành lại khu đất mà Peter cho rằng đáng lý phải thuộc về chú và đồng bọn. Không chỉ vậy, Peter còn quyết một phen chơi lớn khi đưa hội chị em bạn dì trong nhà “phượt” một chuyến lên tận London xa xôi để thị uy kẻ thù không đội trời chung McGregor. Câu chuyện từ đây đã vượt xa khỏi phạm vi khu vườn đồng quê và xung đột giữa… hai người “đàn ông” Peter và McGregor cũng được nâng tầm lên một nấc thang mới. ',1,1,12,1) 
insert into PHIM values (N'NGÒI NỔ','ngoino.jpg','https://www.youtube.com/embed/mNKdoDp85Ug',N'Phim hành động  ',1,5,5,1)
insert into PHIM values (N'Binh Đoàn Phú Quý','binhdoanphuquy.jpg','https://www.youtube.com/embed/QYt-rbNHJF4',N'Binh Đoàn Phú Quý là một bộ phim điện ảnh hài hước do Hồng Kông sản xuất vào năm 1989. Lưu Đức Hoa và Hồng Kim Bảo vào vai những người cảnh sát điều tra một bọn tội phạm,phim có rất nhiều pha võ thuật đẹp mắt từ dàn diễn viên cực kỳ nổi tiếng của võ thuật Hồng Kông  ',1,4,6,1) 
insert into PHIM values (N'PHI VỤ TIỀN GIẢ ','phivutiengia.jpg','https://www.youtube.com/embed/_fZzEssjPBc',N'Cảnh sát Hồng Kông đã phá một vụ án làm tiền giả quy mô lớn và bắt được Lee Man, một thành viên chủ chốt của đường dây buôn tiền giả, khi hắn đang trốn chạy. đến Thái Lan. Các thanh tra cảnh sát đang cố gắng tìm ra danh tính của Painter, kẻ chủ mưu của băng nhóm làm tiền giả từ lời khai của Lee Man. Bất chấp sự truy đuổi gắt gao của cảnh sát, băng nhóm của Painter vẫn lừa mua tiền giấy và cướp một chiếc xe tải chở đầy mực an ninh để sản xuất hàng loạt tờ đô la giả có thể qua mặt các chuyên gia. tiền tệ. Sở cảnh sát nhận ra họ phải đối mặt với một kẻ thù mạnh hơn họ tưởng ...',1,2,7,1) 
insert into PHIM values (N'KẺ LẬP DỊ','kelapdi.jpg','https://www.youtube.com/embed/bnTwm9GQYPs',N'Chev Chelios (Jason Statham) là một sát thủ chuyên nghiệp của một băng đảng xã hội đen ở Los Angeles. Sau nhiều năm lưu lạc khắp thế gian, một ngày nọ anh quyết định rửa tay gác kiếm để sống một cuộc đời khác với cô bạn gái Eve (Amy Smart). Boss Carlito (Carlos Sanz) chấp nhận quyết định của Chev, nhưng buộc anh ta phải thực hiện một nhiệm vụ cuối cùng: giết thủ lĩnh của tổ chức Triad ở LA. Nhưng Chev đã không làm được điều đó. Một buổi sáng, Chev nhận được một đĩa DVD qua đường bưu điện. Quay qua đĩa, anh thấy Verona Jose (Pablo Cantillo), một thành viên trong băng đảng, đang dùng kim đâm vào cổ tay mình - lúc đó, anh đang hôn mê vì bị lừa uống thuốc ngủ. Dung dịch trong kim tiêm được giới xã hội đen gọi là "cocktail Trung Quốc". Chất độc này có thể giết người trong tích tắc, nhưng sẽ không gây hại gì nếu có nhiều adrenaline trong máu. Để tăng lượng adrenaline, người được tiêm phải liên tục vận động mạnh hoặc sửdụng chất kích thích. Nếu nó ngừng hoạt động, nồng độ adrenaline giảm xuống và loại "cocktail Trung Quốc" sẽ gây co thắt tim dẫn đến tử vong.',1,3,8,1) 
insert into PHIM values (N'CHIẾN BINH BẤT TỬ','chienbinhbattu.jpg','https://www.youtube.com/embed/Rh7mO4gWJhY',N'Chiến Binh Bất Tử là câu chuyện cuộc chiến giữa các vị thần trên đỉnh Olympia và những thần dân Hy Lạp chống lại cuộc xâm lược của đế chế Hyperion (Mickey Rourke). Một đội quân khát máu đã tiến vào Hy Lạp tàn sát không thương tiếc dân lành chỉ với một mục đích là tìm một loại vũ khí chết người để tiêu diệt và chiếm lĩnh toàn thế giới. Khi số phận của nhân loại thực sự bị đe dọa Zeus vị thần tối cao trên đỉnh Olympia đã chọn Theseus (Cavill) phải lãnh đạo nhân dân chống lại Hyperion.',1,4,12,1) 
insert into PHIM values (N'CẨM Y VỆ TÀI NĂNG','camyvetainang.jpg','https://www.youtube.com/embed/wQ9pDLaqWC4',N'Phim kiếm hiệp  ',1,6,9,1) 
insert into PHIM values (N'LONG HỔ MÔN','longhomon.jpg','https://www.youtube.com/embed/FE6yY5co3SI',N'Phim Long Hổ Môn thuyết minh kể về môn phái Long Hổ Môn được sáng lập bởi hai vị sư phụ Vương Phục Hổ và Vương Hàng Long. Hai vị sư phụ này không chỉ nổi danh vì tài võ nghệ cao cường mà còn là những người rất có nghĩa khí. Vương Phục Hổ có hai người con trai tên là Vương Tiểu Long và Vương Tiểu Hổ.',1,3,11,1) 
insert into PHIM values (N'Yêu Là Thế','yeulathe.jpg','https://www.youtube.com/embed/VGsWaC9-SqY',N'Đây là một bộ phim Hàn Quốc năm 2008. Được chuyển thể từ Love Story, một webtoon nổi tiếng của Kang Full, đây là bộ phim thứ hai của đạo diễn Ryu Jang-ha. Phim có sự tham gia của Yoo Ji-tae, Lee Yeon-hee, Chae Jung-an và Kang-in.',1,3,12,1) 
insert into PHIM values (N'Chuyện Tình Chàng Ngốc','chyentinhchangngoc.jpg','https://www.youtube.com/embed/Du2ZdL38EJs',N'Phim Chuyện Tình Chàng Ngốc Ho Goo có một cô em gái song sinh là Ho Gyeong. Anh ấy đã cố gắng để qua vòng thi công chức nhà nước nhưng anh ấy đã thất bại 7 lần. Trong cuộc đời mình anh chưa từng hẹn hò với bất kì cô gái nào.Một ngày nọ, anh đã gặp được Do Hee. Trong những ngày còn đi học, cô là cô gái nổi tiếng nhất trong trường trung học. Cô là thành viên của đội tuyển bơi lội quốc gia và cô luôn nuôi dưỡng ý chí sẽ giành gải vô địch. Cô cũng nói chuyện như những người đàn ông. Họ thường dành tất cả các buổi tối cùng nhau, nhưng buổi sáng nọ anh chỉ thấy một đứa bé cạnh mình và Do Hee đã biến mất. Sau khi anh gặp lại Do Hee, anh rơi vào một mối tình phức tạp và một tình bạn nguy hiểm.',1,5,5,1) 
insert into PHIM values (N'Cô dâu 15 tuổi','codau.jpg','https://www.youtube.com/embed/PhtlJbHV-fk',N'Phim Cô Dâu 15 Tuổi là câu chuyện về Sang Min, một giáo viên mỹ thuật thực tập vừa từ Mỹ về. Bố Sang Min bắt anh phải kết hôn với Bo Eun vì lời hứa của ông anh và ông của Bo Eun. Nhưng vấn đề chính là Bo Eun chỉ mới 15 tuổi. Trong phim hay này, ông của Bo Eun nói dối với gia đình là mình bị bệnh sắp qua đời và mong sẽ được nhìn thấy hai đứa cháu kết hôn trước khi nhắm mắt. Vậy là Bo Eun và Sang Min đã kết hôn để vui lòng các bậc phụ huynh, nhưng họ giữ bí mật với bạn bè và mọi người. Rắc rối xảy ra khi nơi Sang Min làm giáo viên thực tập lại chính là trường và lớp học của Bo Eun.',1,3,6,1) 
 

 
delete CHITIETLOAI
insert into CHITIETLOAI values (1,1)
insert into CHITIETLOAI values (1,2)
insert into CHITIETLOAI values (2,2)
insert into CHITIETLOAI values (2,3)
insert into CHITIETLOAI values (3,1)
insert into CHITIETLOAI values (3,3)
insert into CHITIETLOAI values (4,1)
insert into CHITIETLOAI values (4,2)
insert into CHITIETLOAI values (5,1)
insert into CHITIETLOAI values (5,2)
insert into CHITIETLOAI values (6,2)
insert into CHITIETLOAI values (6,3)
insert into CHITIETLOAI values (7,1)
insert into CHITIETLOAI values (7,3)
insert into CHITIETLOAI values (8,1)
insert into CHITIETLOAI values (8,2)
insert into CHITIETLOAI values (9,1)
insert into CHITIETLOAI values (9,3)
insert into CHITIETLOAI values (10,1)
insert into CHITIETLOAI values (10,2)
insert into CHITIETLOAI values (11,1)
insert into CHITIETLOAI values (11,3)
insert into CHITIETLOAI values (12,3)
insert into CHITIETLOAI values (12,4)
insert into CHITIETLOAI values (13,1)
insert into CHITIETLOAI values (13,5)
insert into CHITIETLOAI values (14,5)
insert into CHITIETLOAI values (14,2)
insert into CHITIETLOAI values (15,4)
insert into CHITIETLOAI values (15,5)
insert into CHITIETLOAI values (16,2)
insert into CHITIETLOAI values (16,3)
insert into CHITIETLOAI values (17,1)
insert into CHITIETLOAI values (17,4)
insert into CHITIETLOAI values (18,3)
insert into CHITIETLOAI values (18,4)
insert into CHITIETLOAI values (19,5)
insert into CHITIETLOAI values (19,3)
insert into CHITIETLOAI values (20,2)
insert into CHITIETLOAI values (20,5)
insert into CHITIETLOAI values (21,4)
insert into CHITIETLOAI values (21,1)
insert into CHITIETLOAI values (22,3)
insert into CHITIETLOAI values (22,4)
insert into CHITIETLOAI values (23,4)
insert into CHITIETLOAI values (23,5)

delete PHIM_DV
insert into PHIM_DV values (1,1)
insert into PHIM_DV values (1,2)
insert into PHIM_DV values (2,1)
insert into PHIM_DV values (2,3)
insert into PHIM_DV values (3,3)
insert into PHIM_DV values (3,2)
insert into PHIM_DV values (4,1)
insert into PHIM_DV values (4,2)
insert into PHIM_DV values (5,1)
insert into PHIM_DV values (5,3)
insert into PHIM_DV values (6,3)
insert into PHIM_DV values (6,2)
insert into PHIM_DV values (7,1)
insert into PHIM_DV values (7,2)
insert into PHIM_DV values (8,1)
insert into PHIM_DV values (8,3)
insert into PHIM_DV values (9,3)
insert into PHIM_DV values (9,2)
insert into PHIM_DV values (10,3)
insert into PHIM_DV values (10,2)
insert into PHIM_DV values (11,1)
insert into PHIM_DV values (11,2)
insert into PHIM_DV values (12,2)
insert into PHIM_DV values (12,3)
insert into PHIM_DV values (13,3)
insert into PHIM_DV values (13,1)
insert into PHIM_DV values (14,1)
insert into PHIM_DV values (14,2)
insert into PHIM_DV values (15,3)
insert into PHIM_DV values (15,2)
insert into PHIM_DV values (16,1)
insert into PHIM_DV values (16,3)
insert into PHIM_DV values (17,2)
insert into PHIM_DV values (17,3)
insert into PHIM_DV values (18,3)
insert into PHIM_DV values (18,2)
insert into PHIM_DV values (19,2)
insert into PHIM_DV values (19,1)
insert into PHIM_DV values (20,3)
insert into PHIM_DV values (20,1)
insert into PHIM_DV values (21,2)
insert into PHIM_DV values (21,3)
insert into PHIM_DV values (22,1)
insert into PHIM_DV values (22,3)
insert into PHIM_DV values (23,1)
insert into PHIM_DV values (23,2)


delete PHIMSAPCHIEU
DBCC CHECKIDENT (PHIMSAPCHIEU, RESEED, 0)
DBCC CHECKIDENT (PHIMSAPCHIEU)
insert into PHIMSAPCHIEU values (N'KỊCH TRƯỜNG CỦA TAKEMICHI',N'kichtruong.jpg','https://www.youtube.com/embed/0y4yAFpsUew')
insert into PHIMSAPCHIEU values (N'VENOM: ĐỐI MẶT TỬ THÙ',N'venom.jpg','https://www.youtube.com/embed/EVWdzVtSh1I')
insert into PHIMSAPCHIEU values (N'VÙNG ĐẤT CÂM LẶNG II',N'vungdat.jpg','https://www.youtube.com/embed/OjRmRyWyiZM')
insert into PHIMSAPCHIEU values (N'DORAEMON: STAND BY ME 2',N'doremon.jpg','https://www.youtube.com/embed/GXnOs4Hj8MA')
insert into PHIMSAPCHIEU values (N'MA TRẬN: HỒI SINH',N'matran.jpg','https://www.youtube.com/embed/l2UTOJC5Tbk')
insert into PHIMSAPCHIEU values (N'HỐ ĐỊA NGỤC',N'hodianguc.jpg','https://www.youtube.com/embed/PPrap89FiZI')

select * from ADMINFILM
select * from BinhLuan
select * from ChiTietLoai
select * from DanhGia
select * from DienVien
select * from Loai
select * from NamPhatHanh
select * from THANHVIEN
select * from Phim
select * from PHIMSAPCHIEU
select * from Phim_DV
select * from QuocGia
select * from TrangThai





select * from PHIM where ID_PHIM=23

select * from CHITIETLOAI
where ID_PHIM=23
