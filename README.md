# MiniProject_SimpleMRP(코드분석서 작성하기)
공정관리 with RasberryPi
미니프로젝트 데스크탑앱(자동화 모니터링)-- 데이터 송수신은 MQTT, DB 연동은 MRP 엔티티
-------------
<br>
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EC%84%BC%EC%8B%B1%20%EB%A8%B8%EC%8B%A0.jpg" width="80%" height="60%" ><br><br>

목차
---------------
1. 디버깅
2. 소스코드
3. 구동화면
4. DB
5. 라즈베리파이 소스코드
6. 설치된 누겟패키지
<br><br>

##1. 디버깅
-------------
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%ED%94%84%EB%A1%9C%EC%84%B8%EC%8A%A4%20KILL.png" width="80%" height="60%" ><br><br>
프로그램을 종료해도 백그라운드에서 프로그램이 메모리에 있어서 빌드가 되지 않을 수 있다. 그럴 때는 여기서 KILL해줘야 한다.<br>
스레드문제인 듯 하다. 이를 해결하려면 페이지가 언로드 될 시 다음의 코드가 시행되도록 설정해줘야 한다.<br>
~~~
 private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //자원해제
            if (client.IsConnected) client.Disconnect();
            timer.Dispose();
            //new delete 자원해제가 매우 중요하다.
        }
~~~

##2. 주요 소스코드 바로가기
-------------
* ![Helper](https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/Helper/Commons.cs)<br>
* ![DataAccess](https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/Logic/DataAccess.cs)<br>
* ![DataAccess](https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/Logic/DataAccess.cs)<br>
* ![View](https://github.com/ochestra365/MiniProject_SimpleMRP/tree/main/MRPApp/MRPApp/View)<br>
* ![Model](https://github.com/ochestra365/MiniProject_SimpleMRP/tree/main/MRPApp/MRPApp/Model)

##3. 구동화면
-------------
<br>
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EA%B3%B5%EC%A0%95%EA%B3%84%ED%9A%8D.png" width="80%" height="60%" ><br><br>
공정계획을 나타낸 것이다.
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EA%B3%B5%EC%A0%95%EB%AA%A8%EB%8B%88%ED%84%B0%EB%A7%81.png" width="80%" height="60%" ><br><br>
공정모니터링을 나타낸 것이다.
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EC%84%A4%EC%A0%95.png" width="80%" height="60%" ><br><br>
초기 공장 설정을 나타낸 것이다.
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/MQTT.png" width="80%" height="60%" ><br> 
MQTT화면을 윈폼으로 구성한 것이다.
##4. DB
-------------
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EB%8D%B0%EC%9D%B4%ED%84%B0%20%EC%86%A1%EC%88%98%EC%8B%A0%20%EC%84%B1%EA%B3%B5.png" width="80%" height="60%" ><br> 
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/MQTT%20Explorer.png" width="80%" height="60%" ><br> 
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EB%8B%A4%EC%9D%B4%EC%96%B4%EA%B7%B8%EB%9E%A8.png" width="80%" height="60%" ><br> 
##5. 라즈베리파이 소스코드
-------------
* ![Rasberry_PI](https://github.com/ochestra365/Rasberry_python/blob/main/check_publish_app.py)


##6. 설치된 누겟패키지
-------------
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EC%84%A4%EC%B9%98%EB%90%9C%20%EB%88%84%EA%B2%9F%ED%8C%A8%ED%82%A4%EC%A7%801.png" width="80%" height="60%" ><br> 
<img src="https://github.com/ochestra365/MiniProject_SimpleMRP/blob/main/MRPApp/MRPApp/%EA%B9%83%EC%97%90%20%EC%98%AC%EB%A6%B4%20%EC%82%AC%EC%A7%84/%EC%84%A4%EC%B9%98%EB%90%9C%20%EB%88%84%EA%B2%9F%ED%8C%A8%ED%82%A4%EC%A7%80%202.png" width="80%" height="60%" ><br> 

현재 서보모터 밖에 없으므로, 모터의 각을 기준으로 OEE를 체크할 것이다. 나중에 스텝모터로 회전을 측정해야 함. -->기준은 시간이다.
~~~
#Library
import time
import datetime as dt
from typing import OrderedDict
import RPi.GPIO as GPIO
import random
import paho.mqtt.client as mqtt
import json

mortor = 21 # Raspberry pi PIN 21
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.setup(mortor, GPIO.OUT)
cycles = GPIO.PWM(mortor, 50)

dev_id = 'MACHINE01'
broker_address = '210.119.12.92'
pub_topic = 'factory1/machine1/data/'

def send_data(result):
    
    currtime = dt.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')
    #json data gen
    raw_data = OrderedDict()
    raw_data['DEV_ID'] = dev_id
    raw_data['PRC_TIME'] = currtime
    raw_data['PRC_MSG'] = result
    
    pub_data = json.dumps(raw_data, ensure_ascii=False, indent='\t')
    print(pub_data)
    #mqtt_publish
    client2.publish(pub_topic, pub_data)

def loop():
    while True:
        start = time.time()
        num = random.randrange(2,5)
        for i in range(num):
            cycles.start(0)
            cycles.ChangeDutyCycle(3)
            time.sleep(2)
            cycles.stop()
        WorkTime = time.time() - start
        send_data(WorkTime)

#mqtt inti
print('MQTT Client')
client2 = mqtt.Client(dev_id)
client2.connect(broker_address)
print('MQTT Client connected')

if(__name__ == '__main__'):
    try:
        loop()
    except KeyboardInterrupt:
        GPIO.cleanup()
~~~
