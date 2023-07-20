-- Insert into table RouteType
insert into RouteTypes( name,image, description1, description2,status) Values( N'Front-end-development', 'https://files.fullstack.edu.vn/f8-prod/learning-paths/2/63b4642136f3e.png', N'Lập trình viên Front-end là người xây dựng ra giao diện websites. Trong phần này F8 sẽ chia sẻ cho bạn lộ trình để trở thành lập trình viên Front-end nhé.', N'Hầu hết các websites hoặc ứng dụng di động đều có 2 phần là Front-end và Back-end. Front-end là phần giao diện người dùng nhìn thấy và có thể tương tác, đó chính là các ứng dụng mobile hay những website bạn đã từng sử dụng. Vì vậy, nhiệm vụ của lập trình viên Front-end là xây dựng các giao diện đẹp, dễ sử dụng và tối ưu trải nghiệm người dùng. Tại Việt Nam, lương trung bình cho lập trình viên front-end vào khoảng 16.000.000đ / tháng. Dưới đây là các khóa học F8 đã tạo ra dành cho bất cứ ai theo đuổi sự nghiệp trở thành một lập trình viên Front-end. Các khóa học có thể chưa đầy đủ, F8 vẫn đang nỗ lực hoàn thiện trong thời gian sớm nhất.',0);
insert into RouteTypes( name,image, description1, description2,status) Values( N'Back-end-development', 'https://files.fullstack.edu.vn/f8-prod/learning-paths/3/63b4641535b16.png', N'Trái với Front-end thì lập trình viên Back-end là người làm việc với dữ liệu, công việc thường nặng tính logic hơn. Chúng ta sẽ cùng tìm hiểu lộ trình học Back-end nhé.', N'Hầu hết các websites hoặc ứng dụng di động đều có 2 phần là Front-end và Back-end. Front-end là phần giao diện người dùng nhìn thấy và có thể tương tác. Back-end là nơi xử lý dữ liệu và lưu trữ. Vì vậy, nhiệm vụ của lập trình viên Back-end là phân tích thiết kế dữ liệu, xử lý logic nghiệp vụ của các chức năng trong ứng dụng. Tại Việt Nam, lương trung bình cho lập trình viên Back-end vào khoảng 19.000.000đ / tháng. Dưới đây là các khóa học F8 đã tạo ra dành cho bất cứ ai theo đuổi sự nghiệp trở thành một lập trình viên Back-end. Các khóa học có thể chưa đầy đủ, F8 vẫn đang nỗ lực hoàn thiện trong thời gian sớm nhất.',0);

-- Insert into table RouteTypeItems
insert into RouteTypeItems( Name,Description,RouteTypeID) Values( N'Tìm hiểu về ngành IT', N'Để theo ngành IT - Phần mềm cần rèn luyện những kỹ năng nào? Bạn đã có sẵn tố chất phù hợp với ngành chưa? Cùng thăm quan các công ty IT và tìm hiểu về văn hóa, tác phong làm việc của ngành này nhé các bạn.', '1' );
insert into RouteTypeItems( name,description,routeTypeID) Values( N'HTML và CSS', N'Để học web Front-end chúng ta luôn bắt đầu với ngôn ngữ HTML và CSS, đây là 2 ngôn ngữ có mặt trong mọi website trên internet. Trong khóa học này F8 sẽ chia sẻ từ những kiến thức cơ bản nhất. Sau khóa học này bạn sẽ tự làm được 2 giao diện websites là The Band và Shopee.',1);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'JavaScript', N'Với HTML, CSS bạn mới chỉ xây dựng được các websites tĩnh, chỉ bao gồm phần giao diện và gần như chưa có xử lý tương tác gì. Để thêm nhiều chức năng phong phú và tăng tính tương tác cho website bạn cần học Javascript.',1);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'Sử dụng Ubuntu/Linux', N'Cách làm việc với hệ điều hành Ubuntu/Linux qua Windows Terminal & WSL. Khi đi làm, nhiều trường hợp bạn cần nắm vững các dòng lệnh cơ bản của Ubuntu/Linux.',1);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'Libraries and Frameworks', N'Một websites hay ứng dụng hiện đại rất phức tạp, chỉ sử dụng HTML, CSS, Javascript theo cách code thuần (tự code từ đầu tới cuối) sẽ rất khó khăn. Vì vậy các Libraries, Frameworks ra đời nhằm đơn giản hóa, tiết kiệm chi phí và thời gian để hoàn thành một sản phẩm website hoặc ứng dụng mobile.',1);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'Tìm hiểu về ngành IT', N'Để theo ngành IT - Phần mềm cần rèn luyện những kỹ năng nào? Bạn đã có sẵn tố chất phù hợp với ngành chưa? Cùng thăm quan các công ty IT và tìm hiểu về văn hóa, tác phong làm việc của ngành này nhé các bạn.', 2 );
insert into RouteTypeItems( name,description,routeTypeID) Values( N'HTML và CSS', N'Để học web Front-end chúng ta luôn bắt đầu với ngôn ngữ HTML và CSS, đây là 2 ngôn ngữ có mặt trong mọi website trên internet. Dù bạn có theo Back-end thì công việc của bạn nhiều khi vẫn cần phải ghép dữ liệu với HTML, CSS.',2);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'Ngôn ngữ lập trình', N'Có rất nhiều ngôn ngữ để bạn có thể làm việc với Back-end, tuy nhiên bạn không cần phải học tất cả. Bạn chỉ cần tập trung vào 1 ngôn ngữ là có thể làm việc tốt. Tại đây chúng ta sẽ bắt đầu với ngôn ngữ lập trình Javascript.',2);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'Sử dụng Ubuntu/Linux', N'Cách làm việc với hệ điều hành Ubuntu/Linux qua Windows Terminal & WSL. Khi đi làm, nhiều trường hợp bạn cần nắm vững các dòng lệnh cơ bản của Ubuntu/Linux.',2);
insert into RouteTypeItems( name,description,routeTypeID) Values( N'Libraries and Frameworks', N'Một ứng dụng Back-end hiện đại có thể rất phức tạp, việc sử dụng code thuần (tự tay code từ đầu) không phải là một lựa chọn tốt. Vì vậy các Libraries và Frameworks ra đời nhằm đơn giản hóa, tiết kiệm thời gian và tiền bạc để nhanh chóng tạo ra được sản phẩm cuối cùng.',2);


