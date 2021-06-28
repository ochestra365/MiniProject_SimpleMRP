# MiniProject_SimpleMRP
공정관리 with RasberryPi
미니프로젝트 데스크탑앱(자동화 모니터링)-- 데이터 송수신은 MQTT, DB 연동은 MRP 엔티티
-------------
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EC%84%BC%EC%8B%B1%20%EB%A8%B8%EC%8B%A0.jpg" width="40%" height="30%" >


목차
---------------
1. 디버깅
2. 소스코드
3. 분석
<br><br>
-------------
##목차<br><br>
* ![Helper](https://github.com/ochestra365/MiniProject_Desktop/blob/main/WpfSMSApp/Helper/Commons.cs)<br>

##설명
-------------

<br><br><br>
해당 프로젝트는 누겟패키지를 최대한 활용하여 만들었다. 설치한 누겟패키지는 현재 다음과 같다.<br><br>
<img src="https://github.com/ochestra365/MiniProject_Desktop/blob/main/WpfSMSApp/WPF%EA%B9%83%ED%97%88%EB%B8%8C%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%9D%B4%EB%AF%B8%EC%A7%80%20%EC%82%AC%EC%A7%84%EB%93%A4/%EB%88%84%EA%B2%9F%ED%8C%A8%ED%82%A4%EC%A7%80.png" width="40%" height="30%" ><br><br>
Helper 폴더에는 모든 클래스에 유용하게 사용되는 코드들이 있다. Getmd5Hash로 모든 암호화하는 것, 이메일 정규화 식, Metro MessageBox의 공통메서드가 있다.<br><br>
Logic.DataAccess 폴더에는 DB에 있는 데이터 값을 불러오고 수정하는 코드가 작성되어 있다. <br><br>
~~~
using System.Data.Entity.Migrations;
~~~
데이터베이스 엔티티를 설치해서 해당 자원을 쓸 수 있었다. <br><br>
<img src="https://github.com/ochestra365/MiniProject_Desktop/blob/main/WpfSMSApp/WPF%EA%B9%83%ED%97%88%EB%B8%8C%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%9D%B4%EB%AF%B8%EC%A7%80%20%EC%82%AC%EC%A7%84%EB%93%A4/%EC%9D%B4%EB%AF%B8%EC%A7%80%2020210401001.png" width="40%" height="30%" ><br><br>
확인할 수 있는 바와 같이 SSMS의 다이어그램이 비쥬얼 스튜디오 상에 나타나며 Database Entity의 다양한 솔루션들을 활용할 수 있다.<br><br>
다음으로 View 폴더는 내가 만든 WPF 페이지들이 만들어져 있다. 초기 화면을 만들고 나서<br><br>
복사해서 재사용한다. 이때, 클래스명이 바뀌게 되는 데, xaml에서는 Title 명을 클래스와 동일시 하고<br><br>
로컬과 클래스의 경로를 재설정해준다.<br><br> xaml.cs에서는 namespace경로를 잡아주고, partial 클래스와 InitializeComponent의 public명을 클래스 별로 맞춰준다.

-------------



