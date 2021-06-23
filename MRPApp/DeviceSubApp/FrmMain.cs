using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DeviceSubApp
{
    public partial class FrmMain : Form
    {
        MqttClient client;
        string connectionString;//DB연결 문자열 | MQTT Broker address
        ulong lineCount;
        delegate void UpdateTextCallback(string message);//스레드상에서 윈폼 RichTextbox 텍스트를 출력할 때 필요한 것

        public FrmMain()
        {
            InitializeComponent();
            InitailizeAllData();
        }

        private void InitailizeAllData()
        {
            connectionString = "Data Source="+TxtConnectionString.Text+";Initial Catalog=MRP;User ID=sa;password=mssql_p@ssw0rd!";
            lineCount = 0;
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
            IPAddress brokerAddress;
            try
            {
                brokerAddress = IPAddress.Parse(TxtConnectionString.Text);
                client = new MqttClient(brokerAddress);
                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateText($">>>> 받은 메세지 : {message}");
            }
            catch (Exception ex)
            {
                UpdateText($">>>>ERROR!! : {ex.Message}");
            }
        }//메시지 박스가 뜨면 팝업이 뜨고 진행이 안됨.. 누가 닫아줘야 함. 에러메시지도 리치박스안에서 처리되야 함. 로그로 정상적으로 다 찍어줘야 함.

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(TxtClientID.Text);//SUBSCR01
            UpdateText(">>>>> Client Connect");

            client.Subscribe(new string[] { TxtSubscriptionTopic.Text },
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            UpdateText(">>>>Subscring to : " + TxtSubscriptionTopic.Text);

            BtnConnect.Enabled = false;
            BtnDisconnect.Enabled = true;
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            UpdateText(">>>>Client disconnected");
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
        }

        private void UpdateText(string message)//delegate는 파라미터 시그니처가 같아야 한다. 이벤트 핸들러들을 의미한다. 대리자로 처리하는 것이 에러 구문을 띄우는 것이다.
        {
            if (RtbSubscr.InvokeRequired)
            {
                UpdateTextCallback callback =new UpdateTextCallback(UpdateText);
                this.Invoke(callback, new object[] { message });
            }
            else
            {
                RtbSubscr.AppendText(message + "\n");
                RtbSubscr.ScrollToCaret();//message log나 출력이 많이 되는 거를 대리자랑 업데이트 테스트를 많이 하게 된다. 그럼 별 문제 없이 시행된다.
            }
        }
    }
}