-- Insert Course table
insert into Courses(title, price, isPublished, level, description, image) Values( N'HTML CSS từ Zero đến Hero', 0, 1, 'Easy', N'Trong khóa này chúng ta sẽ cùng nhau xây dựng giao diện 2 trang web là The Band & Shopee.' , N'https://files.fullstack.edu.vn/f8-prod/courses/2.png');
insert into Courses(title, price, isPublished, level, description, image) Values(N'Lập trình JavaScript cơ bản ', 0, 1,'Medium', N'Học Javascript cơ bản phù hợp cho người chưa từng học lập trình. Với hơn 100 bài học và có bài tập thực hành sau mỗi bài học.', N'https://files.fullstack.edu.vn/f8-prod/courses/1.png');
insert into Courses(title, price, isPublished, level, description, image) Values(N'Xây Dựng Website với ReactJS', 0, 1,'Hard',  N'Khóa học ReactJS từ cơ bản tới nâng cao, kết quả của khóa học này là bạn có thể làm hầu hết các dự án thường gặp với ReactJS.', N'https://files.fullstack.edu.vn/f8-prod/courses/13/13.png');
insert into Courses(title, price, isPublished, level, description, image) Values( N'Node & ExpressJS', 0, 1,'Hard', N'Học Back-end với Node & ExpressJS framework, hiểu các khái niệm khi làm Back-end và xây dựng RESTful API cho trang web.', N'https://files.fullstack.edu.vn/f8-prod/courses/6.png');
insert into Courses(title, price, isPublished, level, description, image) Values( N'HTML CSS Pro', 500000, 1,'Easy', N'Cách dễ nhất để học HTML CSS cho người mới bắt đầu!', 'https://files.fullstack.edu.vn/f8-prod/courses/15/62f13d2424a47.png');
insert into Courses(title, price, isPublished, level, description, image) Values( N'Responsive Với Grid System', 0, 1,'Hard', N'Trong khóa này chúng ta sẽ học về cách xây dựng giao diện web responsive với Grid System, tương tự Bootstrap 4.', N'https://files.fullstack.edu.vn/f8-prod/courses/3.png');
insert into Courses(title, price, isPublished, level, description, image) Values( N'Kiến Thức Nhập Môn IT', 0, 1,'Easy', N'Để có cái nhìn tổng quan về ngành IT - Lập trình web các bạn nên xem các videos tại khóa này trước nhé.', N'https://files.fullstack.edu.vn/f8-prod/courses/7.png');
select * from Courses
-- insert in to table Chapter
-- Course ID: 1
insert into Chapters (Name, CourseID) Values (N'1. Bắt đầu', 1);
insert into Chapters (Name, CourseID) Values (N'1. Làm quen với HTML', 1);
insert into Chapters (Name, CourseID) Values (N'1. Làm quen với CSS', 1);
insert into Chapters (Name, CourseID) Values (N'1. Đệm viền và khoang lề', 1);
insert into Chapters (Name, CourseID) Values (N'1. Thuộc tính tạo nền', 1);

