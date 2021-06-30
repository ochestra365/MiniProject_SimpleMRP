#라이브러리
import RPi.GPIO as GPIO
import time
import datetime as dt
from typing import OrderedDict
import paho.mqtt.client as mqtt
import json

#데이터송신 경로
dev_id='MACHINE01'
broker_address='210.119.12.99'
pub_topic='factory1/machine1/data'

#핀설정
Conveyor2=2
Motor16=16
s2=23
s3=24
out=25
NUM_CYCLES=10
currtime=dt.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')

#json gernerating 데이터 딕셔너리
message=''
raw_data=OrderedDict()
raw_data['DEV_ID']=dev_id
raw_data['PRC_TIME']=currtime
raw_data['PRC_MSG']=message
pub_data=json.dumps(raw_data,ensure_ascii=False,indent='\t')
print (pub_data)
client2=mqtt.Client(dev_id)
client2.connect(broker_address)
print ('MQTT Client connected')
#mqtt_publish
client2.publish('factory/machine1/data/',pub_data)

#MQTT설정
dev_id='MACHINE01'
broker_address='210.119.12.99'
pub_topic='factory1/machine1/data'

#셋업
def setup():
	GPIO.setwarnings(False)
	GPIO.setmode(GPIO.BCM)
	GPIO.setup(Motor16,GPIO.OUT)
	GPIO.setup(Conveyor2,GPIO.OUT)
	GPIO.setup(s2,GPIO.OUT)
	GPIO.setup(s3,GPIO.OUT)
	GPIO.setup(out,GPIO.IN,pull_up_down=GPIO.PUD_DOWN)

#데이터 보냄
def send_data(param):
#	message=''
	if param=='GREEN':
		message='OK'
	elif param=='RED':
		message='FAIL'
	elif param=='CONN':
		message='CONNECTED'
	else:
		message='ERR'

#색상값 읽어들임
def read_value(a2,a3):
	GPIO.output(a2,a3)
	GPIO.output(s2,a2)
	GPIO.output(s3,a3)
	time.sleep(0.3)
	start=time.time()
	for impulse_count in range(NUM_CYCLES):
		GPIO.wait_for_edge(out,GPIO.FALLING)
	end=(time.time()-start)
	return NUM_CYCLES/end
	return end

#색상값 감지해서 결과값을 알려줌
def loop():
	red=read_value(GPIO.LOW,GPIO.LOW)
	time.sleep(0.1)
	green=read_value(GPIO.HIGH,GPIO.HIGH)
	time.sleep(0.1)
	blue=read_value(GPIO.LOW,GPIO.HIGH)
	print('red={0}, green={1},blue={2}'.format(red,green,blue))
#	if(red<50):
#		continue
	if(red>green)and(red>blue):
		result='RED'
		send_data(result)
	elif(green>red)and(green>blue):
		result='GREEN'
		send_data(result)
	else:
		result='ERR'
	time.sleep(1)
	
#컨베이어 벨트 굴러가게 함
def Conveyor_GO():
	while True:
		GPIO.output(Conveyor2,False)
		print ("컨베이어 가동중")
		time.sleep(1)

#3초간 컨베이어 벨트 멈추게 함. 이유는 DB에 데이터를 보내는 대기시간이 3초이기 때문이다
def Conveyor_Stop():
	while True:
		print("출력")
		time.sleep(1)
		GPIO.output(Conveyor2,False)
		for i in range(0,3):
			GPIO.output(Conveyor2,True)
			time.sleep(1)
#모터로 불량품 쳐내기
def Sorting_Motor():
	if(loop()=='RED'):
		Conveyor_Stop()
		duty=float(45)/10.0+2.5
		duty2=float(20)/10.0+2.5
		p.ChangeDutyCycle(duty)
		print ("45도로 쳐냄")
		time.sleep(1)
		p.ChangeDutyCycle(duty2)
		print("20도 각도로 돌아옮")
		time.sleep(1)
	else:
		Conveyor_GO()

#메인 렘에 올릴 기능
if(__name__=='__main__'):
#	send_data('CONN',None,None,None)
	try:
		setup()
		p=GPIO.PWM(Motor16,50)
		p.start(5)
		Conveyor_GO()
		loop()
		Sorting_Motor()
		Conveyor_GO()
		
	except KeyboardInterrupt:
		p.stop()
		GPIO.cleanup()


