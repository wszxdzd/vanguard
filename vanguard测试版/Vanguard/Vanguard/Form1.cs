using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;


namespace Vanguard
{
    public partial class Form1 : Form
    {
        #region //global param
        TcpClient client;
        ModbusIpMaster master;
        bool isModbusOpened;
        int waved;
        private Thread wave;
        private Thread State;
        private float X;

        private float Y;

        bool getinfo;

        string WgetTime; //打螺丝时间
        string Wyiled;   //良率
        string Wrealturn; //实际圈数
        string Wrealpow; //实际扭力
        string WholespengTime; //节拍时间

        #endregion
       
        
      

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            btnClear.Enabled = false;
            btnStop.Enabled = false;
            BtnTest.Enabled = false;

            
        }
       Vision vision = Vision.Instance();

        #region //电批连接
        private void btnconnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(vision.param.VanguardIP, Convert.ToInt32(vision.param.VanguardPort));
                if (client.Connected)
                {
                    master = ModbusIpMaster.CreateIp(client);
                    isModbusOpened = true;
                }
                btnconnect.Enabled = false;
                btnClear.Enabled = true;
                BtnTest.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("电批控制器网络未连接，请掉电重试");
            }


            State = new Thread(getHoldRegister);
            State.IsBackground = true;
            State.Start();
           

        }
        #endregion


        #region //打螺丝消耗时间
        public void getTime()
        {
            try
            {
                ushort registeraddress = 52;
                ushort[] nums = { 0 };
                nums = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddress), 1);
                double time = nums[0];
                time = time / 1000d;
                txtSpendtime.Text = Convert.ToString(time) + "s";
                WgetTime = Convert.ToString(time) + "s";
            }
            catch (Exception)
            {
                
              
            }
           

        }
        #endregion


        #region //获取结果
        public void getResult()
        {
            string Time = System.DateTime.Now.ToString("HH:mm:ss");
            ushort registeraddress = 53;
            ushort[] nums = { 0 };
            nums = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddress), 1);
            int Result = nums[0];
            vision.param.ResultSum += 1;
            string number = Convert.ToString(vision.param.ResultSum);
            string str;
            if (Result == 0)
            {
                str = "OK";
                lstResult.Items.Add(Time +" ："+"第" +number +" 个打螺丝 " + str);
                vision.param.ResultOk += 1;
                

            }
            else
            {
                str = "NG";

                lstResult.Items.Add(Time + " ：" + "第" + number + "个打螺丝 " + str);
                getError();
            }
            str="第"+ number+ "个" + str;
            txtSum.Text = Convert.ToString(vision.param.ResultSum);
            txtNumOK.Text = Convert.ToString(vision.param.ResultOk);
            string tmpstr = string.Format("{0},{1},{2},{3}", WgetTime, Wrealturn, Wrealpow, str);
            zxd.LogEx(Application.StartupPath + "\\Log\\Result.csv", tmpstr, true, "花费时间,实际圈数,实际扭力,螺丝结果");


           

            vision.SaveConfigFile();

           

        }
        #endregion

        #region //计算良率
        public void yield()
        {
            //显示统计数据、显示处理时间
           
           
           
            
            
          string   tmpstr = string.Format("良率：{0:0.00}%",1.0*(vision.param.ResultOk)/(vision.param.ResultSum+0.000001)*100.0);
            txtOK.Text=tmpstr;
            Wyiled = tmpstr;
          
        }
        #endregion

        #region //实际圈数
        public void Realturn()
        {
            ushort registeraddress = 22;
            ushort[] nums = { 0 };
            nums = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddress), 1);
           double Result = nums[0];
            Result = Result / 10d;
            txrealTurn.Text = Convert.ToString(Result) + "圈";
            Wrealturn = Convert.ToString(Result) + "圈";
        }
        #endregion

        #region //实际扭力
        public void realpow()
        {
            ushort registeraddress = 51;
            ushort[] nums = { 0 };
            nums = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddress), 1);
            double result = nums[0];
            result = result / 10d;
            txRealpow.Text = Convert.ToString(result) + "mN*m";
            Wrealpow = Convert.ToString(result) + "mN*m";
        }
        #endregion

        #region //波形数据数
        public void numwaveform()
        {
            
            ushort registreaddress = 63;
            ushort[] nums = { 0 };
            nums = master.ReadInputRegisters((ushort)Convert.ToInt16(registreaddress), 1);
            waved = nums[0];
            txwaveform.Text = Convert.ToString(waved);
        }

        public void  numsWaveForm()
        {
            

            #region //改
            Stopwatch nnnn = new Stopwatch();
            int newindex = 0;
            ushort Newregisteraddres1 = 64;
            ushort[] newnums1 = new ushort[waved+125];
            ushort[] newtemp = new ushort[125];
            int d = waved / 125;
            d += 1;
            for (int j = 0; j < d; j++)
           
            {
                newtemp = master.ReadInputRegisters(Newregisteraddres1, 125);
                newtemp.CopyTo(newnums1, newindex);
                newindex += 125;
                Newregisteraddres1 += 125;
            }
           
            string tmpstr1 = string.Join(",", newnums1);
            zxd.LogEx(Application.StartupPath + "\\Log\\Result2.csv", tmpstr1, true, "扭力");
            nnnn.Stop();
            TimeSpan ts2 = nnnn.Elapsed;
            #endregion





        }
       


        #endregion

        #region //错误报告
        public void getError()
        {
            string Time = System.DateTime.Now.ToString("HH:mm:ss");
            string WrongError = "";
            ushort registeraddress =54;
            ushort[] nums = { 0 };
            nums = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddress), 1);
            string number = Convert.ToString(vision.param.ResultSum);
            int Result = nums[0];
           
            switch (Result)
            {
                case 0: 
                    WrongError = "螺丝浮起";
                SENDMSG("0");
                break;
                case 1: 
                    WrongError = "螺丝空转";
                 SENDMSG("1");
                break;
                case 2:
                    WrongError = "检查窗1扭力下限";
                    SENDMSG("2");
                break;
                case 3:
                    WrongError = "检查窗1扭力上限";
                    SENDMSG("3");
                break;
                case 4:
                    WrongError = "检查窗2扭力下限";
                    SENDMSG("4");
                break;
                case 5:
                    WrongError = "检查窗2扭力上限";
                    SENDMSG("5");
                break;
                case 6: 
                    WrongError = "检查窗3扭力下限";
                    SENDMSG("6");
                break;
                case 7:
                    WrongError = "检查窗3扭力上限";
                    SENDMSG("7");
                break;
                case 8:
                    WrongError = "检查窗4扭力下限";
                    SENDMSG("8");
                break;
                case 9:
                    WrongError = "检查窗4扭力上限";
                    SENDMSG("9");
                break;
                case 10:
                    WrongError = "检查窗5扭力下限";
                    SENDMSG("10");
                break;
                case 11:
                    WrongError = "检查窗5扭力上限";
                    SENDMSG("11");
                break;
                case 12:
                    WrongError = "检查窗6扭力下限";
                    SENDMSG("12");
                break;
                case 13:
                    WrongError = "检查窗6扭力上限";
                    SENDMSG("13");
                break;
                case 14: 
                    WrongError = "检查窗7扭力下限";
                    SENDMSG("14");
                break;
                case 15: 
                    WrongError = "检查窗7扭力上限";
                    SENDMSG("15");
                break;
                case 16: 
                    WrongError = "检查窗8扭力下限";
                    SENDMSG("16");
                break;
                case 17:
                    WrongError = "检查窗8扭力上限";
                    SENDMSG("17");
                break;
                case 18: 
                    WrongError = "扭力下限";
                    SENDMSG("18");
                break;
                case 19: 
                    WrongError = "扭力上限";
                    SENDMSG("19");
                break;
                case 20: 
                    WrongError = "马达异常";
                    SENDMSG("20");
                break;
                case 21: 
                    WrongError = "超过扭力";
                    SENDMSG("21");
                break;
           
            }
            if (Result > -1)
            {
                LstWrongmsg.Items.Add(Time + ":"+"第"+ number+"个" + WrongError);
                WrongError = Time + ":" + "第" + number + "个" + WrongError;
                zxd.LogEx(Application.StartupPath + "\\Log\\Error.csv", WrongError, true, "错误信息");
            }


        }
        #endregion

        #region //测试
        private void BtnTest_Click(object sender, EventArgs e)
        {
            test();
            
        }

        

        public void test()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            getTime();
            Realturn();
            realpow();
            numwaveform();
            getResult();
            yield();
            //getError();
           
            if (cbSave.Checked == true)
            {
                wave = new Thread(numsWaveForm);
                wave.IsBackground = true;
                wave.Start();
            }
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;

        
          
        }
        #endregion

        #region //清除数据
        private void btnClear_Click(object sender, EventArgs e)
        {
            vision.param.ResultSum = vision.param.ResultOk = 0;
            txtOK.Text = txtSpendtime.Text = "0";
            txRealpow.Text = txrealTurn.Text = "0";
           
            string inistr;
            inistr = Application.StartupPath + "\\DataResult" + "\\param.ini";
            zxd.WritePrivateProfileString("Result", "resultOK",Convert.ToString(vision.param.ResultOk), inistr);
            zxd.WritePrivateProfileString("Result", "resultSum", Convert.ToString(vision.param.ResultSum), inistr);
            txtSum.Text = Convert.ToString(vision.param.ResultSum);
            txtNumOK.Text = Convert.ToString(vision.param.ResultOk);
            lstResult.Items.Clear();
            LstWrongmsg.Items.Clear();
            lisReceiveMsg.Items.Clear();
            TimeWhole.Items.Clear();


;        }
        #endregion

        #region //LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            vision.loadconfigfile();
            txtSum.Text = Convert.ToString(vision.param.ResultSum);
            txtNumOK.Text = Convert.ToString(vision.param.ResultOk);
            ShowRecvMsgCallback = new showRecvMsgcallback(AddMsgToList);


            #region //窗体变化
            this.Resize += new EventHandler(Form1_Resize);

            X = this.Width;
            Y = this.Height;


            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用
            #endregion
            
        }
        #endregion
       


        #region //robot与控制器连接

        private TcpClient myTcpClient;//tcp客户端
        private NetworkStream ns;  //网络数据流
        //定义一个回调
        private delegate void showRecvMsgcallback(string text);
        private showRecvMsgcallback ShowRecvMsgCallback;
        private Thread ReceiveMsgThread;  //接受消息线程



        private void btnStart_Click(object sender, EventArgs e)
        {
            //string str = "192.168.0.123";
            //string str1 = "110";
            //创建并实例化ip终结点
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(vision.param.RobotIp), Convert.ToInt32(vision.param.RobotPort));
            //实例化客户端
            myTcpClient = new TcpClient();
            try
            {
                //发起Tcp链接
                myTcpClient.Connect(ipEndPoint);
                //获取绑定的网络数据流
                ns = myTcpClient.GetStream();
                //启动线程
                ReceiveMsgThread = new Thread(ReceiveMessage);
                ReceiveMsgThread.IsBackground = true;
                ReceiveMsgThread.Start();
                btnStart.Enabled = false;
                btnStop.Enabled = true;

            }
            catch (Exception ex)
            {

               // MessageBox.Show(ex.Message);
                MessageBox.Show("机器人控制器网络未打开");
            }
        }
        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    //创建字节数据接受
                    byte[] getData = new byte[1024];
                    ns.Read(getData, 0, getData.Length);
                    //转化为字符串形式
                    string msg = Encoding.Default.GetString(getData);
                    //将收到的消息放到字符串中
                    lisReceiveMsg.Invoke(ShowRecvMsgCallback, msg);
                }
              
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    //释放资源
                    if (ns != null)
                    {
                        ns.Dispose();
                    }
                    break;
                }

            }
        }

        //如果接收到ok，则取螺丝情报
        private void AddMsgToList(string text)
        {
            
            int npos = text.IndexOf("OK");
            int npo1 = text.IndexOf("NG");
            int npo2 = text.IndexOf("END");
            if (npos == 0)
            {
                string Time = System.DateTime.Now.ToString("HH:mm:ss");

                string str = "螺丝打完"+ Time;
                lisReceiveMsg.Items.Add(str);
                test();

            }
            if (npo2 == 0)
            {
                text = "节拍时间：" + text + "S";
                TimeWhole.Items.Add(text);
                zxd.LogEx(Application.StartupPath + "\\Log\\wholeTime.csv", text, true, "节拍时间");  
            }         
            if (npo1 == 0)
            {
                string Time = System.DateTime.Now.ToString("HH:mm:ss");
                string str = "螺丝NG"+ Time;
                lisReceiveMsg.Items.Add(str);
                test();
            }
           
            

        }
        #region //停止链接
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                //销毁tcp客户端
                myTcpClient.Close();
                ns.Dispose();
                ReceiveMsgThread.Abort();

            }
            catch (Exception)
            {


            }


            btnStart.Enabled = true;

        }
        #endregion

        #region //发送数据方法
        public void SENDMSG(string str)
        {
            byte[] sendData = new byte[1024];
            sendData = Encoding.Default.GetBytes(str);
            ns.Write(sendData, 0, sendData.Length);

        }
        #endregion
      
        #endregion


        #region //窗体变化
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }
        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }

        #endregion


        #region //实时监测扭力，运行信号
        public void getHoldRegister()
        {
            while (true)
            {
                ushort registeraddress = 194;
                ushort[] nums = { 0 };
                nums = master.ReadHoldingRegisters(registeraddress, 1);

                int Led = nums[0];
                switch (Led)
                {
                    case 0:
                       RunState.Text = "动作结束";
                        break;
                    case 1:
                        RunState.Text = "动作结束";
                        break;
                    case 2:
                        RunState.Text = "动作中";
                        break;
                    case 24:
                        RunState.Text = "运行异常";
                        break;
                }

                #region //当前运行命令 以删
                //ushort registeraddress1 = 195;
                //ushort[] nums1 = { 0 };
                //nums1 = master.ReadHoldingRegisters(registeraddress1, 1);

                //int Led1 = nums1[0];
                //switch (Led1)
                //{
                //    case 16:
                //        txRequest.Text = "锁螺丝";
                //        break;
                //    case 32:
                //        txRequest.Text = "松开螺丝";
                //        break;
                //    case 64:
                //         txRequest.Text = "螺丝机回转";
                //        break;
                //    case 128:
                //        txRequest.Text = "真空ON";
                //        break;
                //    case 256:
                //        txRequest.Text = "真空破坏ON";
                //        break;

                //}
                #endregion

                #region //实时监测扭力发送超过信号
                ushort registeraddresss = 23;
                ushort[] pow = { 0 };
                pow = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddresss), 1);
                double result = pow[0];
                result = result / 10d;
                double setpow = Convert.ToInt32(txsetpow.Text);
                double setpow1 = setpow * 0.5;
                double setpow2 = setpow * 0.95;
                if (result > setpow1)
                {
                    SENDMSG("22");
                }
                if (result > setpow2)
                {
                    SENDMSG("23");
                }


               textBox1.Text = Convert.ToString(result);

                #endregion

                #region //实时监测扭力不发送超过信号

                //ushort registeraddresss = 23;
                //ushort[] pow = { 0 };
                //pow = master.ReadInputRegisters((ushort)Convert.ToInt16(registeraddresss), 1);
                //double result = pow[0];
                //result = result / 10d;
                //double setpow = Convert.ToInt32(txsetpow.Text);
               
                //string str11 = Convert.ToString(result);
                //textBox1.Text = str11;
                #endregion
              
            }
           
            


        }
        #endregion

        private void btntestcom_Click(object sender, EventArgs e)
        {
            SENDMSG(txtrobot.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