-- insert in to table lesson
-- Chapter 1
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Bạn sẽ làm được gì sau khóa học', '', '', '', '', 'https://www.youtube.com/embed/R6plN3FvzFY', 1);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Tìm hiểu về HTML, CSS', '', '', '', '', 'https://www.youtube.com/embed/zwsPND378OQ', 1);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Làm quen với Dev tools','', '', '', '', 'https://www.youtube.com/embed/7BJiPyN4zZ0', 1);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Cài đặt VS Code, Page Ruler extension', '', '', '', '', 'https://www.youtube.com/embed/ZotVkQDC6mU', 1);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Khắc phục lỗi cài đặt Page Ruler Redux ','', '', '', '', 'https://www.youtube.com/embed/ZotVkQDC6mU', 1);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Bạn sẽ làm được gì sau khóa học','', '', '', '', 'https://www.youtube.com/embed/ZotVkQDC6mU', 1);
-- Chapter 2
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Cấu trúc 1 file HTML',  '', '', '', 'practice', 'https://www.youtube.com/embed/LYnrFSGLCl8', 22);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Comments trong HTML',  '', '', '', 'practice', 'https://www.youtube.com/embed/JG0pdfdKjgQ', 22);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Thẻ HTML thông dụng',  '', '', '', 'practice', 'https://www.youtube.com/embed/AzmdwZ6e_aM', 22);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Attribute trong HTML',  '', '', '', 'practice', 'https://www.youtube.com/embed/UYpIh5pIkSA', 22);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'ID và Class',  '', '', '', 'practice','https://www.youtube.com/embed/4J6d8cr0X48', 22);
delete from Lessons
where chapterID = 22
-- Chapter 3
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Sử dụng CSS trong HTML',  '', '', '', '', 'https://www.youtube.com/embed/NsSsJTg29oE', 3);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'CSS Padding',  '', '', '', '', 'https://www.youtube.com/embed/aj-lD4XXr8A', 3);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'CSS Border',  '', '', '', '', 'https://www.youtube.com/embed/VbzOimNAOxE', 3);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'CSS Margin',  '', '', '', '','https://www.youtube.com/embed/8X48l0CK5_4', 3);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'CSS-Box-sizing',  '', '', '', '', 'https://www.youtube.com/embed/bv16wjxgV4U', 3);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'CSS-Background-clip',  '', '', '', '', 'https://www.youtube.com/embed/hMWhvbCJIq8', 3);
-- Chapter 4
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Giới thiệu Flexbox',  '', '', '', '', 'https://www.youtube.com/embed/bVUN6nS82k8', 4);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Ví dụ dùng BEM tạo buttons',  '', '', '', '', 'https://www.youtube.com/embed/k1ZH5Mlj3tw', 4);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Ví dụ dùng BEM tạo Toast Message UI',  '', '', '', '', 'https://www.youtube.com/embed/7c7ABhaQJGM', 4);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'BEM - Khi các Block lồng nhau thì đặt tên như thế nào?',  '', '', '', '', 'https://www.youtube.com/embed/IddL557icoc', 4);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Dựng source base',  '', '', '', '', 'https://www.youtube.com/embed/1xNzl5SYjPo', 4);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Dựng khung web',  '', '', '', '', 'https://www.youtube.com/embed/-umvdHAfR6E', 4);
-- Chapter 5
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Dựng khung phần danh mục',  '', '', '', '', 'https://www.youtube.com/embed/9_9X9GzVOj0', 5);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Danh mục - base responsive',  '', '', '', '', 'https://www.youtube.com/embed/f4LOGq3v0C0', 5);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Dựng khung: Sắp xếp, lọc sản phẩm',  '', '', '', '', 'https://www.youtube.com/embed/N7T_9a1nZmk', 5);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Sản phẩm: CSS nhãn giảm giá',  '', '', '', '', 'https://www.youtube.com/embed/XL0RM7ZMKC8', 5);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Sản phẩm CSS - Phần 1',  '', '', '', '', 'https://www.youtube.com/embed/3E_8Pnjnrms', 5);
insert into Lessons(Name, Content, Date, NumOfLike, Type, Link, ChapterID) Values(N'Sản phẩm CSS - Phần 2',  '', '', '', '', 'https://www.youtube.com/embed/G9Lx0ejUgzE', 5);

-- insert into table CourseRouteTypeItem
insert into CourseRouteTypeItem( RouteTypeItemsID,CoursesId ) Values(1,7);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(2,1);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(3,2);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(4,6);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(5,3);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(6,7);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(7,1);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(7,5);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(8,2);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(9,6);
insert into CourseRouteTypeItem( RouteTypeItemsID ,CoursesId ) Values(10,3);
